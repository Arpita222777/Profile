<?php
session_start();
require_once('../../Model/Database_connection.php');
if($_SESSION['status']){
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Your Data</title>
    <link rel="stylesheet" href="../../Asset/CSS/Dashboard/YourData.css">
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
        <h1 class="titleBody" style="padding: 15px; font-size: 24px; background-color:transparent; text-align: center; margin: 20px 0; ">Your All Data</h1>

        <div class="bodyclass1">
            <div class="balance">
                <h1 style="margin: 10px; font-size: 18px;background-color: transparent;">Your Monthly Balance</h1>
                <table class="allTable" >
                    <?php
                        $con = getConnection();

                        $username = $_SESSION['username'];
                        $sql1 = "SELECT user_id FROM user WHERE username = '$username'";
                        $result1 = mysqli_query($con, $sql1);
                        $row1 = mysqli_fetch_assoc($result1);
                        $userid = $row1['user_id'];

                        // Fetch savings ordered chronologically (by year, then month)
                        $sqlSavings = "
                            SELECT year, month, amount
                            FROM saving
                            WHERE user_id = '$userid'
                            ORDER BY year ASC,
                                CASE month
                                    WHEN 'January' THEN 1 WHEN 'February' THEN 2 WHEN 'March' THEN 3 WHEN 'April' THEN 4
                                    WHEN 'May' THEN 5 WHEN 'June' THEN 6 WHEN 'July' THEN 7 WHEN 'August' THEN 8
                                    WHEN 'September' THEN 9 WHEN 'October' THEN 10 WHEN 'November' THEN 11 WHEN 'December' THEN 12
                                    ELSE 13
                                END ASC
                        ";

                        $resultSavings = mysqli_query($con, $sqlSavings);

                        $cumulative = 0;
                        while ($row = mysqli_fetch_assoc($resultSavings)) {
                            $cumulative += floatval($row['amount']);
                            $year = $row['year'];
                            $month = $row['month'];

                            // Insert or update balance table
                            $sqlInsertBalance = "
                                INSERT INTO balance (user_id, year, month, balance)
                                VALUES ('$userid', '$year', '$month', '$cumulative')
                                ON DUPLICATE KEY UPDATE balance = VALUES(balance)
                            ";
                            mysqli_query($con, $sqlInsertBalance);
                        }

                        // Now display balance table
                        $sqlDisplay = "
                            SELECT year, month, balance
                            FROM balance
                            WHERE user_id = '$userid'
                            ORDER BY year DESC,
                                CASE month
                                    WHEN 'January' THEN 1 WHEN 'February' THEN 2 WHEN 'March' THEN 3 WHEN 'April' THEN 4
                                    WHEN 'May' THEN 5 WHEN 'June' THEN 6 WHEN 'July' THEN 7 WHEN 'August' THEN 8
                                    WHEN 'September' THEN 9 WHEN 'October' THEN 10 WHEN 'November' THEN 11 WHEN 'December' THEN 12
                                    ELSE 13
                                END DESC
                        ";

                        $resultDisplay = mysqli_query($con, $sqlDisplay);

                        // Table headers
                        echo "<tr>
                                <th style='border: 1px solid black; padding: 8px;'>Year</th>
                                <th style='border: 1px solid black; padding: 8px;'>Month</th>
                                <th style='border: 1px solid black; padding: 8px;'>Balance</th>
                            </tr>";

                        while ($row = mysqli_fetch_assoc($resultDisplay)) {
                            echo "<tr>";
                            echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['year']) . "</td>";
                            echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['month']) . "</td>";
                            echo "<td style='border: 1px solid black; padding: 8px;'>" . number_format($row['balance'], 2) . "</td>";
                            echo "</tr>";
                        }

                        mysqli_close($con);
                    ?>

                </table>
            </div>
            <div class="saving">
                <h1 style="margin: 10px; font-size: 18px;background-color: transparent;">Your Monthly Savings</h1>
                <table class="allTable" >
                    <?php
                        $con = getConnection();

                        // Get current user's user_id
                        $username = $_SESSION['username'];
                        $sql1 = "SELECT user_id FROM user WHERE username = '$username'";
                        $result1 = mysqli_query($con, $sql1);
                        $row1 = mysqli_fetch_assoc($result1);
                        $userid = $row1['user_id'];

                        // Update the saving table: calculate income - expense per month and insert/update
                        $updateSavingsSql = "
                            INSERT INTO saving (user_id, year, month, amount)
                            SELECT 
                                i.user_id, 
                                i.year, 
                                i.month, 
                                COALESCE(SUM(i.amount),0) - COALESCE(SUM(e.amount),0) AS amount
                            FROM 
                                income i
                            LEFT JOIN 
                                expense e ON i.user_id = e.user_id AND i.year = e.year AND i.month = e.month
                            WHERE i.user_id = '$userid'
                            GROUP BY 
                                i.user_id, i.year, i.month
                            ON DUPLICATE KEY UPDATE
                                amount = VALUES(amount),
                                created_at = CURRENT_TIMESTAMP;
                        ";

                        mysqli_query($con, $updateSavingsSql);

                        // Now select savings data for display
                        $sql2 = "SELECT year, month, amount, created_at FROM saving WHERE user_id = '$userid' ORDER BY year DESC, month DESC";
                        $result2 = mysqli_query($con, $sql2);

                        // Table headers
                        echo "<tr>
                                <th style='border: 1px solid black; padding: 8px;'>Year</th>
                                <th style='border: 1px solid black; padding: 8px;'>Month</th>
                                <th style='border: 1px solid black; padding: 8px;'>Amount</th>
                                <th style='border: 1px solid black; padding: 8px;'>Added At</th>
                            </tr>";

                        // Table rows
                        while ($row = mysqli_fetch_assoc($result2)) {
                            echo "<tr>";
                            echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['year']) . "</td>";
                            echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['month']) . "</td>";
                            echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['amount']) . "</td>";
                            echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['created_at']) . "</td>";
                            echo "</tr>";
                        }

                        mysqli_close($con);
                    ?>
                </table>
            </div>
        </div>
        <div class="bodyclass2">
             <div class="income">
                <h1 style="margin: 10px; font-size: 18px;background-color: transparent;">Your Monthly Income</h1>
                <table class="allTable" >
                    <?php
                    $con = getConnection();

                    // Get current user's user_id
                    $username = $_SESSION['username'];
                    $sql1 = "SELECT user_id FROM user WHERE username = '$username'";
                    $result1 = mysqli_query($con, $sql1);
                    $row1 = mysqli_fetch_assoc($result1);
                    $userid = $row1['user_id'];

                    // Get income records for the user
                    $sql2 = "SELECT year, month, amount, created_at FROM income WHERE user_id = '$userid' ORDER BY created_at DESC";
                    $result2 = mysqli_query($con, $sql2);

                    // Table headers
                    echo "<tr>
                            <th style='border: 1px solid black; padding: 8px;'>Year</th>
                            <th style='border: 1px solid black; padding: 8px;'>Month</th>
                            <th style='border: 1px solid black; padding: 8px;'>Amount</th>
                            <th style='border: 1px solid black; padding: 8px;'>Added At</th>
                        </tr>";

                    // Table rows
                    while ($row = mysqli_fetch_assoc($result2)) {
                        echo "<tr>";
                        echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['year']) . "</td>";
                        echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['month']) . "</td>";
                        echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['amount']) . "</td>";
                        echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['created_at']) . "</td>";
                        echo "</tr>";
                    }
                    ?>
                </table>
                 <button class="addItem" id="addItem1">Add New Month</button>
                <div class="addPanel1"id="addPanel1">
                    <form id="incomeform">
                        <input type="hidden" name="form_type" value="form1">
                        <table class="tableAd">
                            <tr>
                                <td><label for="">Month </label></td>
                                <td>
                                    <select id="incomeMonth" name="month">
                                        <option value="">--Select--</option>
                                        <option value="January">January</option>
                                        <option value="February">February</option>
                                        <option value="March">March</option>
                                        <option value="April">April</option>
                                        <option value="May">May</option>
                                        <option value="June">June</option>
                                        <option value="July">July</option>
                                        <option value="August">August</option>
                                        <option value="September">September</option>
                                        <option value="October">October</option>
                                        <option value="November">November</option>
                                        <option value="December">December</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td><label for="">Year</label></td>
                                <td>
                                    <select id="incomeYear" name="year1">
                                        <option value="">--Select--</option>
                                        <option value="2018">2018</option>
                                        <option value="2019">2019</option>
                                        <option value="2020">2020</option>
                                        <option value="2021">2021</option>
                                        <option value="2022">2022</option>
                                        <option value="2023">2023</option>
                                        <option value="2024">2024</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td><label for="">Amount </label></td>
                                <td><input type="text" id="incomeAmount"></td>
                            </tr>
                            <tr>
                                <td><input id="add1" type="submit" value="Add" style="width: 60px;"></td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
            <div class="expense">
                <h1 style="margin: 10px; font-size: 18px;background-color: transparent;">Your Monthly Expense</h1>
                <table class="allTable" >
                    <?php
                    $con = getConnection();

                    // Get current user's user_id
                    $username = $_SESSION['username'];
                    $sql1 = "SELECT user_id FROM user WHERE username = '$username'";
                    $result1 = mysqli_query($con, $sql1);
                    $row1 = mysqli_fetch_assoc($result1);
                    $userid = $row1['user_id'];

                    // Get income records for the user
                    $sql2 = "SELECT year, month, amount, created_at FROM expense WHERE user_id = '$userid' ORDER BY created_at DESC";
                    $result2 = mysqli_query($con, $sql2);

                    // Table headers
                    echo "<tr>
                            <th style='border: 1px solid black; padding: 8px;'>Year</th>
                            <th style='border: 1px solid black; padding: 8px;'>Month</th>
                            <th style='border: 1px solid black; padding: 8px;'>Amount</th>
                            <th style='border: 1px solid black; padding: 8px;'>Added At</th>
                        </tr>";

                    // Table rows
                    while ($row = mysqli_fetch_assoc($result2)) {
                        echo "<tr>";
                        echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['year']) . "</td>";
                        echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['month']) . "</td>";
                        echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['amount']) . "</td>";
                        echo "<td style='border: 1px solid black; padding: 8px;'>" . htmlspecialchars($row['created_at']) . "</td>";
                        echo "</tr>";
                    }
                    ?>
                </table>
                 <button class="addItem" id="addItem3">Add New Month</button>
                 <div class="addPanel1"id="addPanel3">
                    <form id="expenseform">
                        <input type="hidden" name="form_type" value="form1">
                        <table class="tableAd">
                            <tr>
                                <td><label for="">Month </label></td>
                                <td>
                                    <select id="expenseMonth" name="month">
                                        <option value="">--Select--</option>
                                        <option value="January">January</option>
                                        <option value="February">February</option>
                                        <option value="March">March</option>
                                        <option value="April">April</option>
                                        <option value="May">May</option>
                                        <option value="June">June</option>
                                        <option value="July">July</option>
                                        <option value="August">August</option>
                                        <option value="September">September</option>
                                        <option value="October">October</option>
                                        <option value="November">November</option>
                                        <option value="December">December</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td><label for="">Year</label></td>
                                <td>
                                    <select id="expenseYear" name="year1">
                                        <option value="">--Select--</option>
                                        <option value="2018">2018</option>
                                        <option value="2019">2019</option>
                                        <option value="2020">2020</option>
                                        <option value="2021">2021</option>
                                        <option value="2022">2022</option>
                                        <option value="2023">2023</option>
                                        <option value="2024">2024</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td><label for="">Amount </label></td>
                                <td><input type="text" id="expenseAmount"></td>
                            </tr>
                            <tr>
                                <td><input id="add1" type="submit" value="Add" style="width: 60px;"></td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
        <div class="upFile">
            <form id="uploadForm" action="../../Model/file_handle.php" method="post" enctype="multipart/form-data" style="background-color: white; color: black; border: 1px solid black; padding: 20px; width: 300px; font-family: Arial, sans-serif; border-radius: 8px; box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.1);">
                <label for="file" style="display: block; margin-bottom: 8px; font-weight: bold;">Upload your document:</label>
                <input type="file" name="file" id="file" required style="margin-bottom: 15px; width: 100%;">
                <button type="submit" name="submit" style="background-color: black; color: white; padding: 8px 16px; border: none; border-radius: 4px; cursor: pointer;">Upload</button>
            </form>
        </div>
    </div>
    
    <script src="../../Asset/JS/Dashboard/YourData.js"></script>
</body>
</html>
<?php
}
else{
    header('location: ../../View/User Authentication/Login.html');
}
?>