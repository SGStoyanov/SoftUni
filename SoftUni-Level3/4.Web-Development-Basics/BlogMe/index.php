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

include_once 'controllers/main_controller.php';
include_once 'controllers/posts_controller.php';
include_once 'controllers/comments_controller.php';
include_once 'controllers/users_controller.php';

if ( ! empty ( $request ) ) {
    if (strpos( $request, $request_home ) === 0) {
        $request = substr( $request, strlen( $request_home ) );
        $components = explode( '/', $request, 3);

        if ( count ($components ) > 1) {
            list ( $controller, $method) = $components;

            if ( isset ( $components[2] ) ) {
                $param = $components[2];

                // to add something missed
            }
        }
    }
}

//pr($controller);
//pr($method);
//pr($param);

$controller_class = '\\Controllers\\' . ucfirst( $controller . '_Controller');

$instance = new $controller_class();

if ( method_exists( $instance, $method) ) {
    call_user_func_array( array ( $instance, $method), array ($param) );
}



function pr($data)
{
    echo "<pre>";
    var_dump($data); // or var_dump($data);
    echo "</pre>";
}