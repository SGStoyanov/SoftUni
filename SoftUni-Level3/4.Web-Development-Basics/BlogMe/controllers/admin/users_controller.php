<?php

namespace Admin\Controllers;

class Users_Controller extends Admin_Controller {

    public function __construct() {
        parent::__construct(
            get_class(),
            'users',
            '/views/admin/users/' );
    }

    public function index() {
        $users = $this -> model -> listAll();
        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';
        include_once $this -> layout;
    }

    public function view( $id ) {
        $users = $this -> model -> get( $id );
        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';
        include_once $this -> layout;
    }
}