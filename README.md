**Projeto Backend em C#**

**Descrição:**
Este projeto é uma aplicação backend em C# que interage com um banco de dados PostgreSQL e consome dados da API Random User Generator. Ele permite realizar operações CRUD (criar, ler, atualizar e excluir) em dados de usuários, com uma interface web simples em JavaScript para exibição e edição dos dados.

**Funcionalidades Principais:**

Integração com a API Random User Generator para obter dados fictícios de usuários.
Operações CRUD (criar, ler, atualizar e excluir) no banco de dados PostgreSQL.
Interface Frontend em JavaScript para exibir e editar os dados dos usuários.

**Tecnologias Utilizadas:**

**C#**: Linguagem principal do backend.
**Dapper**: Micro ORM para consultas SQL e manipulação de dados.
**PostgreSQL**: Banco de dados utilizado para armazenar os dados dos usuários.
**JavaScript**: Linguagem usada no front-end para interação com o backend.
**Random User Generator API**: API externa para obter dados de usuários fictícios.
**JSON**: Usado para configurar a string de conexão com o banco de dados.

**Estrutura do Projeto:**

**│                                                                                                                                                                                                                          
├──Program.cs                                                                                                                                                                                                                
│                                                                                                                                                                                                                            
├──Usuario.cs                                                                                                                                                                                                                
│                                                                                                                                                                                                                            
├──ConfigApp.json                                                                                                                                                                                                            
│                                                                                                                                                                                                                            
├──Frontend/                                                                                                                                                                                                                 
│    ├── index.html                                                                                                                                                                                                          
│     ├──app.js                                                                                                                                                                                                              
└── sql/                                                                                                                                                                                                                     
     └── init.sql**                                                                                                                                                                                                          

**1. Program.cs**
O arquivo principal do backend. Ele realiza as seguintes funções:

Leitura da Configuração: Carrega informações do arquivo ConfigApp.json para obter a string de conexão com o PostgreSQL.
Conexão com o Banco de Dados: Utiliza o Dapper para realizar operações CRUD.
Consumo da API Random User Generator: Obtém dados de usuários fictícios da API e insere no banco de dados.

**Exemplo de configuração de conexão com o banco de dados:**

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("ConfigApp.json", optional: false)
    .Build();

using (IDbConnection dbConnection = new NpgsqlConnection(connectionString))
{
    // Operações no banco de dados
}

**2. ConfigApp.json**
Arquivo de configuração que contém a string de conexão com o banco de dados. Exemplo de estrutura:

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=bdLocal;Username=postgres;Password=senha"
  }
}

**3. Banco de Dados PostgreSQL**
O projeto utiliza PostgreSQL para armazenar os dados de usuários. A tabela principal é users, e pode ser criada com o seguinte script:

CREATE TABLE users (
  id SERIAL PRIMARY KEY,
  nome VARCHAR(100),
  email VARCHAR(100),
  contato VARCHAR(15)
);

**4. Frontend (app.js)**
O frontend permite a exibição e edição de dados de usuários. As principais funcionalidades incluem:

Exibir Dados: Exibe os usuários em uma tabela ou lista.
Editar Dados: Permite editar informações de usuários.
Excluir Usuários: Remove um usuário via requisição HTTP ao backend.


**Passos para Execução
**
**1. Clonar o Repositório**

git clone https://github.com/PedroOliveira-dev/PEDRO-HENRIQUE-SALES-DE-OLIVEIRA.git
cd PEDRO-HENRIQUE-SALES-DE-OLIVEIRA.git

**2. Configurar a String de Conexão**
Edite o arquivo ConfigApp.json com suas credenciais do PostgreSQL.

**3. Executar a Aplicação**
No terminal, execute o comando:

dotnet run

**4. Frontend**
O frontend está disponível no diretório Frontend. Abra o arquivo index.html em um navegador para interagir com os dados.

**Considerações Finais**
Este projeto é uma aplicação simples de CRUD com foco no uso de boas práticas de desenvolvimento backend em C#. Ele pode ser expandido para incluir novas funcionalidades conforme necessário.
