<?php

define( 'DX_ROOT_DIR', dirname( __FILE__ ) . '/' ); // full path
define( 'DX_ROOT_PATH', basename ( dirname( __FILE__) ) . '/' ); // BlogMe

$request = $_SERVER['REQUEST_URI'];
$request_home = strtolower('/' . DX_ROOT_PATH);

$components = array();
$controller = 'main';
$method = 'index';
$admin_routing = false;
$param = array();

include_once 'config/db_params.php';
include_once 'lib/database.php';
include_once 'controllers/main_controller.php';
include_once 'controllers/posts_controller.php';
include_once 'controllers/comments_controller.php';
include_once 'controllers/users_controller.php';
include_once 'models/main.php';
//include_once 'models/users.php';

if ( ! empty ( $request ) ) {
    if (strpos( $request, $request_home ) === 0) {
        $request = substr( $request, strlen( $request_home ) );
        $components = explode( '/', $request, 3);

        if ( count ($components ) > 1) {
            list ( $controller, $method) = $components;

            if ( isset ( $components[2] ) ) {
                $param = $components[2];

                // TODO: to fix this dynamic adding of controllers and models
                //include_once 'controllers/' . $controller . '_controller.php';
                include_once 'models/' . $controller . '.php';
            }
        }
    }
}

$controller_class = '\Controllers\\' . ucfirst( $controller . '_Controller');

$instance = new $controller_class();

if ( method_exists( $instance, $method) ) {
    call_user_func_array( array ( $instance, $method), array ($param) );
}

$db_object = \Lib\Database::get_instance();
$db_connection = $db_object::get_db();
//pr($db_connection);


function pr($data)
{
    echo "<pre>";
    var_dump($data); // or var_dump($data);
    echo "</pre>";
}