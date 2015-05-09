<?php

namespace Controllers;

class Comments_Controller extends Main_Controller {

    public function __construct() {
        parent::__construct(
            get_class(),
            'comments',
            '/views/posts/'
        );
    }

    public function index() {
        $comments = $this -> model -> listAll();
    }

    public function add() {
        if( ! empty ( $_POST['commenterName'] ) && ! empty ( $_POST['commentContent'] ) )
        {
            $commenter = $_POST['commenterName'];
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
                return $this -> renderView( 'add.php' );
            }

            if( strlen( $comment ) < 3 || strlen( $comment ) > 500) {
                $this -> addFieldValue('comment', $comment);
                $this -> addValidationError('comment', 'The comment length should be between 3 and 500');
                return $this -> renderView( 'add.php');
            }

            $comment = array(
                'commenterName' => $commenter,
                'content' => $comment,
                'commenterEmail' => $email,
                'post_id' => $post_id
            );

            $isCommentAdded = $this -> model -> add( $comment );

            if( $isCommentAdded ) {
                $this -> addInfoMessage('Comment added');
                $this -> redirect($isAdminRedirect = true, 'posts');
            }

        }

        $this -> renderView( 'index.php' );
    }
}