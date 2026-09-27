<?php
session_start();
if (isset($_SESSION["status"])) {

    // require_once("../Model/User_Model.php");

    // $user_data = getUserByUsername();
    // $_SESSION['user_data'] = $user_data;
    header('location:../View/Profile Management/View profile.php');
} else {
    header('location:../View/User Authentication/Login.html');
}

?>