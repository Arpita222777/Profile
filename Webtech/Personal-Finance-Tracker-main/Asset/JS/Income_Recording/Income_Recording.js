
const Grid_Data = {

    rowData: [
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
        { Date: "1-5-25", Payee: "ABC Company", Amount: 64950, Notes: true },
        { Date: "3-5-25", Payee: "G-Project", Amount: 33850, Notes: true },
        { Date: "5-5-25", Payee: "Bonus", Amount: 29600, Notes: false },
    ],
    defaultColDef: {

        filter: true,
        editable: true,
        floatingFilter: true,

    },
    pagination: true,
    // Column Definitions: Defines the columns to be displayed.
    columnDefs: [
        { field: "Date" },
        { field: "Payee" },
        { field: "Amount", valueFormatter: p => '$' + p.value.toLocaleString() },
        { field: "Notes" }
    ]
};

const myGridElement = document.getElementById("myGrid");
agGrid.createGrid(myGridElement, Grid_Data);