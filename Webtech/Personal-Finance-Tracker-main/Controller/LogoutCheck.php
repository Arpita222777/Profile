<?php
session_start();
session_destroy();
setcookie('status', 'false', time() - 10, '/');
header('location:../View/User Authentication/Login.html');
?>