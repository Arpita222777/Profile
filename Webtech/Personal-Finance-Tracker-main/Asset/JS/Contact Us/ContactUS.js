document.addEventListener('DOMContentLoaded',()=>{
    namefield=document.getElementById('name')
    mailfield=document.getElementById('mail')
    messagefield=document.getElementById('message')
    sendBTN=document.getElementById('send')
    
    sendBTN.addEventListener('click',()=>{
        if(namefield.value.trim()==""){
            alert("Fill Up Your Name")
            return;
        }
        else if(mailfield.value.trim()==""){
            alert("Give Your Mail for seding message")
            return
        }
        else if(messagefield.value.trim()==""){
            alert("Your Message is Empty")
            return
        }
        alert("Message sent.")
        namefield.value=""
        mailfield.value=""
        messagefield.value=""
    })
})