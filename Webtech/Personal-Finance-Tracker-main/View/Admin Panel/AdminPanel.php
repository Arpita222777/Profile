<?php
session_start();
require_once('../../Model/Database_connection.php');
if($_SESSION['status']){
    $user = $_SESSION['user_data'];
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../../Asset/CSS/Admin_Panel/AdminPanel.css">
    <title>Admin Panel</title>
</head>
<body>
    <header class="header">
        <div class="head">
            <img src="../../Asset/CSS/Admin Panel/images/dashBoard.png" alt="" class="dashimg">
            <h1 class="dashText">Dashboard</h1>
            <div class="searchDiv">
                <input type="text" id="searchText" placeholder="Search...">
                <img src="../../Asset/CSS/Admin Panel/images/search.png" alt="" class="searchIcon">
            </div>
            <img src="../../Asset/CSS/Admin Panel/images/notification.png" alt="" class="notification">
            <div class="profile">
                <img src="../../Asset/CSS/Admin Panel/images/tuhin.jpg" class="userImage" alt="">
                <div class="nameDes">
                    <h1 class="name"><?php echo htmlspecialchars($user['username']); ?></h1>
                    <h1 class="designation"><?php echo htmlspecialchars($user['Designation']); ?></h1>
                </div>
                <img id="profileDetails" src="../../Asset/CSS/Admin Panel/images/downarrow2.png" alt="">
            </div>
        </div>
    </header>
    <div class="adminDetails"id="adminDetails">
        <div class="imgandname">
            <img src="../../Asset/CSS/Admin Panel/images/tuhin.jpg" class="UimgEx">
            <h1 class="nameEx"><?=$_SESSION['username']?></h1>
        </div>
        <ul class="poptions">
            <li class="profileOptions">
                <img src="../../Asset/CSS/Admin Panel/images/info.png" class="profileOptionImg" alt="">
                <a class="profileOptions2" href="#">Profile Information</a>
            </li>
            <li class="profileOptions">
                <img src="../../Asset/CSS/Admin Panel/images/support.png" class="profileOptionImg" alt="">
                <a class="profileOptions2" href="#">Support and Help</a>
            </li>
            <hr class="line">
            <li class="profileOptions">
                <img src="../../Asset/CSS/Admin Panel/images/account.png" class="profileOptionImg" alt="">
                <a class="profileOptions2" href="#">Deactive/Close Account</a>
            </li>
            <li class="profileOptions">
                <img src="../../Asset/CSS/Admin Panel/images/logout.png" class="profileOptionImg" alt="">
                <a class="profileOptions2" href="../../Controller/LogoutCheck.php">Logout</a>
            </li>
        </ul>
    </div>
    <nav class="sideNav">
        <img class="mainLogo" src="../../Asset/CSS/Admin Panel/images/Main_Logo.png" alt="">
        <ul class="menu">
            <li class="menuRow" id="Dashboard">
                <img class="menuIcon"src="../../Asset/CSS/Admin Panel/images/home.png" alt="home">
                <a class="subMenu" href="#">Dashboard</a>
            </li>
            <li class="menuRow" id="alluser">
                <img class="menuIcon"src="../../Asset/CSS/Admin Panel/images/allUser.png" alt="home">
                <a class="subMenu" href="#" >All User</a>
                <img class="menuIcon" id="all-Pending" src="../../Asset/CSS/Admin Panel/images/downarrow.png" alt="">
            </li>
            <li class="menuRow" id="pendingUser">
                <img class="menuIcon"src="../../Asset/CSS/Admin Panel/images/pendingUser.png" alt="home">
                <a class="subMenu" href="#">Pending User</a>
            </li>
            <li class="menuRow" id="addUser">
                <img class="menuIcon"src="../../Asset/CSS/Admin Panel/images/addUser.png" alt="home">
                <a class="subMenu" href="#">Add User</a>
            </li>
            <li class="menuRow">
                <img class="menuIcon"src="../../Asset/CSS/Admin Panel/images/allTransaction.png" alt="home">
                <a class="subMenu" href="#">All Transactions</a>
            </li>
            <li class="menuRow">
                <img class="menuIcon"src="../../Asset/CSS/Admin Panel/images/report.png" alt="home">
                <a class="subMenu" href="#">Reports</a>
            </li>
            <li class="menuRow" id="setting">
                <img class="menuIcon"src="../../Asset/CSS/Admin Panel/images/settings.png" alt="home">
                <a class="subMenu" href="#">Settings</a>
            </li>
        </ul>
    </nav>
    <div class="settingPanel" id="settingPanel">
        <div class="adminAccountSetting">
            <img src="../../Asset/CSS/Admin Panel/images/adminSetting.png" alt="Settings Icon" class="settingIcon">
            <h1 class="headline">Admin Account Setting</h1>
            <ul class="options">
                <li class="optionsList">Change Admin Password</li>
                <li class="optionsList">Update Email/UserName</li>
                <li class="optionsList">Add/Remove Admins</li>
                <li class="optionsList">Two Factor Authentications</li>
            </ul>
        </div>
        <div class="adminAppearence">
            <img src="../../Asset/CSS/Admin Panel/images/ui.png" alt="Settings Icon" class="settingIcon">
            <h1 class="headline">Appearence Setting</h1>
            <ul class="options">
                <li class="optionsList">Change Brand Logo</li>
                <li class="optionsList">Email and Notification Setting</li>
                <li class="optionsList">Language Setting</li>
            </ul>
        </div>
        <div class="systemConfiguration">
            <img src="../../Asset/CSS/Admin Panel/images/system.png" alt="Settings Icon" class="settingIcon">
            <h1 class="headline">System Configuration</h1>
            <ul class="options">
                <li class="optionsList">Enable Maintainence Mode</li>
                <li class="optionsList">BackUp and Recovery Setting</li>
            </ul>
        </div>
    </div>
    <div class="allUserPanel" id="allUserPanel">
        <table class="allTable">
            <?php
            $con = getConnection();

            if (isset($_GET['delete_id'])) {
                $delete_id = intval($_GET['delete_id']);
                $stmt = $con->prepare("DELETE FROM user WHERE user_id = ?");
                $stmt->bind_param("i", $delete_id);
                $stmt->execute();
                $stmt->close();
            }

            $sql = "SELECT user_id, first_name, last_name, full_name, phone, email, gender, birth_date, username, UserType, Designation 
                    FROM user 
                    WHERE UserType = 'user' 
                    ORDER BY user_id ASC";

            $result = $con->query($sql);

            echo "<thead><tr>
                    <th>User ID</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Full Name</th>
                    <th>Phone</th>
                    <th>Email</th>
                    <th>Gender</th>
                    <th>Birth Date</th>
                    <th>Username</th>
                    <th>User Type</th>
                    <th>Designation</th>
                    <th>Delete</th>
                </tr></thead><tbody>";

            while ($row = $result->fetch_assoc()) {
                echo "<tr>";
                echo "<td>" . htmlspecialchars($row['user_id']) . "</td>";
                echo "<td>" . htmlspecialchars($row['first_name']) . "</td>";
                echo "<td>" . htmlspecialchars($row['last_name']) . "</td>";
                echo "<td>" . htmlspecialchars($row['full_name']) . "</td>";
                echo "<td>" . htmlspecialchars($row['phone']) . "</td>";
                echo "<td>" . htmlspecialchars($row['email']) . "</td>";
                echo "<td>" . htmlspecialchars($row['gender']) . "</td>";
                echo "<td>" . htmlspecialchars($row['birth_date']) . "</td>";
                echo "<td>" . htmlspecialchars($row['username']) . "</td>";
                echo "<td>" . htmlspecialchars($row['UserType']) . "</td>";
                echo "<td>" . htmlspecialchars($row['Designation']) . "</td>";
                echo "<td>
                        <a href='?delete_id=" . $row['user_id'] . "' 
                        onclick=\"return confirm('Are you sure you want to delete this user?')\">
                        Delete
                        </a>
                    </td>";
                echo "</tr>";
            }
            echo "</tbody>";
            ?>
        </table>

        <?php
        $con->close();
        ?>


    </div>
    <div class="dashboardPanel" id="dashboardPanel">
        <div class="summarydiv">
            <h1 class="scard">Summary Card (Top Metrics)</h1>
            <div class="sdivTotalUser">
                <h1>Total User</h1>
                <?php
                    $con = getConnection();

                    $countSql = "SELECT COUNT(*) AS total FROM user";
                    $countResult = $con->query($countSql);
                    $rowCount = 0;

                    if ($countResult && $countResult->num_rows > 0) {
                        $row = $countResult->fetch_assoc();
                        $rowCount = $row['total'];
                    }
                ?>

                <h2><?php echo number_format($rowCount); ?></h2>
            </div>
            <div class="sdivActiveUser">
                <h1>Active User</h1>
                <h2>---</h1>
            </div>
            <div class="sdivTotalTransaction">
                <h1>Total Transaction</h1>
                <h2>---</h1>
            </div>
        </div>
        <div class="userInsight">
            <h1>User Insights</h1>
            <ul class="ULuserInsight">
                <li class="ULset">
                    <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/user.png">
                    <a class="ULa" href="#">Top User</a>
                    <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
                </li>
                <hr class="ULline">
                <li class="ULset">
                    <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/activeUser.png">
                    <a class="ULa" href="#">Most Active User</a>
                    <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
                </li>
                <hr class="ULline">
                <li class="ULset">
                    <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/newUser.png">
                    <a class="ULa" href="#">Newly Registered Users (Last 7 Days)</a>
                    <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
                </li>
                <hr class="ULline">
                <li class="ULset">
                    <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/alert.png">
                    <a class="ULa" href="#">Suspicious or Unusual Activily Alerts</a>
                    <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
                </li>
            </ul>
    </div>
    <div class="Notification">
    <h1>Notification</h1>
    <ul class="ULnotification">
        <li class="ULset">
            <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/bug.png">
            <a class="ULa" href="#">Feedback or Bug Reports</a>
            <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
        </li>
        <hr class="ULline">
        <li class="ULset">
            <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/support2.png">
            <a class="ULa" href="#">Support Messages</a>
            <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
        </li>
        <hr class="ULline">
        <li class="ULset">
            <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/system.png">
            <a class="ULa" href="#">System Message</a>
            <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
        </li>
        <hr class="ULline">
        <li class="ULset">
            <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/emailsetting.png">
            <a class="ULa" href="#">Email Setting</a>
            <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
        </li>
        <hr class="ULline">
        <li class="ULset">
            <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/notificationCenter.png">
            <a class="ULa" href="#">Notification Center</a>
            <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
        </li>
        <hr class="ULline">
        <li class="ULset">
            <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/notificationSetting.png">
            <a class="ULa" href="#">Notification Setting</a>
            <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
        </li>
    </ul>
</div>
        <div class="systemMonitor">
            <h1>System Monitoring and Maintenance</h1>
            <ul class="ULsystemMonitor">
                <li class="ULset">
                    <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/server.png">
                    <a class="ULa" href="#">Server Health</a>
                    <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
                </li>
                <hr class="ULline">
                <li class="ULset">
                    <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/backup.png">
                    <a class="ULa" href="#">Backup Status</a>
                    <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
                </li>
                <hr class="ULline">
                <li class="ULset">
                    <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/update.png">
                    <a class="ULa" href="#">Version Control/ Last Update</a>
                    <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
                </li>
                <hr class="ULline">
                <li class="ULset">
                    <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/security.png">
                    <a class="ULa" href="#">Security Monitoring</a>
                    <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
                </li>
                <hr class="ULline">
                <li class="ULset">
                    <img class="ULicon" src="../../Asset/CSS/Admin Panel/images/performance.png">
                    <a class="ULa" href="#">Performance Metrics</a>
                    <img class="ULarrow" src="../../Asset/CSS/Admin Panel/images/forward.png" alt="">
                </li>
            </ul>
        </div>
    </div>
    <script src="../../Asset/JS/Admin_Panel/AdminPanel.js"></script>
</body>
</html>
<?php
}
else{
    header('location: ../../View/User Authentication/Login.html');
}
?>