<?php

namespace Models;

class Tags_Model extends Main_Model {

    public function __construct( $args = array() ) {
        parent::__construct( array( 'table' => 'tags' ) );
    }

    public function tags_for_post( $post_id ) {

        $query = "SELECT t.Id, t.Name FROM Tags AS t ";
        $query .= "INNER JOIN Posts_has_Tags AS pt ON t.Id = pt.Tag_Id ";
        $query .= "INNER JOIN Posts AS p ON pt.Post_Id = p.Id ";
        $query .= "WHERE p.Id = {$post_id} ";
        $query .= "LIMIT 20";

        $result_set = $this -> dbConn -> query( $query );

        $results = $this -> process_results( $result_set );
        return $results;
    }
}