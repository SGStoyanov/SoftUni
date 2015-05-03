<?php

namespace Controllers;

class Login_Controller extends Main_Controller {

    public function __construct() {
        parent::__construct(
            get_class(),
            'main',
            '/views/login/'
        );
    }

    public function index() {
        $auth = \Lib\Auth::get_instance();

        $login_message = '';
        $user = $auth -> get_logged_user();

        if( $user ) {
            header('Location: ' . DX_URL . 'admin/posts/index');
        }

        if( empty( $user ) && isset( $_POST['username'] ) && isset( $_POST['password'] ) ) {

            $logged_in = $auth -> login( $_POST['username'], $_POST['password'] );

            if ( ! $logged_in ) {
                // TODO: to fix the response message on login
                $login_message = 'Login not successful. Try again!';
            } else {
                $login_message = 'Login was successful! Hi ' . $_POST['username'];

                header('Location: ' . DX_URL . 'admin/posts/index');
            }
        }

        echo $login_message;

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';
        include_once $this -> layout;
    }

    public function logout() {
        // TODO: to implement logout function

        $auth = \Lib\Auth::get_instance();

        $auth -> logout();

        header( 'Location: ' . DX_URL . '?msg=' . urlencode( base64_encode( "You have been successfully logged out!" ) ) );
        exit();
    }
}