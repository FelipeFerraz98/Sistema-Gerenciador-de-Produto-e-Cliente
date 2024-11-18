using System;
using Npgsql;

namespace GerenciadorProdutoECliente.Data
{
    public class DBConnection
    {
        // Método para abrir a conexão com o banco de dados PostgreSQL
        public static NpgsqlConnection OpenConnection()
        {
            // Parâmetros de conexão com o banco de dados PostgreSQL
            string host = "localhost"; // Host onde o PostgreSQL está rodando
            string porta = "5432";     // Porta padrão do PostgreSQL
            string usuario = "postgres";   // Usuário do banco
            string senha = "root";         // Senha do banco
            string database = "Empresa"; // Nome do banco de dados

            // String de conexão
            string connString = $"Host={host};Port={porta};Username={usuario};Password={senha};Database={database}";

            try
            {
                // Criar e retornar a instância da conexão com o banco de dados
                NpgsqlConnection conn = new NpgsqlConnection(connString);
                Console.WriteLine("Conexão com o banco de dados foi aberta.");
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                // Em caso de erro, imprime a mensagem e retorna null
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
                return null;  // Retorna null caso haja falha na conexão
            }
        }

        // Método para garantir que a conexão seja sempre fechada após a execução
        public static void CloseConnection(NpgsqlConnection conn)
        {
            if (conn != null)
            {
                conn.Close();
                Console.WriteLine("Conexão com o banco de dados foi fechada.");
            }
        }
    }
}