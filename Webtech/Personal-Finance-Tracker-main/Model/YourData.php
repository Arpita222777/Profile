<?php
session_start();
require_once('Database_connection.php');

if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['form_type'])) {
    $formType = $_POST['form_type'];
    $month = trim($_POST['month']);
    $year = intval($_POST['year']);
    $amount = trim($_POST['amount']);
    $username = $_SESSION['username'];

    if (empty($month) || empty($year) || !is_numeric($amount)) {
        echo "Invalid input.";
        exit();
    }

    $con = getConnection();

    // Get user_id from session username
    $sql1 = "SELECT user_id FROM user WHERE username = '$username'";
    $result = mysqli_query($con, $sql1);
    $row = mysqli_fetch_assoc($result);
    $userid = $row['user_id'];

    if (!$userid) {
        echo "User not found.";
        exit();
    }

    // Table name based on form
    $tableName = ($formType === 'incomeForm') ? 'income' : (($formType === 'expenseForm') ? 'expense' : '');

    if (!$tableName) {
        echo "Invalid form type.";
        exit();
    }

    // Check for duplicate month-year entry
    $checkSql = "SELECT * FROM $tableName WHERE user_id = '$userid' AND year = '$year' AND month = '$month'";
    $checkResult = mysqli_query($con, $checkSql);

    if (mysqli_num_rows($checkResult) > 0) {
        echo ucfirst($formType === 'incomeForm' ? 'Income' : 'Expense') . " data for $month $year already exists.";
        mysqli_close($con);
        exit();
    }

    // Insert new entry
    $insertSql = "INSERT INTO $tableName (user_id, year, month, amount) VALUES ('$userid', '$year', '$month', '$amount')";
    if (mysqli_query($con, $insertSql)) {
        echo ucfirst($formType === 'incomeForm' ? 'Income' : 'Expense') . " data stored successfully.";
    } else {
        echo "Error inserting data: " . mysqli_error($con);
    }

    mysqli_close($con);
} else {
    echo "Invalid request.";
}
?>
