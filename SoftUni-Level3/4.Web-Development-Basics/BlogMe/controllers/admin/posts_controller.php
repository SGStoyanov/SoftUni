<?php

namespace Admin\Controllers;

class Posts_Controller extends Admin_Controller {

    public function __construct() {
        parent::__construct(
            get_class(),
            'posts',
            '/views/admin/posts/' );
    }

    public function index() {
        $posts = $this -> model -> listAll();

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';

        include_once $this -> layout;
    }

    public function view( $id ) {
        $posts = $this -> model -> get( $id );

        if( empty ( $posts ) ) {
            //die('No such post exists');
            header( 'Location: ' . DX_URL );
        }

        $posts = $posts[0];
//        pr($posts);

        $user_id = $posts['User_Id'];
        include DX_ROOT_DIR . '/models/users_model.php';
        $user_model = new \Models\Users_Model();

        $users = $user_model -> get( $user_id );
        $user = $users[0];

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'view.php';

        include_once $this -> layout;
    }

    public function add() {
        if( ! empty ($_POST['title']) && ! empty ($_POST['content']) ) {
            $title = $_POST['title'];
            $content = $_POST['content'];
            $user_id = $this -> logged_user['id'];

            $post = array(
                'title' => $title,
                'content' => $content,
                'user_id' => $user_id
            );

            $this -> model -> add( $post );
        }

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'add.php';

        include_once $this -> layout;
    }

    public function edit( $id ) {
        $post = $this -> model -> get( $id );

        if( empty( $post ) ) {
            die( 'Nothing to edit here' );
        }

        $post = $post[0];
        //pr($post);

        if( ! empty( $_POST['title'] ) && ! empty( $_POST['content'] ) && ! empty( $_POST['id'] ) ) {
            $title = $_POST['title'];
            $content = $_POST['content'];
            $post_id = $_POST['id'];
            $user_id = $this -> logged_user['id'];

            $post = array(
                'Id' => $post_id,
                'Title' => $title,
                'Content' => $content,
                'User_Id' => $user_id
            );

            //pr($post);

            $this -> model -> update( $post );
        }

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'edit.php';

        include_once $this -> layout;
    }
}