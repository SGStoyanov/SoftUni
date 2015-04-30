<?php

namespace Lib;

class Auth {

    private static $is_logged_in = false;
    private static $logged_user = array();

    private function __construct() {
        session_set_cookie_params( 7200, "/"); // 2 hours session time
        session_start();

        if( ! empty ($_SESSION['username']) ) {
            self::$is_logged_in = true;

            self::$logged_user = array (
                'id' => $_SESSION['user_id'],
                'username' => $_SESSION['username']
            );
        }
    }

    public static function get_instance() {
        static $instance = null;

        if( $instance === null ) {
            $instance = new static();
        }

        return $instance;
    }

    public function is_logged_in() {
        return self::$is_logged_in;
    }

    public function get_logged_user() {
        return self::$logged_user;
    }

    public function login( $username, $password ) {
        $db_object = \Lib\Database::get_instance();
        $db = $db_object -> get_db();

        $statement = $db -> prepare (
            "SELECT Id, Username FROM Users " .
            "WHERE Username = ? AND " .
                  "Password = PASSWORD( ? ) LIMIT 1"
        );

        $statement -> bind_param( 'ss', $username, $password );
        $statement -> execute();

        $result_set = $statement -> get_result();

        if( $row = $result_set -> fetch_assoc() ) {
            //pr($row);
            $_SESSION['user_id'] = $row['Id'];
            $_SESSION['username'] = $row['Username'];

            return true;
        }

        return false;
    }

    public function logout() {
        session_destroy();
    }
}