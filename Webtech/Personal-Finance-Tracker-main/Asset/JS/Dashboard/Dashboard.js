fetch('../../Model/retrieveData.php')
  .then(res => res.json())
  .then(response => {
    // Line Chart for Balance
    const ctx_linechart = document.getElementById('panel1_lineChart_balance').getContext('2d');
    new Chart(ctx_linechart, {
      type: 'line',
      data: {
        labels: response.balance.labels,
        datasets: [{
          label: 'Balance ($)',
          data: response.balance.data,
          borderColor: 'rgba(75, 192, 192, 1)',
          borderWidth: 2,
          backgroundColor: 'rgba(75, 192, 192, 0.03)',
          tension: 0.4,
          fill: true,
          pointBackgroundColor: '#3498db',
          pointRadius: 3
        }]
      },
      options: {
        responsive: false,
        maintainAspectRatio: false,
        scales: {
          x: { display: false, grid: { display: false } },
          y: { display: false, grid: { display: false }, ticks: { display: false } }
        },
        plugins: {
          legend: { display: false },
          tooltip: { enabled: true }
        }
      }
    });

    // Line Chart for Savings (was bar chart before)
    const ctx_linechart_saving = document.getElementById('panel1_lineChart_savings').getContext('2d');
    new Chart(ctx_linechart_saving, {
      type: 'line',
      data: {
        labels: response.saving.labels,
        datasets: [{
          label: 'Savings ($)',
          data: response.saving.data,
          borderColor: 'rgb(255, 159, 64)',
          borderWidth: 2,
          backgroundColor: 'rgba(255, 159, 64, 0.1)',
          tension: 0.4,
          fill: true,
          pointBackgroundColor: '#ffa726',
          pointRadius: 3
        }]
      },
      options: {
        responsive: false,
        maintainAspectRatio: false,
        scales: {
          x: { display: false, grid: { display: false } },
          y: { display: false, grid: { display: false }, ticks: { display: false } }
        },
        plugins: {
          legend: { display: false },
          tooltip: { enabled: true }
        }
      }
    });

    // Bar Chart for Income (was line chart before)
    const ctx_barchart_income = document.getElementById('panel1_barChart_income').getContext('2d');
    new Chart(ctx_barchart_income, {
      type: 'bar',
      data: {
        labels: response.income.labels,
        datasets: [{
          label: 'Income ($)',
          data: response.income.data,
          backgroundColor: [
            'rgb(40, 199, 25)', 'rgb(0, 188, 212)', 'rgb(255, 87, 34)',
            'rgb(103, 58, 183)', 'rgb(255, 206, 86)', 'rgb(75, 192, 192)'
          ],
          borderColor: 'rgb(40, 199, 25)',
          borderWidth: 1,
          borderRadius: 6,
          barThickness: 15
        }]
      },
      options: {
        responsive: false,
        maintainAspectRatio: false,
        scales: {
          x: { display: false, grid: { display: false } },
          y: { display: false, grid: { display: false }, ticks: { display: false } }
        },
        plugins: {
          legend: { display: false },
          tooltip: { enabled: true }
        }
      }
    });

    // Pie Chart for Expense
    const ctx_piechart = document.getElementById('panel1_pieChart_expense').getContext('2d');
    new Chart(ctx_piechart, {
      type: 'pie',
      data: {
        labels: response.expense.labels,
        datasets: [{
          label: 'Expense',
          data: response.expense.data,
          backgroundColor: [
            'rgb(255, 99, 132)', 'rgb(54, 162, 235)', 'rgb(255, 206, 86)',
            'rgb(75, 192, 192)', 'rgb(153, 102, 255)', 'rgb(255, 159, 64)',
            'rgb(199, 199, 199)', 'rgb(83, 102, 255)', 'rgb(40, 199, 25)'
          ],
          borderWidth: 1,
          borderColor: '#ffffff'
        }]
      },
      options: {
        responsive: false,
        maintainAspectRatio: false,
        plugins: {
          legend: { display: false },
          tooltip: { enabled: true }
        }
      }
    });


const ctx_statistics = document.getElementById('statisctics').getContext('2d');

const barChart_statistics = new Chart(ctx_statistics, {
  type: 'bar',
  data: {
    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September'],
    datasets: [
      {
        label: 'Income',
        data: response.income.data,
        backgroundColor: '#4caf50',
        borderWidth: 1,
        borderRadius: 6,
        barThickness: 10
      },
      {
        label: 'Expense',
        data: response.expense.data,
        backgroundColor: '#f44336',
        borderWidth: 1,
        borderRadius: 6,
        barThickness: 10
      },
      {
        label: 'Saving',
        data: response.saving.data,
        backgroundColor: '#2196f3',
        borderWidth: 1,
        borderRadius: 10,
        barThickness: 10
      }
    ]
  },
  options: {
    responsive: true,
    maintainAspectRatio: true,
    scales: {
      x: {
        display: false,
        grid: { display: false },
        categoryPercentage: 0.5,  // spacing between months (lower = more gap)
                barPercentage: 0.8 
      },
      y: {
        display: false,
        grid: { display: false },
        ticks: { display: false }
      }
    },
    plugins: {
      legend: { display: false },
      tooltip: { enabled: true }
    }
  }
});

const totalBalance = response.balance.data.reduce((sum, val) => sum + parseFloat(val), 0);
document.getElementById('balance').innerHTML=totalBalance;
const totalSaving = response.saving.data.reduce((sum, val) => sum + parseFloat(val), 0);
document.getElementById('savings').innerHTML=totalSaving;
const totalIncome = response.income.data.reduce((sum, val) => sum + parseFloat(val), 0);
document.getElementById('income').innerHTML=totalIncome;
const totalExpense = response.expense.data.reduce((sum, val) => sum + parseFloat(val), 0);
document.getElementById('expense').innerHTML=totalExpense;

});
///////////// Event Listener
document.getElementById('overview').addEventListener('click', function() {
    document.getElementById('panel1').style.display = 'block';
    document.getElementById('panel2').style.display = 'none';
});

