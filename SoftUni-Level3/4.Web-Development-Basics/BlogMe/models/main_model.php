<?php

namespace Models;

class Main_Model {

    protected $table;
    protected $where;
    protected $columns;
    protected $limit;
    protected $dbConn;

    public function __construct( $args = array() ) {
        //echo 'Hello from Main Model';
        $args = array_merge( array(
            'where' => '',
            'columns' => '*',
            'limit' => 0
        ), $args );

        if ( ! isset( $args['table'] ) ) {
            die( 'Table not defined.' );
        }

        extract( $args );

        $this -> table = $table;
        $this -> where = $where;
        $this -> columns = $columns;
        $this -> limit = $limit;

        $db_object = \Lib\Database::get_instance();
        $this -> dbConn = $db_object::get_db();
    }

    public function listAll( $args = array() ) {
        $defaults = array(
            'table' => $this -> table,
            'where' => '',
            'columns' => '*',
            'limit' => 0
        );

        $args = array_merge( $defaults, $args);

        extract( $args );

        $query = "SELECT {$columns} FROM {$table}";

        if( ! empty( $where ) ) {
            $query .= ' where ' . $where;
        }

        if( ! empty( $limit ) ) {
            $query .= ' limit ' . $limit;
        }

        $result_set = $this -> dbConn -> query( $query );

        $results = $this -> process_results( $result_set );

        return $results;
    }

    protected function process_results ( $result_set ) {
        $results = array();

        if( ! empty ( $result_set ) && $result_set -> num_rows > 0 ) {
            while( $row = $result_set -> fetch_assoc() ) {
                $results[] = $row;
            }
        }

        return $results;
    }
}