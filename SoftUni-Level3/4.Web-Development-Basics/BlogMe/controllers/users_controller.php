<?php

namespace Controllers;

class Users_Controller extends Main_Controller {

    public function __construct() {
        parent::__construct( get_class(), 'users', '/views/users/' );
    }

    public function index() {
        //pr( $this -> model ); die;
        $users = $this -> model -> listAll();
        pr($users);

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';

        include_once $this -> layout;
    }
}