using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace backPadaria
{
    public static class Banco
    {
        private static string stringDeConexao = "Server=10.91.45.56;Port=3306;Database=padaria_bd;Uid=admin;Pwd=12345678";


        public static void conectAndTest() 
        {
            using (var connection = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    Console.WriteLine("Tentando conectar ao banco de dados.");
                    connection.Open();

                    Console.WriteLine("Conexão bem sucedida");

                    using (var command = new MySqlCommand("SELECT VERSION();", connection))
                    {
                        string version = command.ExecuteScalar()?.ToString();
                        Console.WriteLine($"Versão do MariaDB {version}");
                    }

                }
                catch (MySqlException ex)
                { 
                    Console.WriteLine("Erro ao conectar o banco de dados.");
                    Console.WriteLine(ex.Message);
                }


                

            }
        }


        //Declaração do método: público e estatico, retorna um número inteiro(linhas afetadas)
        // e recebe um objeto MySqlCommand com a instrução SQL já configurada como parâmetro.
        public static int executarComando(MySqlCommand command)
        {

            /*O bloco 'using' garante que a conexão será automaticamente fechada e liberada
             * da memória ao final do bloco, mesmo que ocorram erros no meio do processo.
             * 
             * cria a conexão utilizando a variavel de ambiente
             */
            using (var conexao = new MySqlConnection(stringDeConexao))
            {
                //Vinculação: Diz ao comando SQL em qual conexão ele deve ser executado.
                command.Connection = conexao;

                try
                {

                    conexao.Open();

                    // Execução: executeNonQuery dispara comandos de ação (INSERT, UPDATE, DELETE)
                    // Ele não retorna registros, mas sim o número inteiro de linhas que foram alteradas,
                    // e o 'return' devolve esse número para quem chamou o método.
                    return command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Erro de Banco de dados{ex.Message}");

                    return -1;

                }

            }

        }






    }
}
