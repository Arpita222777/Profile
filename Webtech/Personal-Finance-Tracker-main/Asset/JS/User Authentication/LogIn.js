const username = document.getElementById("username");
const password = document.getElementById("password");
const form = document.getElementById("main_form");

const login = document.getElementById("login_btn");

function isValidLength(str, maxLength = 30) {
    return str.trim().length <= maxLength;
}

login.addEventListener("click", function (e) {


    const uname = username.value.trim();
    const pwd = password.value.trim();


    if (uname === "" || pwd === "") {
        alert("Please Fill Username and Password");
        isValid = false;
    }


    if (!isValidLength(uname) || !isValidLength(pwd)) {
        alert("Username and Password must be less than 30 characters");
        isValid = false;
    }

    // // Only submit if all validations pass
    // if (isValid) {

    //     form.submit();

    // }

});
