document.getElementById('load-users').addEventListener('click', async function() {
    try {
        const response = await fetch('http://localhost:5000/api/users'); // Ajuste a URL conforme sua API
        const users = await response.json();
        const tableBody = document.getElementById('user-table').getElementsByTagName('tbody')[0];
        
        // Limpar a tabela antes de adicionar novos usuários
        tableBody.innerHTML = '';

        users.forEach(user => {
            const row = tableBody.insertRow();
            row.insertCell(0).innerText = user.Nome;
            row.insertCell(1).innerText = user.Idade;
            row.insertCell(2).innerText = user.Email;
            row.insertCell(3).innerText = user.Contato;
        });
    } catch (error) {
        console.error('Erro ao carregar usuários:', error);
    }
});
