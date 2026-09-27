<?php
session_start();
if($_SESSION['status']){
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Debt Tracking</title>
    <link rel="stylesheet" href="../../Asset/CSS/Debt Tracking/DebtTracking.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0../../Asset/CSS/all.min.css"/>
</head>
<body>
    <header class="Header">
        <img src="../../Asset/CSS/Dashboard/images/Main_Logo.png" alt="" class="logo">
        <ul>
            <li class="user-info">
                <p class="username">User Name</p>
                <p class="designation">Designation</p>
            </li>
        </ul>
        <img class="Uimg" src="../../Asset/CSS/Dashboard/images/tuhin.jpg" alt="User Image"/>
        <img class="Unotify" src="../../Asset/CSS/Dashboard/images/notifications.png" alt="Notification Sign"/>
        <div class="search-bar">
        <input type="text" placeholder="Search for..." />
        <i class="fa fa-search"></i>
        </div>
    </header> 
    <div class="bodyClass">
        <div class="ldash">
            <h1 class="ldash_title">Loan Dashboard</h1>
            <div class="creditCard">
                <div class="topRow">
                    <label class="label">Credit Card</label>
                    <label class="date">May, 2025</label>
                </div>
                <h1 class="money">2500</h1>
            </div>
            <div class="sLoan">
                <div class="topRow">
                    <label class="label">Student Loan</label>
                    <label class="date">July, 2026</label>
                </div>
                <h1 class="money">12500</h1>
            </div>
            <div class="morgatge">
                <div class="topRow">
                    <label class="label">Mortgage</label>
                    <label class="date">September, 2025</label>
                </div>
                <h1 class="money">150500</h1>
            </div>
        </div>
        <div class="pcalc">
            <h1 class="payCalc">Payoff Calculator</h1>
            <select id="LoanDr" class="dropdown">
                <option value="">-- Select Loan--</option>
                <option value="Credit Card">Credit Card</option>
                <option value="Student Loan">Sudent Loan</option>
                <option value="Mortgage">Mortgage</option>
            </select>
            <select id="PayDr" class="dropdown">
                <option value="">--Select Payment Frequency--</option>
                <option value="weekly">Weekly</option>
                <option value="monthly">Monthly</option>
                <option value="6monthly">6 Months</option>
                <option value="Yearly">Yearly</option>
            </select>
            <input type="text" class="intRate" placeholder="Interest Rate">
            <input type="date" class="paydate">
            <button class="calc">Calculate</button>
        </div>
        <div class="int">
            <h1 class="intTitle">Interest Analyzer</h1>
        </div>
    </div>
    <script src="../../Asset/JS/Debt Tracking/DebtTracking.js"></script>
</body>
</html>
<?php 
}
else{
    header('location: ../../View/User Authentication/LogIn.html');
}
?>