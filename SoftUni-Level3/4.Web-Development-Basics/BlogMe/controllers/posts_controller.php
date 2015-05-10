<?php

namespace Controllers;

class Posts_Controller extends Main_Controller {

    private $commentsModel;
    private $usersModel;
    private $tagsModel;
    protected $comments;
    protected $authors;
    protected $tags;
    protected $posts;

    public function __construct() {
        parent::__construct(
            get_class(),
            'posts',
            '/views/posts/'
        );

        include DX_ROOT_DIR . '/models/comments_model.php';
        $this -> commentsModel = new \Models\Comments_Model();

        include DX_ROOT_DIR . '/models/users_model.php';
        $this -> usersModel = new \Models\Users_Model();

        include DX_ROOT_DIR . '/models/tags_model.php';
        $this -> tagsModel = new \Models\Tags_Model();
    }

    public function index() {
        $pageNumber = 1;
        $pageSize = 20;

        if( isset( $_POST['pageNumber'] ) && strlen( $_POST['pageNumber'] ) > 0 ) {
            if(intval($_POST['pageNumber']) > 0) {
                $pageNumber = intval( htmlspecialchars( $_POST['pageNumber'] ) );
            } else {
                $pageNumber = 1;
            }
        }

        if( isset( $_POST['pageSize'] ) && strlen( $_POST['pageSize'] ) > 0 ) {
            if( intval($_POST['pageSize']) > 0 ) {
                $pageSize = intval( htmlspecialchars( $_POST['pageSize'] ) );
            } else {
                $pageSize = 20;
            }
        }

        $from = ($pageNumber - 1) * $pageSize;
        $this -> posts = $this -> model ->
            listAll( array( 'limit' => array('from' => $from, 'pageSize' => $pageSize) ) );

        $totalCount = $this -> model -> getCount('posts');
        $totalCount = $totalCount[0];

        $this -> comments = array();
        $this -> authors = array();
        $this -> tags = array();

        foreach($this -> posts as $post) {
            $post_id = $post['Id'];
            $this -> comments[$post_id] = $this -> commentsModel -> comments_for_post( $post_id );
            $this -> authors[$post_id] = $this -> usersModel -> get($post['User_Id']);
            $this -> tags[$post_id] = $this -> tagsModel -> tags_for_post( $post_id );
        }

        if (! empty($_POST['commenter']) && ! empty( $_POST['commentContent']) ) {
            $this -> add_comment();
        }

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';
        include_once $this -> layout;
    }

    private function add_comment() {
            $commenter = $_POST['commenter'];
            $comment = $_POST['commentContent'];
            $email = '';

            if( ! empty( $_POST['email'] ) ) {
                $email = $_POST['email'];
            }

            $post_id = '';
            if( ! empty( $_POST['commentPostId'] ) ) {
                $post_id = $_POST['commentPostId'];
            }

            if( strlen( $commenter ) < 2 || strlen( $commenter ) > 150 ) {
                $this -> addFieldValue('commenter', $commenter);
                $this -> addValidationError('commenter', 'The Commenter\'s name length should be between 2 and 150');
                return $this -> renderView( 'index.php' );
            }

            if( strlen( $comment ) < 3 || strlen( $comment ) > 500) {
                $this -> addFieldValue('comment', $comment);
                $this -> addValidationError('comment', 'The comment length should be between 3 and 500');
                return $this -> renderView( 'index.php');
            }

            $comment = array(
                'commenterName' => $commenter,
                'content' => $comment,
                'commenterEmail' => $email,
                'post_id' => $post_id
            );

            $isCommentAdded = $this -> commentsModel -> add( $comment );

            if( $isCommentAdded ) {
                $this -> addInfoMessage('Comment added');
                $this -> redirect($isAdminRedirect = false, 'posts');
            }

            $this -> renderView( 'index.php' );

    }
}