<?php

namespace Models;

class Comments_Model extends Main_Model {

    public function __construct() {
        parent::__construct( array( 'table' => 'comments' ));
    }

    public function add( $element ) {
        if( empty( $element ) ) {
            echo 'Comment NOT added!';
            return false;
        }

        $statement = $this -> dbConn -> prepare(
            "INSERT INTO {$this -> table}(CommenterName, CommenterEmail, Content, Post_Id) " .
            "VALUES(?, ?, ?, ?)"
        );

        $statement -> bind_param("sssi", $element['commenterName'], $element['commenterEmail'], $element['content'],
            $element['post_id']);

        $statement -> execute();

        return $statement -> affected_rows > 0;
    }

    public function comments_for_post( $post_id ) {

        $query = "SELECT c.CommenterName, c.CommenterEmail, c.Content, c.Date_Commented FROM Comments AS c ";
        $query .= "INNER JOIN Posts AS p ON c.Post_Id = p.Id ";
        $query .= "WHERE c.Post_Id = {$post_id} ";
        $query .= "LIMIT 20";

        $result_set = $this -> dbConn -> query( $query );

        $results = $this -> process_results( $result_set );
        return $results;
    }
}