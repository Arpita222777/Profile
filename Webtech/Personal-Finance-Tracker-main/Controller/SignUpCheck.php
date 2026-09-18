<?php

require_once "../Model/Database_connection.php";
require_once("../Model/User_Model.php");
if (isset($_POST['submit'])) {

    $fname = trim($_POST['fname']);
    $lname = trim($_POST['lname']);

    $phone = trim($_POST['phone']);
    $email = trim($_POST['email']);
    $gender = trim($_POST['gender']);
    $birth_date = trim($_POST['birthdate']);
    $password = trim($_POST['password']);
    $username = trim($_POST['username']);
    $flag = true;




    if (empty($fname) || strlen($fname) < 2) {
        echo "First name must be at least 2 characters.<br>";
        $flag = false;
    }
    if (empty($lname) || strlen($lname) < 2) {
        echo "Last name must be at least 2 characters.<br>";
        $flag = false;
    }

    // Phone: numeric, length check
    if (!is_numeric($phone) || strlen($phone) == 11) {
        echo "Phone number must be numeric and at least 10 digits.<br>";
        $flag = false;
    }


    if (strlen($password) < 6) {
        echo "Password must be at least 6 characters.<br>";
        $flag = false;
    }


    if (empty($username) || strlen($username) < 10) {
        echo "Username must be at least 10 characters.<br>";
        $flag = false;
    }
    if ($flag) {
        $user = [
            'fname' => $fname,
            'lname' => $lname,
            'phone' => $phone,
            'email' => $email,
            'gender' => $gender,
            'birthdate' => $birth_date,
            'password' => $password,
            'username' => $username
        ];
        if (addUser($user)) {
            // echo json_encode(array('status'=> 'success'));
            header('location: ../View/User Authentication/Login.html');

        } else {
            echo 'User Not Added<br>';
        }

    }

}
?>