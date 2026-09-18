const editBtn = document.getElementById('editBtn');
const saveBtn = document.getElementById('saveBtn');
const cancelBtn = document.getElementById('cancelBtn');
const changePassBtn = document.getElementById('changePassword');
const formInputs = document.querySelectorAll('#profileForm input');

let originalValues = {};

editBtn.addEventListener('click', () => {
  formInputs.forEach(input => {
    originalValues[input.id] = input.value;
    input.disabled = false;
  });

  // Show/hide appropriate buttons
  editBtn.style.display = 'none';
  changePassBtn.style.display = 'none';
  saveBtn.style.display = 'inline-block';
  cancelBtn.style.display = 'inline-block';


  // Create file input
  if (!document.querySelector('.choose-image')) {
    const choose_picture = document.createElement('input');
    choose_picture.type = "file";
    choose_picture.name = 'choose_image';
    choose_picture.className = "choose-image";
    choose_picture.accept = "image/*"; // 

    choose_picture.addEventListener('change', function () {
      const file = this.files[0];
      const fileInput = document.querySelector('.choose-image');
      if (fileInput) {
        fileInput.remove();
      }
      if (file) {
        const reader = new FileReader();

        reader.onload = function (e) {
          user_img.src = e.target.result; // Set image preview
        };

        reader.readAsDataURL(file); // Convert file to base64 string
      }
    });


    const user_img = document.querySelector('.user_img');
    if (user_img) {
      user_img.insertAdjacentElement('afterend', choose_picture);
    } else {
      console.error("Element with class 'user_img' not found.");
    }
  }


});



cancelBtn.addEventListener('click', () => {
  formInputs.forEach(input => {
    input.value = originalValues[input.id];
    input.disabled = true;
  });
  editBtn.style.display = 'inline-block';
  saveBtn.style.display = 'none';
  cancelBtn.style.display = 'none';
});

changePassBtn.addEventListener('click', () => {
  window.location.href = '/View/Profile Management/Change Password.html';
});


document.getElementById('profileForm').addEventListener('submit', (e) => {
  e.preventDefault();
  formInputs.forEach(input => input.disabled = true);
  editBtn.style.display = 'inline-block';
  saveBtn.style.display = 'none';
  cancelBtn.style.display = 'none';
  alert('Profile saved successfully!');
});
