<?php

namespace Config;

class Database {
    private static $db = null;

    private function __construct() {
        $host = DB_HOST;
        $username = DB_USER;
        $password = DB_PASS;
        $dbName = DB_NAME;

        if( self::$db == null ) {
            $db = new \mysqli( $host, $username, $password, $dbName );
            $db -> set_charset("utf8");

            if( $db -> connect_error ) {
                var_dump($db);
                die( 'Can not connect to database' );
            }

            self::$db = $db;
        }

    }

    public static function get_instance() {
        static $instance = null;

        if( $instance === null ) {
            $instance = new static();
        }

        return $instance;
    }

    public static function get_db() {
        return self::$db;
    }
}