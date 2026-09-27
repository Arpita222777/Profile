//input
const username = document.getElementById('check_username');
const current_password = document.getElementById('current_pass');
const new_pass_input = document.getElementById('new_pass_input');
const retype_new_pass_input = document.getElementById('retype_new_pass_input');
//button
const new_pass_submit_btn = document.getElementById('new_pass_submit');
const current_pass_submit_btn = document.getElementById('current_pass_submit');


//section
const new_pass_content_section = document.querySelector(".new_pass_content");
const current_pass_content_section = document.querySelector(".current_pass_content");

current_pass_submit_btn.addEventListener('click', function (event) {
    event.preventDefault();
    current_pass_content_section.style.display = 'none';
    new_pass_content_section.style.display = 'flex';
    new_pass_content_section.style.flexDirection = 'column';
    new_pass_content_section.style.alignItems = 'center';
    new_pass_content_section.style.justifyContent = 'center';


})
new_pass_submit_btn.addEventListener('click', function (event) {
    event.preventDefault();

    window.location.href = '../../View/Profile Management/View profile.html';


})


