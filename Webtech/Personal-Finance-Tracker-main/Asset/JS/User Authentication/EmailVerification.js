//input feild
const Email_input = document.getElementById('Email_input');
const OTP_input = document.getElementById('OTP_input');


//button
const Email_submit = document.getElementById('Email_submit');
const OTP_submit = document.getElementById('OTP_submit');

//section
const Otp_content = document.querySelector(".Otp_content");
const Email_Verify_content = document.querySelector(".Email_Verify_content");

Email_submit.addEventListener('click', function (event) {
    event.preventDefault();
    if (Email_input.value == "") {
        alert("Please Enter vaid Email");
    } else {
        Email_Verify_content.style.display = 'none';
        Otp_content.style.display = 'flex';
        Otp_content.style.flexDirection = 'column';
        Otp_content.style.alignItems = 'center';
        Otp_content.style.justifyContent = 'center';
    }



})

OTP_submit.addEventListener('click', function (event) {
    event.preventDefault();

    if (OTP_input.value == "") {
        alert('Enter OTP');
    } else if (OTP_input.value.length < 4) {

        alert('OTP Must be 4 Digit');
    } else {

        window.location.href = '../../View/User Authentication/ForgetPassword.html';
    }

})