// document.getElementById('data').addEventListener('click', function() {
//     document.getElementById('panel1').style.display = 'none';
//     document.getElementById('panel2').style.display = 'block';
// });
let cardCount = 2;

document.addEventListener("DOMContentLoaded", () => {
  const cardContainer = document.getElementById("cardContainer");
  const addCardBtn = document.getElementById("addCardBtn");
  const scrollLeftBtn = document.getElementById("scrollLeftBtn");
  const scrollRightBtn = document.getElementById("scrollRightBtn");
  const menuShow=document.getElementById("showMenu")
  const SideNav=document.getElementById("SideNav")
  const panel1=document.getElementById('panel1')
  const panel2=document.getElementById('panel2')

  menuShow.addEventListener('click',()=>{
    if(SideNav.style.display=='block'){
        SideNav.style.display='none'
        panel1.style.left="100px"
        panel2.style.left="100px"
    }
    else {
        SideNav.style.display='block'
        panel1.style.left="200px"
        panel2.style.left="200px"
    }
  })

  // Add new card when "+" is clicked
  addCardBtn.addEventListener("click", () => {
    const cardName = prompt("Enter the name for your new card:");
    if (cardName && cardName.trim() !== "") {
      const newCard = document.createElement("div");
      newCard.className = "card";
      newCard.textContent = cardName;
      cardContainer.insertBefore(newCard, addCardBtn);
    }
  });
  scrollLeftBtn.addEventListener("click", () => {
    cardContainer.scrollBy({
      left: -160,
      behavior: "smooth",
    });
  });

  // Scroll right
  scrollRightBtn.addEventListener("click", () => {
    cardContainer.scrollBy({
      left: 160,
      behavior: "smooth",
    });
  });
});
