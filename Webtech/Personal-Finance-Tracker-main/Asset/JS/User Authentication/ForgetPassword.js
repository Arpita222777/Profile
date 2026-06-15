const new_pass_input = document.getElementById('new_pass_input');
const retype_new_pass_input = document.getElementById('retype_new_pass_input');
const error = document.getElementById('error');

const new_pass_submit_btn = document.getElementById('new_pass_submit');

const new_pass_content_section = document.querySelector(".new_pass_content");
new_pass_submit_btn.addEventListener('click', function (event) {
    event.preventDefault();
    if(new_pass_input.value==""|| new_pass_input.value=="")
    {
            error.innerText="Please Enter password";
        
    }else{
        if(new_pass_input.value.length<5)
        {
            error.innerText="Password Must Be More than 5 charecter";
        }else if(new_pass_input.value!=retype_new_pass_input.value)
        {
            error.innerText="Both Password Not Same";
        }else{
             window.location.href = '../../View/User Authentication/LogIn.html';
        }
        
    }
   


})