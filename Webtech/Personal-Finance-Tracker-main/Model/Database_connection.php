<?php
    $host = "127.0.0.1";
    $dbname = "personal_finance_tracker";
    $dbuser = "root";
    $dbpass = "";

    function getConnection(){
        
        global $dbname;
        global $dbuser;
        global $dbpass;

        $con = mysqli_connect($GLOBALS['host'], $dbuser, $dbpass, $dbname);
        return $con;
    }
?>