document.addEventListener("DOMContentLoaded", () => {
    const bname = document.getElementById('bname');
    const bamount = document.getElementById('bamount');
    const addBudget = document.getElementById("addBudget");
    const showPanel = document.getElementById("showPanel");
    const newPaAdPanel = document.getElementById("newPaAd");

    showPanel.addEventListener('click', () => {
        newPaAdPanel.style.display = (newPaAdPanel.style.display === 'none') ? "block" : "none";
    });

    const form = addBudget ? addBudget.closest('form') : null;

    if (!form) {
        console.error("Form not found. Check if #addBudget is inside a <form> element.");
        return;
    }

    form.addEventListener('submit', (e) => {
        const name = bname.value.trim();
        const amount = bamount.value.trim();

        if (name === "" || amount === "") {
            e.preventDefault();
            alert("Please fill all fields (required).");
            return;
        }

        const parsedAmount = parseFloat(amount);

        if (isNaN(parsedAmount) || parsedAmount <= 0) {
            e.preventDefault();
            alert("Please enter a valid numeric amount greater than 0.");
            return;
        }
    });
});
