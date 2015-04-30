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

    // TODO: to check this function, normally it should not be needed
    public function get_by_id( $id ) {
        return $this -> listAll(
            array (
                'columns' => 'Id, Username, FullName, Email',
                'where' => 'Id = ' . $id
            )
        );
    }

    public function get( $id ) {
        $results = $this -> listAll( array( 'where' => 'id = ' . $id ) );

        return $results;
    }

    public function get_by_username ( $username ) {
        return $this -> listAll(
            array (
                'columns' => 'Id, Username, FullName, Email' ,
                'where' => "Username = '" . $username . "'"
            )
        );
    }

    public function listAll( $args = array() ) {
        $args = array_merge( array(
            'table' => $this -> table,
            'where' => '',
            'columns' => '*',
            'limit' => 0
        ), $args );

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

    public function add( $element ) {
        $keys = array_keys( $element );
        $values = array();

        foreach( $element as $key => $value ) {
            $values[] = "'" . $this -> dbConn -> real_escape_string($value) . "'";
        }

        $keys = implode( $keys, ',' );
        $values = implode( $values, ',' );

        $query = "INSERT INTO {$this -> table}($keys) VALUES($values)";

        $this -> dbConn -> query( $query );

        return $this -> dbConn -> affected_rows;
    }

    public function update( $element ) {
        $query = "UPDATE {$this -> table} SET ";

        foreach( $element as $key => $value ) {
            if( $key === 'Id' ) continue;

            $query .= "$key = '" . $this -> dbConn -> real_escape_string($value) . "', ";
        }

        $query = rtrim( $query, ', ' );
        $query .= " WHERE id = {$element['Id']}";

        $this -> dbConn -> query( $query );

        return $this -> dbConn -> affected_rows;
    }

    public function delete( $element ) {
        $query = "DELETE FROM {$this -> table} ";
        $query .= "WHERE Id = {$element['Id']}";
        pr($query);
        $this -> dbConn -> query( $query );

        return $this -> dbConn -> affected_rows;
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