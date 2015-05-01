<?php

namespace Controllers;

class Register_Controller extends Main_Controller {

    const register_not_possible = -1;

    public function __construct() {
        parent::__construct(
            get_class(),
            'main',
            'views/register/'
        );
    }
    
    public function index() {
        $auth = \Lib\Auth::get_instance();

        $register_message = '';
        $user = $auth -> get_logged_user();

        if( $user ) {
            header('Location: ' . DX_URL . 'admin/posts/index');
        }

        if( empty( $user ) && 
            isset( $_POST['username'] ) && 
            isset( $_POST['password'] ) &&
            isset( $_POST['passwordConfirmed'] ) &&
            isset( $_POST['email'] )
        ) {
            
            if( $_POST['password'] !== $_POST['passwordConfirmed'] ) {
                $register_message = 'Passwords mismatch!';
            } else {
                $username = $_POST['username'];
                $password = $_POST['password'];
                $full_name = $_POST['fullName'];
                $email = $_POST['email'];

                $user = array(
                    'Username' => $username,
                    'Password' => $password,
                    'FullName' => $full_name,
                    'Email' => $email
                );

                $is_registered = $auth -> register( $user );

                if ( $is_registered === self::register_not_possible ) {
                    $register_message = 'Register not successful. Try again!';
                    echo $register_message;
                } else {
                    $register_message = 'Register successful!';
                    echo $register_message;

                    $auth -> login($username, $password);

                    header('Location: ' . DX_URL . 'admin/posts/index');
                }
            }

        }

        echo $register_message;

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';
        include_once $this -> layout;
    }
}