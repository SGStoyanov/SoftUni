<?php

namespace Admin\Controllers;

use Controllers\Main_Controller;

class Admin_Controller extends Main_Controller {

    // TODO: to add different admin interface
    protected $layout;

    public function __construct(
        $class_name = '\Admin\Controllers\Admin_Controller',
        $model = 'main',
        $views_dir = 'views/admin/main'
    )
    {
        parent::__construct( $class_name, $model, $views_dir);

        $auth = \Lib\Auth::get_instance();
        $logged_user = $auth -> get_logged_user();

        if( empty ( $logged_user ) ) {
            die( 'No access here!');
            // TODO: to perform redirect
        }
    }
}