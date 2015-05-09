<?php

namespace Admin\Controllers;

use Controllers\Main_Controller;

class Admin_Controller extends Main_Controller {

    protected $layout;

    public function __construct(
        $class_name = '\Admin\Controllers\Admin_Controller',
        $model = 'main',
        $views_dir = 'views/admin/main'
    )
    {
        parent::__construct(
            $class_name,
            $model,
            $views_dir );

        $logged_in = \Lib\Auth::get_instance() -> is_logged_in();

        if( ! $logged_in ) {
            header( 'Location: ' . DX_URL );
            exit();
        }
    }
}