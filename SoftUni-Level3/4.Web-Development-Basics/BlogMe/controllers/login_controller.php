<?php

namespace Controllers;

class Login_Controller extends Main_Controller {

    public function __construct() {
        parent::__construct( get_class(), 'main', '/views/login/' );
    }

    public function index() {
        //pr($_SESSION);
        $auth = \Lib\Auth::get_instance();

        if( ! empty ($_POST['username']) && ! empty ($_POST['password']) ) {
            $username = $_POST['username'];
            $password = $_POST['password'];

            $is_logged_in = $auth -> login( $username, $password );
            //echo ('Logged in: ');
            //pr($is_logged_in);
        }

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';
        include_once $this -> layout;
    }

    public function logout() {
        // TODO: to implement logout function
        session_start();
        session_destroy();
    }
}