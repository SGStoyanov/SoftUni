<?php

namespace Controllers;

class Main_Controller {

//    protected $class_name;
//    protected $model;
    protected $views_dir;
    protected $layout;

    public function __construct(
        $class_name = '\Controllers\Main_Controller',
        $model = 'main',
        $views_dir = '/views/main' ) {

        $this -> views_dir = $views_dir;
        $this -> class_name = $class_name;

        include_once DX_ROOT_DIR . "models/{$model}_model.php";
        $model_class = "\Models\\" . ucfirst( $model ) . "_Model";

        $this -> model = new $model_class( array( 'table' => 'none' ) );
        // \Models\Main_Model

        $this -> layout = DX_ROOT_DIR . '/views/layouts/default.php';
    }
}