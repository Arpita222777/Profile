<?php
require_once('Database_connection.php');

function login($user)
{
    $con = getConnection();
    $sql = "select * from user where username='{$user['username']}' and password='{$user['password']}'";
    $result = mysqli_query($con, $sql);
    $count = mysqli_num_rows($result);

    if ($count == 1) {
        return true;
    } else {
        return false;
    }

}

function getUserByUsername()
{
    $con = getConnection();
    $username = $_SESSION['username'];
    $sql = "select * from user where username='$username'";
    $result = mysqli_query($con, $sql);
    $userData = mysqli_fetch_assoc($result);
    return $userData;
}
function getAllUser()
{

}

function deleteUser($id)
{

}

function getincom($id)
{

}

function addUser($user)
{
    $con = getConnection();
    $fname = $user['fname'];
    $lname = $user['lname'];
    $full_name = $fname . ' ' . $lname;
    $phone = $user['phone'];
    $email = $user['email'];
    $gender = $user['gender'];
    $birth_date = $user['birthdate'];
    $password = $user['password'];
    $username = $user['username'];
    $sql = "INSERT INTO user (first_name, last_name,full_name, phone, email,gender,birth_date,password,username,UserType) VALUES ( '$fname', '$lname', '$full_name', '$phone', '$email','$gender','$birth_date', '$password','$username','user')";
    if (mysqli_query($con, $sql)) {
        return true;
    } else {
        return false;
    }

}

?>