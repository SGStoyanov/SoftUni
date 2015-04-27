<?php

namespace Models;

class Users_Model extends Main_Model {

    public function __construct() {
        parent::__construct( array( 'table' => 'Users' ));
    }
}