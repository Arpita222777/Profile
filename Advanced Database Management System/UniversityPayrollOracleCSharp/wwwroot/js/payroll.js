function toNumber(value){
  var n = parseFloat(value);
  if(isNaN(n)){ return 0; }
  return n;
}

function money(value){
  return toNumber(value).toFixed(2);
}

function validateLoginForm(){
  var username = document.getElementById("email").value.trim();
  var password = document.getElementById("password").value.trim();
  var role = document.getElementById("role").value;

  if(username === "" || password === "" || role === ""){
    alert("Please fill in all fields.");
    return false;
  }
  return true;
}

function validateFacultyForm(){
  var firstName = document.getElementById("first_name").value.trim();
  var lastName = document.getElementById("last_name").value.trim();
  var email = document.getElementById("faculty_email").value.trim();
  var phone = document.getElementById("phone").value.trim();
  var emp = document.getElementById("employee_id").value.trim();
  var joining = document.getElementById("date_joining").value.trim();
  var dept = document.getElementById("department_id").value;
  var desig = document.getElementById("designation_id").value;
  var bank = document.getElementById("bank_name").value.trim();
  var account = document.getElementById("account_number").value.trim();
  var ifsc = document.getElementById("ifsc_code").value.trim();
  var base = document.getElementById("base_salary").value.trim();

  if(firstName === "" || lastName === "" || email === "" || phone === "" || emp === "" || joining === "" || dept === "" || desig === "" || bank === "" || account === "" || ifsc === "" || base === ""){
    alert("Please fill in all required fields.");
    return false;
  }
  if(email.indexOf("@") === -1 || email.indexOf(".") === -1){
    alert("Please enter a valid email address.");
    return false;
  }
  if(isNaN(base) || parseFloat(base) <= 0){
    alert("Base salary must be a number greater than 0.");
    return false;
  }
  return true;
}

function calculateFacultySalary(){
  var base = toNumber(document.getElementById("base_salary").value);
  var research = toNumber(document.getElementById("research_allowance").value);
  var house = toNumber(document.getElementById("house_rent_allowance").value);
  var total = base + research + house;
  document.getElementById("faculty_total_salary").innerHTML = total.toFixed(0);
}

function fillFacultyPayroll(){
  var select = document.getElementById("faculty_id");
  var option = select.options[select.selectedIndex];

  if(!option || select.value === ""){
    document.getElementById("payroll_department").value = "";
    document.getElementById("pay_base_salary").value = "";
    document.getElementById("pay_research_allowance").value = "";
    document.getElementById("pay_house_rent_allowance").value = "";
    calculatePayroll();
    return;
  }

  document.getElementById("payroll_department").value = option.getAttribute("data-department") || "";
  document.getElementById("pay_base_salary").value = option.getAttribute("data-base") || "0";
  document.getElementById("pay_research_allowance").value = option.getAttribute("data-research") || "0";
  document.getElementById("pay_house_rent_allowance").value = option.getAttribute("data-house") || "0";
  calculatePayroll();
}

function calculatePayroll(){
  var base = toNumber(document.getElementById("pay_base_salary").value);
  var research = toNumber(document.getElementById("pay_research_allowance").value);
  var house = toNumber(document.getElementById("pay_house_rent_allowance").value);
  var other = toNumber(document.getElementById("pay_other_allowances").value);
  var tax = toNumber(document.getElementById("tax_deduction").value);
  var pf = toNumber(document.getElementById("provident_fund").value);
  var otherDed = toNumber(document.getElementById("other_deductions").value);

  var gross = base + research + house + other;
  var deduction = tax + pf + otherDed;
  var net = gross - deduction;

  document.getElementById("gross_salary").innerHTML = gross.toFixed(2);
  document.getElementById("total_deductions").innerHTML = deduction.toFixed(2);
  document.getElementById("net_salary").innerHTML = net.toFixed(0);
}

