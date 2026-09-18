<?php
session_start();
if ($_SESSION["status"]) {

    ?>
    <!DOCTYPE html>
    <html lang="en">

    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <script src="https://cdn.jsdelivr.net/npm/ag-grid-community/dist/ag-grid-community.min.js"></script>
        <script src="../../Asset/JS/Income_Recording/Income_Recording.js" defer></script>
        <title>Income Recording</title>
    </head>

    <body>
        <div class="ag-theme-quartz" style="height:100vh" id="myGrid"></div>
    </body>

    </html>

    <?php
} else {
    header("location:../User Authentication/LogIn.html");
}
?>