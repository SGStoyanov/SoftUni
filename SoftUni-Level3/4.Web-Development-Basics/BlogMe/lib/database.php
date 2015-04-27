<?php

namespace Lib;

class Database {
    private static $db = null;

    private function __construct() {
        $host = DB_HOST;
        $username = DB_USER;
        $password = DB_PASS;
        $dbName = DB_NAME;

        $db = new \mysqli( $host, $username, $password, $dbName );

        self::$db = $db;
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