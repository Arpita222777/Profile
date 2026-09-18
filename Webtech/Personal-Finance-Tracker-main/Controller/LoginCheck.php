<?php
require_once "../Model/Database_connection.php";
require_once("../Model/User_Model.php");
session_start();
if (isset($_POST['submit'])) {

    $username = trim($_POST['username']);
    $password = trim($_POST['password']);
    if (empty($username) || empty($password)) {

        echo "UserName And Password Must Be filled";

        exit;
    } else if (strlen($username) > 10) {
        echo "Username Must be within 10 charecter ";
        exit;
    }

    $user = [
        'username' => $username,
        'password' => $password
    ];
    if (login($user)) {
        // echo json_encode(array('status'=> 'success'));
        $_SESSION['status'] = true;
        $_SESSION['username'] = $username;


        $user_data = getUserByUsername();
        $_SESSION['user_data'] = $user_data;
        $type = $user_data['UserType'];
        setcookie('status', 'true', time() + 3000, '/');
        if ($type == 'user') {
            header('location:../View/Dashboard/Dashboard.php');
        } else {
            header('location:../View/Admin Panel/AdminPanel.php');
        }


    } else {
        echo 'Wrong username or password';
    }

}
?>