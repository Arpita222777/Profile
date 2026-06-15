document.getElementById('addBtn').addEventListener('click', function () {
    const col1 = document.getElementById('col1Input').value.trim();
    const col2 = document.getElementById('col2Input').value.trim();

    if (col1 === '' || col2 === '') {
      alert('Please enter values in both columns.');
      return;
    }

    const tableBody = document.getElementById('tableBody');
    const newRow = document.createElement('tr');

    const cell1 = document.createElement('td');
    const cell2 = document.createElement('td');

    cell1.textContent = col1;
    cell2.textContent = col2;

    newRow.appendChild(cell1);
    newRow.appendChild(cell2);
    tableBody.appendChild(newRow);

    // Clear inputs after adding
    document.getElementById('col1Input').value = '';
    document.getElementById('col2Input').value = '';
  });