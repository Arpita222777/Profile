<?php
session_start();
if ($_SESSION['status']) {
  $user = $_SESSION['user_data'];
  ?>
  <!DOCTYPE html>
  <html lang="en">

  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Personal Finance Tracker - Dashboard</title>
    <link rel="stylesheet" href="../../Asset/CSS/Dashboard/Dashboard.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
  </head>

  <body>
    <header class="Header">
      <img class="LogoImg" src="../../Asset/CSS/Dashboard/images/Main_Logo.png" alt="Logo" />
      <img src="../../Asset/CSS/Dashboard/images/menu.png" alt="" class="menuI" id="showMenu">
      <ul>
        <li class="user-info">
          <p class="username"><?= $_SESSION['username'] ?></p>
          <p class="designation"><?php echo htmlspecialchars($user['Designation']); ?></p>
        </li>
      </ul>
      <img class="Uimg" src="../../Asset/CSS/Dashboard/images/tuhin.jpg" alt="User Image" />
      <img class="Unotify" src="../../Asset/CSS/Dashboard/images/notifications.png" alt="Notification Sign" />
      <div class="search-bar">
        <input type="text" placeholder="Search for..." />
        <i class="fa fa-search"></i>
      </div>
    </header>

    <nav class="SideNav" id="SideNav">
      <ul class="Menu">
        <li class="menuRow" id="overview">
          <img class="menuIcon" src="../../Asset/CSS/Dashboard/images/overview.png" />
          <a class="subMenu" href="#">Overview</a>
        </li>
        <li class="menuRow" id="data">
          <img class="menuIcon" src="../../Asset/CSS/Dashboard/images/data.png" />
          <a class="subMenu" href="../../View/Dashboard/YourData.php">Your Data</a>
        </li>
        <li class="menuRow">
          <img class="menuIcon" src="../../Asset/CSS/Dashboard/images/Budget.png" />
          <a class="subMenu" href="../../View/Budget_Goals/BudgetGoals.php">Budget Goal</a>
        </li>
        <li class="menuRow">
          <img class="menuIcon" src="../../Asset/CSS/Dashboard/images/debt.png" />
          <a class="subMenu" href="../../View/Debt Tracking/DebtTracking.php">Debt and Payment</a>
        </li>
        <li class="menuRow">
          <img class="menuIcon" src="../../Asset/CSS/Dashboard/images/statistics.png" />
          <a class="subMenu" href="../Income_Recording/Income_Recording.php">Income Recording</a>
        </li>
        <li class="menuRow">
          <img class="menuIcon" src="../../Asset/CSS/Dashboard/images/report.png" />
          <a class="subMenu" href="#">Report</a>
        </li>
        <li class="menuRow">
          <img class="menuIcon" src="../../Asset/CSS/Dashboard/images/account.png" />
          <a class="subMenu" href="../../Controller/ProfileCheck.php">Account</a>
        </li>
      </ul>

      <div class="logout">
        <div class="menuRow">
          <img class="menuIcon" src="../../Asset/CSS/Dashboard/images/logout.png" />
          <a class="subMenu" href="../../Controller/LogoutCheck.php">Log Out</a>
        </div>
      </div>
    </nav>
    <div class="panel1" id="panel1">
      <div class="balance">
        <h1>Balance</h1>
        <h2 id="balance">$57,569</h2>
        <canvas id="panel1_lineChart_balance" width="200" height="140"></canvas>
      </div>
      <div class="savings">
        <h1>Savings</h1>
        <h2 id="savings">$12,345</h2>
        <canvas id="panel1_lineChart_savings" width="190" height="140"
          style="margin-top: -145px; margin-left: 70px; padding-left: 10px;">
        </canvas>
      </div>
      <div class="Income">
        <h1>Income</h1>
        <h2 id="income">$25,980</h2>
        <canvas id="panel1_barChart_income" width="200" height="140" style="margin-top: -140px; margin-left: 70px;">
        </canvas>
      </div>
      <div class="Expense">
        <h1>Expense</h1>
        <h2 id="expense">$19,765</h2>
        <canvas id="panel1_pieChart_expense" width="190" height="140"></canvas>
      </div>
      <div class="FStatistics">
        <h1>Financial Statistics</h1>
        <canvas id="statisctics" width="380" height="150"></canvas>
      </div>
      <div class="AllTransactions">
        <h1>All Transactions</h1>
      </div>
    </div>
    <div class="panel2" id="panel2">
      <div class="carousel-wrapper">
        <h1>My Card</h1>
        <button class="scroll-btn scroll-left" id="scrollLeftBtn">&#8249;</button>
        <div class="card-container" id="cardContainer">
          <div class="card">Card 1</div>
          <div class="card">Card 2</div>
          <div class="card">Card 3</div>
          <div class="card">Card 4</div>
          <div class="card add-card" id="addCardBtn">+</div>
        </div>
        <button class="scroll-btn scroll-right" id="scrollRightBtn">&#8250;</button>
      </div>
      <div class="tansactions">
        <h1>Recent Transactions</h1>
        <table class="Transaction_table">
          <tr class="table_labels">
            <td>Date</td>
            <td>Description</td>
            <td>Category</td>
            <td>Amount</td>
          </tr>
          <tr class="Data">
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
          <tr class="Data">
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
          <tr class="Data">
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
          <tr class="Data">
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
          <tr class="Data">
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
          <tr class="Data">
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
          <tr class="Data">
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
          <tr class="Data">
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
          <tr class="Data">
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
        </table>
      </div>
    </div>
    <script src="../../Asset/JS/Dashboard/Dashboard.js"></script>
  </body>

  </html>
  <?php
} else {
  header('location:../../View/User Authentication/Login.html');
}
?>