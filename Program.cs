using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Dapper;
using Npgsql;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ProjetoPedro
{
    class Program
    {
        static async Task Main(string[] args) // O método Main deve ser estático
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfigApp.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            // Consome a API Random User Generator
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://randomuser.me/api/");
            var json = JObject.Parse(response);

            // Extrai dados do usuário
            var usuario = new Usuario
            {
                Nome = json["results"][0]["name"]["first"]?.ToString() ?? "Nome não disponível",
                Idade = json["results"][0]["dob"]["age"]?.ToString() ?? "Idade não disponível",
                Email = json["results"][0]["email"]?.ToString() ?? "Email não disponível",
                Contato = json["results"][0]["phone"]?.ToString() ?? "Contato não disponível"
            };

            // Insere o usuário no banco de dados
            var sql = "INSERT INTO Users (Nome, Idade, Email, Contato) VALUES (@Nome, @Idade, @Email, @Contato)";
            await connection.ExecuteAsync(sql, usuario);

            Console.WriteLine("Usuário inserido com sucesso!");

            // Relatório de Usuários: Lista todos os usuários armazenados
            await ListarUsuarios(connection);
        }

        private static async Task ListarUsuarios(NpgsqlConnection connection)
        {
            var sql = "SELECT Nome, Idade, Email, Contato FROM Users";
            var usuarios = await connection.QueryAsync<Usuario>(sql);

            Console.WriteLine("Usuários armazenados:");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Nome: {usuario.Nome}, Idade: {usuario.Idade}, Email: {usuario.Email}, Contato: {usuario.Contato}");
            }
        }
    }
}
