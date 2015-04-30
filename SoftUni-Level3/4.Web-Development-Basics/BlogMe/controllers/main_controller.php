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
}