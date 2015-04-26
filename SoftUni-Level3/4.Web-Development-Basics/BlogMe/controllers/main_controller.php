<?php

namespace Controllers;

class Main_Controller {

    protected $layout;
    protected $views_dir;

    public function __construct( $views_dir = '/views/main' ) {
        $this -> views_dir = $views_dir;

        $this -> layout = DX_ROOT_DIR . '/views/layouts/default.php';
    }


}