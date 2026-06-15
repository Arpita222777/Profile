<?php
session_start();
require_once('Database_connection.php');
$budgetName = trim($_POST['Name']);
$budgetAmount = trim($_POST['Amount']);
$username = $_SESSION['username'];
$current_date = date("Y-m-d");

$con=getConnection();
$sql1="select user_id from user where username='$username'";
$result=mysqli_query($con,$sql1);
$row=mysqli_fetch_assoc($result);
$userid=$row['user_id'];

$sql2 = "INSERT INTO budget_goal (user_id, setamount, budgetgoalname, creation_date) VALUES ('$userid', '$budgetAmount', '$budgetName', '$current_date')";
mysqli_query($con,$sql2);

header("Location: /Personal-Finance-Tracker/View/Budget_Goals/BudgetGoals.php");
exit();


?>