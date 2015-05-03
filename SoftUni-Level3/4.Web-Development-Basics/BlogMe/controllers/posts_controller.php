<?php

namespace Controllers;

class Posts_Controller extends Main_Controller {

    public function __construct() {
        parent::__construct(
            get_class(),
            'posts',
            '/views/posts/'
        );
    }

    public function index() {
        $pageNumber = 1;
        $pageSize = 20;

        if( isset( $_POST['pageNumber'] ) && strlen( $_POST['pageNumber'] ) > 0 ) {
            if(intval($_POST['pageNumber']) > 0) {
                $pageNumber = intval( htmlspecialchars( $_POST['pageNumber'] ) );
            } else {
                $pageNumber = 1;
            }

        }

        if( isset( $_POST['pageSize'] ) && strlen( $_POST['pageSize'] ) > 0 ) {
            if( intval($_POST['pageSize']) > 0 ) {
                $pageSize = intval( htmlspecialchars( $_POST['pageSize'] ) );
            } else {
                $pageSize = 20;
            }

        }

        $from = ($pageNumber - 1) * $pageSize;

        $this -> posts = $this -> model ->
            listAll( array( 'limit' => array('from' => $from, 'pageSize' => $pageSize) ) );

        $totalCount = $this -> model -> getCount('posts');
        $totalCount = $totalCount[0];

        $template_name = DX_ROOT_DIR . $this -> views_dir . 'index.php';
        include_once $this -> layout;
    }
}