function validatePayrollForm(){
  var faculty = document.getElementById("faculty_id").value;
  var date = document.getElementById("transaction_date").value;
  var base = document.getElementById("pay_base_salary").value.trim();

  if(faculty === "" || date === "" || base === ""){
    alert("Please fill in all required fields.");
    return false;
  }
  if(isNaN(base) || parseFloat(base) <= 0){
    alert("Base salary must be a number greater than 0.");
    return false;
  }
  return true;
}

function filterFacultyTable(){
  var q = document.getElementById("facultySearch").value.toLowerCase();
  var rows = document.querySelectorAll("#facultyTable tbody tr");
  for(var i=0; i<rows.length; i++){
    var text = rows[i].innerText.toLowerCase();
    rows[i].style.display = text.indexOf(q) !== -1 ? "" : "none";
  }
}

function printReport(){
  window.print();
}

function confirmLogout(){
  return confirm("Do you really want to logout?");
}

function validateRegisterForm(){
  var name = document.getElementById("register_name").value.trim();
  var email = document.getElementById("register_email").value.trim();
  var password = document.getElementById("register_password").value.trim();
  var confirmPassword = document.getElementById("confirm_password").value.trim();
  var role = document.getElementById("register_role").value;

  if(name === "" || email === "" || password === "" || confirmPassword === "" || role === ""){
    alert("Please fill in all fields.");
    return false;
  }
  if(email.indexOf("@") === -1 || email.indexOf(".") === -1){
    alert("Please enter a valid email address.");
    return false;
  }
  if(password.length < 4){
    alert("Password must be at least 4 characters.");
    return false;
  }
  if(password !== confirmPassword){
    alert("Password and confirm password do not match.");
    return false;
  }
  return true;
}

function validateSetupUserForm(){
  var name = document.getElementById("setup_user_name").value.trim();
  var email = document.getElementById("setup_user_email").value.trim();
  var password = document.getElementById("setup_user_password").value.trim();
  var role = document.getElementById("setup_user_role").value;

  if(name === "" || email === "" || password === "" || role === ""){
    alert("Please fill in all user fields.");
    return false;
  }
  if(email.indexOf("@") === -1 || email.indexOf(".") === -1){
    alert("Please enter a valid user email address.");
    return false;
  }
  if(password.length < 4){
    alert("Password must be at least 4 characters.");
    return false;
  }
  return true;
}

function validateDepartmentForm(){
  var name = document.getElementById("department_name").value.trim();
  var dean = document.getElementById("dean_name").value.trim();
  var email = document.getElementById("dean_email").value.trim();

  if(name === "" || dean === "" || email === ""){
    alert("Please fill in all department fields.");
    return false;
  }
  if(email.indexOf("@") === -1 || email.indexOf(".") === -1){
    alert("Please enter a valid dean email address.");
    return false;
  }
  return true;
}

function validateDesignationForm(){
  var title = document.getElementById("designation_title").value.trim();
  if(title === ""){
    alert("Please enter a designation title.");
    return false;
  }
  return true;
}

function getRoleCredential(role){
  var accounts = {
    "Admin": {email:"upms_admin", password:"admin123"},
    "Auditor": {email:"upms_auditor", password:"auditor123"},
    "Payroll Staff": {email:"upms_operator", password:"operator123"}
  };
  return accounts[role] || accounts["Payroll Staff"];
}

function updateLoginCredentialHint(){
  var roleSelect = document.getElementById("role");
  if(!roleSelect){ return; }

  var role = roleSelect.value;
  var account = getRoleCredential(role);
  var email = document.getElementById("email");
  var password = document.getElementById("password");
  var box = document.getElementById("selectedCredential");

  //if(email){ email.placeholder = account.email; }
  //if(password){ password.placeholder = account.password; }
  if(box){ box.innerHTML = role + ": " + account.email + " / " + account.password; }
}
