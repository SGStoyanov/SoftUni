<?php

namespace Admin\Controllers;

class Posts_Controller extends Admin_Controller {

    private $filtered_by_tag = false;
    private $commentsModel;
    private $usersModel;
    private $tagsModel;
    protected $comments;
    protected $authors;
    protected $tags;
    protected $posts;
    protected $post;

    protected $editing_message;
    protected $deletion_message;

    public function __construct() {
        parent::__construct(
            get_class(),
            'posts',
            '/views/admin/posts/' );

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

        if( ! $this -> filtered_by_tag ) {
            $this -> posts = $this -> model ->
            listAll( array( 'limit' => array('from' => $from, 'pageSize' => $pageSize) ) );
        }

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

    public function view( $id ) {
        $posts = $this -> model -> get( $id );

        if( empty ( $posts ) ) {
            header( 'Location: ' . DX_URL );
        }

        $posts = $posts[0];

        $user_id = $posts['User_Id'];
        include DX_ROOT_DIR . '/models/users_model.php';
        $user_model = new \Models\Users_Model();

        $users = $user_model -> get( $user_id );
        $user = $users[0];

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'view.php';
        include_once $this -> layout;
    }

    public function add() {
        if( ! empty ( $_POST['title'] ) &&
            ! empty ( $_POST['content'] ) &&
            ! empty( $_POST['tags'] )
        ) {
            $title = $_POST['title'];
            $content = explode( PHP_EOL, $_POST['content'] );
//            var_dump($content);
            $content = implode( "\n", $content );
//            var_dump($content);
//            $content = $_POST['content'];
            $tags = $_POST['tags'];
            $user_id = $this -> logged_user['id'];

            if( strlen($title) < 5 || strlen($title) > 150 ) {
                $this -> addFieldValue('title', $title);
                $this -> addValidationError('title', 'The title length should be between 5 and 150');
                return $this -> renderView( 'add.php' );
            }

            if( strlen($content) < 10 || strlen($content) > 3000) {
                $this -> addFieldValue('content', $content);
                $this -> addValidationError('content', 'The content length should be between 10 and 3000');
                return $this -> renderView( 'add.php');
            }

            if( strlen($tags) < 2 || strlen($tags) > 150) {
                $this -> addFieldValue('tags', $tags);
                $this -> addValidationError('tags', 'The tags length should be between 2 and 150');
                return $this -> renderView( 'add.php');
            }

            $post = array(
                'title' => $title,
                'content' => $content,
                'tags' => $tags,
                'user_id' => $user_id
            );

            $isPostAdded = $this -> model -> add( $post );

            if( $isPostAdded ) {
                $this -> addInfoMessage('Post added');
                $this -> redirect($isAdminRedirect = true, 'posts');
            }
        }

        $this -> renderView( 'add.php' );
    }

    public function edit( $id ) {
        $post = $this -> model -> get( $id );

        if( empty( $post ) ) {
            header( 'Location: ' . DX_ROOT_DIR . $this -> views_dir . 'index.php');
        }

        $this -> post = $post[0];

        $this -> tags = $this -> tagsModel -> tags_for_post( $this -> post['Id'] );;

        if( ! empty ( $_POST['title'] ) &&
            ! empty ( $_POST['content'] ) &&
            ! empty( $_POST['tags'] )
        ) {
            $title = $_POST['title'];
            $content = $_POST['content'];
            $tags = $_POST['tags'];
            $user_id = $this -> logged_user['id'];

            if( strlen($title) < 5 || strlen($title) > 150 ) {
                $this -> addFieldValue('title', $title);
                $this -> addValidationError('title', 'The title length should be between 5 and 150');
                return $this -> renderView( 'edit.php' );
            }

            if( strlen($content) < 10 || strlen($content) > 3000) {
                $this -> addFieldValue('content', $content);
                $this -> addValidationError('content', 'The content length should be between 10 and 3000');
                return $this -> renderView( 'edit.php' );
            }

            if( strlen($tags) < 2 || strlen($tags) > 150) {
                $this -> addFieldValue('tags', $tags);
                $this -> addValidationError('tags', 'The tags length should be between 2 and 150');
                return $this -> renderView( 'edit.php' );
            }

            $post = array(
                'Id' => $this -> post['Id'],
                'title' => $title,
                'content' => $content,
                'tags' => $tags,
                'user_id' => $user_id
            );

            $isPostEdited = false;

            if( ! empty ( $post ) ) {
                $loggedUser = $this -> logged_user;
                $loggedUser = $loggedUser['id'];
                $deletionUser = $this -> usersModel -> get($post['User_Id'] );
                $deletionUser = intval($deletionUser[0]['Id']);

                if( $loggedUser !== $deletionUser) {
                    $this -> editing_message = 'Only the Post Authors can edit their posts.';
                } else {
                    $isPostEdited = $this -> model -> update( $post );
                }
            }

            if( $isPostEdited ) {
                $this -> redirect($isAdminRedirect = true, 'posts');
                $this -> editing_message = 'Post edited successfully';
            } else {
                $this -> editing_message = 'There was a problem with the editing of the post';
            }
        }

        $this -> renderView( 'edit.php' );
    }

    public function delete( $post_id ) {
        $post = $this -> model -> get( $post_id );

        if( ! empty ( $post ) ) {
            $post = $post[0];

            $loggedUser = $this -> logged_user;
            $loggedUser = $loggedUser['id'];
            $deletionUser = $this -> usersModel -> get($post['User_Id'] );
            $deletionUser = intval($deletionUser[0]['Id']);

            if( $loggedUser !== $deletionUser) {
                $this -> deletion_message = 'Only the Post Authors can delete their posts.';
            } else {
                $this -> model -> delete( $post );
                $this -> deletion_message = 'Post deleted successfully';
            }
        }

        $this -> index();
    }

    public function search_by_tag( $tag_id ) {
        $this -> filtered_by_tag = true;
        $this -> posts = $this -> model -> posts_for_tag( $tag_id );

        $this -> index();
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
            $this -> redirect($isAdminRedirect = true, 'posts');
        }

        $this -> renderView( 'index.php' );
    }
}