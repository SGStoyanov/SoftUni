<?php

namespace Models;

class Posts_Model extends Main_Model {

    public function __construct( $args = array() ) {
        parent::__construct( array( 'table' => 'posts' ) );
    }

    public function listAll( $args = array() ) {
        $args = array_merge( array(
            'table' => $this -> table,
            'where' => '',
            'columns' => '*',
            'limit' => array('from' => 0, 'pageSize' => 20),
            'order_by' => ''
        ), $args );

        extract( $args );

        $query = "SELECT {$columns} FROM {$table}";

        if( ! empty( $where ) ) {
            $query .= ' where ' . $where;
        }

        if( ! empty( $order_by ) ) {
            $query .= ' order by ' . $order_by;
        } else {
            $query .= ' order by Id DESC';
        }

        if( ! empty( $limit ) && $limit['pageSize'] < 100 ) {
            $query .= ' limit ' . $limit['from'] . ', ' . $limit['pageSize'];
        }

        $result_set = $this -> dbConn -> query( $query );
        $results = $this -> process_results( $result_set );

        return $results;
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
            $query_tags = "INSERT INTO tags(Name) VALUES($tag_value)";
            $this -> dbConn -> query( $query_tags ); // inserting tags

            if( $this -> dbConn -> affected_rows <= 0 ) {
                echo 'There was problem with the inserting in the tags table';
                return false;
            }

            $tag_id = $this -> dbConn -> insert_id;
            $query_posts_has_tags = "INSERT INTO posts_has_tags(Post_Id, Tag_Id) VALUES($post_id, $tag_id)";
            $this -> dbConn -> query( $query_posts_has_tags ); // inserting in posts_has_tags table

            if( $this -> dbConn -> affected_rows <= 0 ) {
                echo 'There was problem with the inserting in the posts_has_tags table';
                return false;
            }
        }

        return $this -> dbConn -> affected_rows > 0;
    }

    public function posts_for_tag( $tag_id ) {
        $query = "SELECT p.Id, p.Title, p.Content, p.Visits, p.Date_Published, p.User_Id FROM posts AS p ";
        $query .= "INNER JOIN posts_has_tags AS pt ON p.Id = pt.Post_Id ";
        $query .= "INNER JOIN tags AS t ON pt.Tag_Id = t.Id ";
        $query .= "WHERE t.Id = {$tag_id} ";
        $query .= "LIMIT 100";

        $result_set = $this -> dbConn -> query( $query );
        $results = $this -> process_results( $result_set );
        return $results;
    }
}