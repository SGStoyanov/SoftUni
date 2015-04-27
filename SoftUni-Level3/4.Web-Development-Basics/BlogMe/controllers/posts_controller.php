<?php

namespace Controllers;

class Posts_Controller extends Main_Controller {

    public function __construct() {
        parent::__construct( get_class(), 'posts', '/views/posts/' );
    }

    public function index() {
        //pr( $this -> model ); die;
        $posts = $this -> model -> listAll();

        foreach ($posts as $post) {
            echo "{$post['Title']}<br />";
        }

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';

        include_once $this -> layout;
    }
}