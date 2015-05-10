<?php

use Config\Database;

define( 'DX_ROOT_DIR', dirname( __FILE__ ) . '/' ); // full path
define( 'DX_ROOT_PATH', basename ( dirname( __FILE__) ) . '/' ); // BlogMe
define( 'DX_URL', 'http://stoyanstoyanov.eu/blogme/' ); // constant url base
//define( 'DX_URL', 'http://localhost:89/blogme/' );

$request = $_SERVER['REQUEST_URI'];
$request_home = strtolower('/' . DX_ROOT_PATH);

$components = array();
$controller = 'main';
$method = 'index';
$admin_routing = false;
$params = array();

include_once 'config/db_params.php';
include_once 'config/database.php';
include_once 'config/auth.php';
include_once 'controllers/main_controller.php';
include_once 'models/main_model.php';

if( ! empty ( $request ) ) {
    if ( strpos( $request, $request_home ) === 0 ) {
        $request = substr( $request, strlen( $request_home ) );

        if( strpos( $request, 'admin/' ) === 0 ) {
            $admin_routing = true;
            include_once 'controllers/admin/admin_controller.php';
            $request = substr( $request, strlen( 'admin/' ) );
        }

        $components = explode( '/', $request, 3 );

        if( count( $components ) > 1 ) {
            list ( $controller, $method) = $components;

            if( ! $method ) {
                $method = 'index';
            }

            $params = isset( $components[2] ) ? $components[2] : array();

            $admin_folder = $admin_routing ? 'admin/' : '';

            $pathToControllerFile = 'controllers/' . $admin_folder . $controller . '_controller.php';
            include_once $pathToControllerFile;
        }
    }
}

$admin_namespace = $admin_routing ? 'Admin' : '';
$controller_class = $admin_namespace . '\Controllers\\' . ucfirst( $controller ) . '_Controller';

$instance = new $controller_class();

if( method_exists( $instance, $method ) ) {
    call_user_func_array( array( $instance, $method), array( $params ) );
} else {
    die( 'No such method' );
}

$db_object = Database::get_instance();
$db_connection = $db_object::get_db();