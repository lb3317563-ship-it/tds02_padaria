using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Cliente
    {
        private int id;
        private string nome;
        private string cpf;
        private string telefone;
        private string endereco;
        private int pontos;

        public Cliente(string nome, string cpf, string telefone, string endereco, int pontos)
        {

            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O nome do cliente não pode ser vazio");

            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Pontos = pontos;
        }

        public Cliente(int id, string nome, string cpf, string telefone, string endereco, int pontos)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Pontos = pontos;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public int Pontos { get => pontos; set => pontos = value; }

        public void AdicionarPontos(int pontos)
        {
            this.Pontos += pontos;
        }


        public static int Inserir(Cliente cliente)
        {
            // Introdução SQL: Define o comando de inserção (INSERT).
            // O uso de marcações com '@' (ex: @Nome) é uma prática de segurança crucial chamada de "parametrização".
            // Ela impede ataques de SQL Injection, pois o banco entende o que é comando e o que é apenas texto do usuário

            string sql = "INSERT INTO `Cliente`(`Nome`, `CPF`, `Telefone`, `Endereco`, `Pontos`) VALUES (@Nome, @CPF, @Telefone, @Endereco, @Pontos)";


            // Gerenciamento de recursos: Cria o objeto de comando já passando a instrução SQL.
            // O 'Using' garante que os recursos de memória ocupados pelo comando sejam liberados ao final do bloco
            using (var cmd = new MySqlCommand(sql))
            {
                // Vinculação de Dados: Pega as propriedades do objeto C# (cliente.Nome, cliente.cpf, etc.)
                // e substitui de forma segura as marcações '@' da string SQL com os valores reais.
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Pontos", cliente.Pontos);


                // Execução: Como o comando de INSERT não retorna tabelas (apenas executa uma ação),
                // ele envia o comando configurado para o método genérico 'executarComando' da classe 'Banco'.
                // O método retorna 1 (se o usuario for inserido com sucesso) ou -1 (se houver erro no banco).
                return Banco.executarComando(cmd);

            }

        }






    }
}
