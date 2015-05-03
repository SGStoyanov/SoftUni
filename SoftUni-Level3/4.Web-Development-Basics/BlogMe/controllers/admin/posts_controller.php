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
        //var_dump('Page: ' . $page);
        $posts = $this -> model -> listAll();

        include DX_ROOT_DIR . '/models/tags_model.php';
        $tags_model = new \Models\Tags_Model();

        $tags = array();
        foreach($posts as $post) {
            $post_id = $post['Id'];
            $tags[$post_id] = $tags_model -> tags_for_post( $post_id );
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
            $content = $_POST['content'];
            $tags = $_POST['tags'];
            $user_id = $this -> logged_user['id'];

            $post = array(
                'title' => $title,
                'content' => $content,
                'tags' => $tags,
                'user_id' => $user_id
            );

            $this -> model -> add( $post );
            $this -> redirect($isAdminRedirect = true, 'posts');
        }

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'add.php';
        include_once $this -> layout;
    }

    public function edit( $id ) {
        $post = $this -> model -> get( $id );

        if( empty( $post ) ) {
            header( 'Location: ' . DX_ROOT_DIR . $this -> views_dir . 'index.php');
        }

        $post = $post[0];

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

            $this -> model -> update( $post );
        }

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'edit.php';
        include_once $this -> layout;
    }

    public function delete( $id ) {
        $post = $this -> model -> get( $id );

        if( ! empty ( $post ) ) {
            $post = $post[0];
            $this -> model -> delete( $post );
        }

        $this -> index();
    }
}