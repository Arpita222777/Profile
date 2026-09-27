<?php
session_start();
if (isset($_SESSION['status'])) {
  $user = $_SESSION['user_data'];


  ?>
  <!DOCTYPE html>
  <html lang="en">

  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>View Profile</title>
    <link rel="stylesheet" href="../../Asset/CSS/Profile Management/View profile.css" />
    <script src="../../Asset/JS/Profile Management/View profile.js" defer></script>
  </head>

  <body>
    <div class="profile-container">
      <h2>User Profile</h2>
      <form id="profileForm">
        <div class="form-group">
          <img src="profile.png" alt="user_img" class="user_img">
        </div>
        <div class="form-group">
          <label for="name">Full Name</label>
          <input type="text" id="name" value="<?php echo htmlspecialchars($user['full_name']); ?>" disabled />
        </div>
        <div class="form-group">
          <label for="email">Email</label>
          <input type="email" id="email" value="<?php echo htmlspecialchars($user['email']); ?>" disabled />
        </div>
        <div class="form-group">
          <label for="Username">Username</label>
          <input type="text" id="username" value="<?php echo htmlspecialchars($user['username']); ?>" readonly />
        </div>
        <div class="form-group">
          <label for="phone">Phone</label>
          <input type="tel" id="phone" value="<?php echo htmlspecialchars($user['phone']); ?>" disabled />
        </div>
        <div class="form-group">
          <label for="gender">Gender</label>
          <input type="tel" id="gender" value="<?php echo htmlspecialchars($user['gender']); ?>" disabled />
        </div>
        <div class="form-group">
          <label for="birthdate">BirthDate</label>
          <input type="date" id="birthdate" value="<?php echo htmlspecialchars($user['birth_date']); ?>" disabled />
        </div>
        <div class="button-group">
          <button type="button" id="editBtn">Edit Profile</button>
          <button type="button" id="changePassword">Change Password</button>
          <button type="submit" id="saveBtn" style="display: none;">Save</button>
          <button type="button" id="cancelBtn" style="display: none;">Cancel</button>
        </div>
      </form>
    </div>


  </body>

  </html>
  <?php
} else {
  header('location:../../View/User Authentication/Login.html');
}
?>