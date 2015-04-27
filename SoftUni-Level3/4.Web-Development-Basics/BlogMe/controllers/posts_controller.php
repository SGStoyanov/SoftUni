<?php

namespace Controllers;

class Posts_Controller extends Main_Controller {

    public function __construct() {
        echo "I'm Posts Controller <br />";
    }

    public function index() {
        echo 'I\'m the Posts index()';
    }
}