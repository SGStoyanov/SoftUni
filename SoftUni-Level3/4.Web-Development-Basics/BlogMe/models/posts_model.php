<?php

namespace Models;

class Posts_Model extends Main_Model {

    public function __construct( $args = array() ) {
        parent::__construct( array( 'table' => 'posts' ) );
    }

    public function add( $element ) {

        $tags_array = explode( ', ', $element['tags'] );
        unset($element['tags']);
        $values_tags = array();

        foreach( $tags_array as $tag_key => $tag_value ) {
            $values_tags[] = "'" . $this -> dbConn -> real_escape_string($tag_value) . "'";
        }

        $keys = array_keys( $element ); // all keys except tags which has been already removed from the element array
        $values = array();

        foreach( $element as $key => $value ) {
            $values[] = "'" . $this -> dbConn -> real_escape_string($value) . "'";
        }

        $keys = implode( $keys, ',' );
        $values = implode( $values, ',' );

        $query = "INSERT INTO {$this -> table}($keys) VALUES($values)"; // inserting posts
        $this -> dbConn -> query( $query );
        $post_id = $this -> dbConn -> insert_id;

        foreach( $values_tags as $tag_key => $tag_value ) {

            $query_tags = "INSERT INTO Tags(Name) VALUES($tag_value)";
            $this -> dbConn -> query( $query_tags ); // inserting tags

            $tag_id = $this -> dbConn -> insert_id;
            $query_posts_has_tags = "INSERT INTO Posts_has_Tags(Post_Id, Tag_Id) VALUES($post_id, $tag_id)";
            $this -> dbConn -> query( $query_posts_has_tags ); // inserting in Posts_has_Tags table
        }

        return $this -> dbConn -> affected_rows > 0;
    }
}