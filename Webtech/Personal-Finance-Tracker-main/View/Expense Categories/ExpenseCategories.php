
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Expense Categories</title>
    <link rel="stylesheet" href="../../Asset/CSS/Expense Categories/ExpenseCategories.css">
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
        <!-- <h3 class="clsTitle">Category Manager</h3> -->
        <div class="catgAdd">
            <h3>Add Categories into Table</h3>
        <table id="myTable" class="ExTable">
            <thead>
            <tr>
                <th>Expense Category</th>
                <th>Limits</th>
            </tr>
            </thead>
            <tbody id="tableBody">
            <!-- New rows go here -->
            </tbody>
        </table>
        <input type="text" id="col1Input" placeholder="Expense Category Name" class="inText">
        <input type="text" id="col2Input" placeholder="Mony Limits" class="inText">
        <button id="addBtn">Add Category</button>
        </div>
        <div class="transaction">
            <h3>Current Transaction</h3>
        </div>
    </div>
    <script src="../../Asset/JS/Expense Categories/ExpenseCategories.js"></script>
</body>
</html>
