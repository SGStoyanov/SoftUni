<?php

namespace Controllers;

class Users_Controller extends Main_Controller {

    public function __construct() {
        parent::__construct(
            get_class(),
            'users',
            '/views/users/' );
    }

    public function index() {
        $users = $this -> model -> listAll();
        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';
        include_once $this -> layout;
    }

    public function view( $id ) {
        $users = $this -> model -> get( $id );
        //$users = $users[0];

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';
        include_once $this -> layout;
    }
}