
// GET
async function loadDataToTable(apiUrl, tableId, columns, deleteCallback, editPageUrl, idKey = 'id') {
    try {
        const response = await fetch(apiUrl);
        if (!response.ok) throw new Error('Ошибка запроса');

        const data = await response.json();

        const tbody = document.getElementById(tableId).querySelector('tbody');
        tbody.innerHTML = '';

        data.forEach(item => {
            const row = document.createElement('tr');

            row.innerHTML = columns.map(column => `<td>${item[column] || ''}</td>`).join('');

            const actionsCell = document.createElement('td');

            if (deleteCallback) {
                const deleteButton = document.createElement('button');
                deleteButton.classList.add('delete-btn');
                deleteButton.innerHTML = '<img src="icons/delete.png" class="trash">';
                deleteButton.onclick = () => deleteCallback(item[idKey]);
                actionsCell.appendChild(deleteButton);
            }

            if (editPageUrl) {
                const editButton = document.createElement('button');
                editButton.classList.add('edit-btn');
                editButton.innerHTML = '<img src="icons/edit.png" class="trash">';
                editButton.onclick = () => {
                    window.location.href = `${editPageUrl}?${idKey}=${item[idKey]}`;
                };
                actionsCell.appendChild(editButton);
            }

            row.appendChild(actionsCell);
            tbody.appendChild(row);
        });
    } catch (error) {
        console.error('Ошибка:', error);
        alert('Не удалось загрузить данные: ' + error.message);
    }
}



// POST
async function postData(apiUrl, data) {
    try {
        const response = await fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) throw new Error(`Ошибка ${response.status}: ${response.statusText}`);

        window.history.back();
        return await response.json();
    } catch (error) {
        console.error('Ошибка при отправке данных:', error);
        alert('Не удалось отправить данные: ' + error.message);
        throw error;
    }
}

// PUT
async function putData(apiUrl, data) {
    try {
        const response = await fetch(apiUrl, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) throw new Error(`Ошибка ${response.status}: ${response.statusText}`);
        window.history.back();
        return await response.json();
    } catch (error) {
        console.error('Ошибка при обновлении данных:', error);
        throw error;
    }
}


// DELETE
async function deleteData(apiUrl) {
    try {
        const response = await fetch(apiUrl, { method: 'DELETE' });
        if (!response.ok) throw new Error(`Ошибка ${response.status}: ${response.statusText}`);
    } catch (error) {
        console.error('Ошибка удаления:', error);
        alert('Не удалось удалить запись: ' + error.message);
    }
}