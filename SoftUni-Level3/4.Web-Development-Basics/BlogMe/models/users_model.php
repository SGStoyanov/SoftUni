<?php

namespace Models;

class Users_Model extends Main_Model {

    public function __construct( $args = array() ) {
        parent::__construct( array( 'table' => 'users' ) );
    }
}