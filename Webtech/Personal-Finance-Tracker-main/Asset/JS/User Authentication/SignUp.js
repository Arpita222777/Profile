// Input fields
const first_name = document.getElementById("fname");
const last_name = document.getElementById("lname");
const phone = document.getElementById("phone");
const email = document.getElementById("email");
const date = document.getElementById("birthdate");
const section = document.querySelector("footer");
const password = document.getElementById('password');
const username = document.getElementById('username');

// Button
const signup = document.getElementById("signup_btn");

// Utility functions
function isFilled(...fields) {
    return fields.every(field => field.value.trim() !== "");
}

function isValidLength(str, maxLength = 30) {
    return str.trim().length <= maxLength;
}

function getSelectedGender() {
    return document.querySelector('input[name="gender"]:checked');
}

// Event listener
signup.addEventListener("click", function () {
    const oldError = document.getElementById("error_message");
    if (oldError) {
        oldError.remove();
    }

    const error = document.createElement("p");
    error.id = "error_message";

    const selectedGender = getSelectedGender();

    // Validation checks
    if (!isFilled(first_name, last_name, phone, email, date, password, username)) {
        // error.innerText = "All input fields must be filled.";
        alert("All input fields must be filled.");
    } else if (
        !isValidLength(first_name.value) ||
        !isValidLength(last_name.value) ||
        !isValidLength(phone.value)
    ) {
        // error.innerText = "First Name, Last Name, and Phone must be less than or equal to 11 characters.";
        alert("First Name, Last Name, and Phone must be less than or equal to 11 characters.");
    } else if (!selectedGender) {
        // error.innerText = "Please select a gender.";
        alert("Please select a gender.");
    } else {
        
        alert("Form submitted successfully!")


    }

    section.insertAdjacentElement('afterend', error);
});
