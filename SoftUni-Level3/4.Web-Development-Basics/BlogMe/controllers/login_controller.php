<?php

namespace Controllers;

class Login_Controller extends Main_Controller {

    protected $login_message;

    public function __construct() {
        parent::__construct(
            get_class(),
            'main',
            '/views/login/'
        );
    }

    public function index() {
        $auth = \Config\Auth::get_instance();

        $this -> login_message = '';
        $user = $auth -> get_logged_user();

        if( $user ) {
            header('Location: ' . DX_URL . 'admin/posts/index');
        }

        if( empty( $user ) && isset( $_POST['username'] ) && isset( $_POST['password'] ) ) {

            $logged_in = $auth -> login( $_POST['username'], $_POST['password'] );

            if( ! $logged_in ) {
                $this -> login_message = 'Login not successful. Try again!';
            } else {
                header('Location: ' . DX_URL . 'admin/posts/index');
            }
        }

        //echo $this -> login_message;

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';
        include_once $this -> layout;
    }

    public function logout() {
        $auth = \Config\Auth::get_instance();

        $auth -> logout();
        header('Location: ' . DX_URL . 'posts/index');
        //header( 'Location: ' . DX_URL . '?msg=' . urlencode( base64_encode( "You have been successfully logged out!" ) ) );
        //exit();
    }
}