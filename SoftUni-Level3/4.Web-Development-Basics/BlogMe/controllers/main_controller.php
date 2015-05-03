<?php

namespace Controllers;

class Main_Controller {

    protected $class_name = null;
    protected $model = null;
    protected $views_dir;
    protected $layout = 'default.php';
    protected $logged_user = array();

    public function __construct(
        $class_name = '\Controllers\Main_Controller',
        $model = 'main',
        $views_dir = '/views/main/' ) {

        $this -> views_dir = $views_dir;
        $this -> class_name = $class_name;

        include_once DX_ROOT_DIR . "models/{$model}_model.php";
        $model_class = "\Models\\" . ucfirst( $model ) . "_Model";

        $this -> model = new $model_class( array( 'table' => 'none' ) );
        // \Models\Main_Model

        $auth = \Lib\Auth::get_instance();
        $logged_user = $auth -> get_logged_user();
        $this -> logged_user = $logged_user;

        $this -> layout = DX_ROOT_DIR . '/views/layouts/default.php';
    }

    public function index() {
        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';
        include_once $this -> layout;
    }

    public function redirectToUrl( $url ) {
        header("Location: " . $url);
        die;
    }

    public function redirect($isAdminRedirect, $controllerName, $actionName = null, $params = null) {
        $url = DX_URL;

        if( $isAdminRedirect ) {
            $url .= 'admin/';
        }

        $url .=  urlencode( $controllerName );

        if( $actionName != null ) {
            $url .= '/' . urlencode( $actionName );
        } else {
            $url .= '/index';
        }

        if( $params != null ) {
            $encodedParams = array_map($params, 'urlencode');
            $url .= implode( '/', $encodedParams );
        }

        $this -> redirectToUrl( $url );
    }

    private function addMessage($msg, $type) {
        if( ! isset($_SESSION['messages']) ) {
            $_SESSION['messages'] = array();
        }

        array_push($_SESSION['messages'], array('text' => $msg, 'type' => $type));
    }

    public function addInfoMessage($msg) {
        $this -> addMessage($msg, 'info');
    }

    public function addErrorMessage($msg) {
        $this -> addMessage($msg, 'error');
    }

}