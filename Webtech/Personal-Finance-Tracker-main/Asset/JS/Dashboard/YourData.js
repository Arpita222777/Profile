document.addEventListener("DOMContentLoaded", () => {
   addItem1=document.getElementById('addItem1');
   addItem2=document.getElementById('addItem2');
   addItem3=document.getElementById('addItem3');
   addItem4=document.getElementById('addItem4');
   addPanel1=document.getElementById("addPanel1");
   addPanel2=document.getElementById("addPanel2");
   addPanel3=document.getElementById("addPanel3")

   document.getElementById('uploadForm').addEventListener('submit', function (e) {
        const fileInput = document.getElementById('file');
        if (!fileInput.value) {
            alert('Please select a file before uploading.');
            e.preventDefault();
        } else {
            alert('File uploaded successfully!');
        }
    });

   addItem1.addEventListener('click',()=>{
    if(addPanel1.style.display=='none'){
        addPanel1.style.display="block"
    }
    else {
        addPanel1.style.display='none'
    }
   })

   addItem3.addEventListener('click',()=>{
    if(addPanel3.style.display=='none'){
        addPanel3.style.display="block"
    }
    else {
        addPanel3.style.display='none'
    }
   })


   //Form Validation//income Form
   const incomeform = document.getElementById('incomeform');
   incomeform.addEventListener('submit', function(e) {
    e.preventDefault();

    const incomeMonth = document.getElementById("incomeMonth").value.trim();
    const incomeYear = document.getElementById('incomeYear').value.trim();
    const incomeAmount = document.getElementById("incomeAmount").value.trim();

    if (!incomeMonth) {
        alert("Please select a month.");
        return;
    }

    if (!incomeYear) {
        alert("Please select a year.");
        return;
    }

    if (incomeAmount === "" || isNaN(incomeAmount)) {
        alert("Please enter a valid numeric amount.");
        return;
    }

    const formType = "incomeForm";
    const data = `form_type=${formType}&month=${encodeURIComponent(incomeMonth)}&year=${encodeURIComponent(incomeYear)}&amount=${encodeURIComponent(incomeAmount)}`;

    const xhr = new XMLHttpRequest();
    xhr.open("POST", "../../Model/YourData.php", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                alert(xhr.responseText);
                incomeform.reset();
            } else {
                alert("Request failed: " + xhr.status);
            }
        }
    };

    xhr.send(data);
});

//validation of Expense form
const expenseForm = document.getElementById('expenseform');
   expenseForm.addEventListener('submit', function(e) {
    e.preventDefault();

    const expenseMonth = document.getElementById("expenseMonth").value.trim();
    const expenseYear = document.getElementById('expenseYear').value.trim();
    const expenseAmount = document.getElementById("expenseAmount").value.trim();

    if (!expenseMonth) {
        alert("Please select a month.");
        return;
    }

    if (!expenseYear) {
        alert("Please select a year.");
        return;
    }

    if (expenseAmount === "" || isNaN(expenseAmount)) {
        alert("Please enter a valid numeric amount.");
        return;
    }

    const formType = "expenseForm";
    const data = `form_type=${formType}&month=${encodeURIComponent(expenseMonth)}&year=${encodeURIComponent(expenseYear)}&amount=${encodeURIComponent(expenseAmount)}`;

    const xhr = new XMLHttpRequest();
    xhr.open("POST", "../../Model/YourData.php", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                alert(xhr.responseText);
                expenseForm.reset();
            } else {
                alert("Request failed: " + xhr.status);
            }
        }
    };

    xhr.send(data);
});

})

