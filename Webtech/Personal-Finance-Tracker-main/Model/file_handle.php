<?php
session_start();


if (!isset($_SESSION['username'])) {
    die("User not logged in.");
}

if (isset($_POST['submit']) && isset($_FILES['file'])) {
    $username = $_SESSION['username'];
    $file = $_FILES['file'];

    $originalName = basename($file['name']);
    $tempPath = $file['tmp_name'];
    $uploadDir = '../Asset/uploads/';
    $newFileName = $username . "_" . $originalName;
    $targetPath = $uploadDir . $newFileName;

    if (!is_dir($uploadDir)) {
        mkdir($uploadDir, 0777, true);
    }

    if (move_uploaded_file($tempPath, $targetPath)) {
        echo "File uploaded successfully as $newFileName.";
    } else {
        echo "Error uploading the file.";
    }
} else {
    echo "No file selected.";
}
?>
