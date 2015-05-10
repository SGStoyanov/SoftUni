<?php

namespace Config;

class Auth {

    private static $is_logged_in = false;
    private static $logged_user = array();
    protected $dbConn;

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

        $this -> table = 'users';

        $db_object = Database::get_instance();
        $this -> dbConn = $db_object::get_db();
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
        $statement = $this -> dbConn -> prepare(
            "SELECT Id, Username FROM users " .
            "WHERE Username = ? AND Password = PASSWORD( ? ) LIMIT 1"
        );

        if( $statement !== FALSE ) {
            $statement -> bind_param( "ss", $username, $password );
            $statement -> execute();

            $statement -> bind_result($Id, $Username);

            if( $statement -> fetch() ) {
                $_SESSION['user_id'] = $Id;
                $_SESSION['username'] = $Username;

                return true;
            }

//            $result_set = $statement -> get_result();
//
//            if( $row = $result_set -> fetch_assoc() ) {
//                $_SESSION['user_id'] = $row['Id'];
//                $_SESSION['username'] = $row['Username'];
//
//                return true;
//            }
        }

        return false;
    }

    public function register( $element ) {
        $keys = array_keys( $element );
        $values = array();

        foreach( $element as $key => $value ) {
            if( $key === 'Password' ) {
                $values[] = "PASSWORD('" . $this -> dbConn -> real_escape_string($value) . "')";
                continue;
            }
            $values[] = "'" . $this -> dbConn -> real_escape_string($value) . "'";
        }

        $keys = implode( $keys, ',' );
        $values = implode( $values, ',' );

        $query = "INSERT INTO {$this -> table}($keys) VALUES($values)";

        $this -> dbConn -> query( $query );

        return $this -> dbConn -> affected_rows > 0;
    }

    public function logout() {
        session_destroy();
    }
}