<?php
session_start();
if($_SESSION['status']){
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Budget Goals</title>
    <link rel="stylesheet" href="../../Asset/CSS/Budget_Goals/BudgetGoals.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css"/>
</head>
<body>
    <header class="Header">
        <img src="../../Asset/CSS/Dashboard/images/Main_Logo.png" alt="" class="logo">
        <ul>
            <li class="user-info">
                <p class="username"><?= $_SESSION['username'] ?></p>
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
    <div class="bodyclass">
        <div class="bSet">
            <h1 class="bSeth1">Set Your Budget</h1>
            <input type="text" class="bSetinput">
            <input type="button"class="bSetButton" value="Set">
        </div>
        <div class="allBudget">
                <table class="tableC" style="padding: 10px; margin: 10px; margin-left: auto; margin-right: auto; border-collapse: collapse; border: 2px solid black;">
                <?php
                require_once('../../Model/Database_connection.php');
                $con = getConnection();

                // Get current user's user_id
                $username = $_SESSION['username'];
                $sql1 = "SELECT user_id FROM user WHERE username = '$username'";
                $result1 = mysqli_query($con, $sql1);
                $row1 = mysqli_fetch_assoc($result1);
                $userid = $row1['user_id'];

                // Get all budget goals for the user
                $sql2 = "SELECT budgetgoalname, setamount, creation_date FROM budget_goal WHERE user_id = '$userid'";
                $result2 = mysqli_query($con, $sql2);

                // Table headers
                echo "<tr>
                        <th style='border: 1px solid black; padding: 8px;'>Budget Name</th>
                        <th style='border: 1px solid black; padding: 8px;'>Amount</th>
                        <th style='border: 1px solid black; padding: 8px;'>Creation Date</th>
                    </tr>";

                // Table rows
                while($row = mysqli_fetch_assoc($result2)) {
                    echo "<tr>";
                    echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['budgetgoalname']) . "</td>";
                    echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['setamount']) . "</td>";
                    echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['creation_date']) . "</td>";
                    echo "</tr>";
                }
                ?>
            </table>

            <div class="allBudgetAddbtn"id="allBudgetAddbtn"></div>
            <button id="showPanel">Add New Budget Category</button>
            <div class="newPaAd"id="newPaAd">
            <form action="..\..\Model\budget.php" method="POST">
                <table class="tableB">
                    <tr>
                        <td><label for="">Budget Name: </label></td>
                        <td><input type="text" class="bname" id="bname" name="Name"></td>
                    </tr>
                    <tr>
                        <td><label for="">Budget Amount: </label></td>
                        <td><input type="text" class="bamount" id="bamount" name="Amount"></td>
                    </tr>
                    <tr>
                        <td><input type="submit" class="addBudget" id="addBudget"value="Add" style="width: 100px;padding:5px;"></td>
                    </tr>
                </table>
            </form>
            </div>
        </div>
        <div class="warning">

        </div>
    </div>
    <script src="../../Asset/JS/Budget_Goals/BudgetGoals.js"></script>
</body>
</html>
<?php
}
else{
    header('location: ../../View/User Authentication/Login.html');
}
?>