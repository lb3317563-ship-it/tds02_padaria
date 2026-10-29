using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Funcionario
    {

        private int id;
        private string nome;
        private string cpf;
        private string cargo;


        public Funcionario(string nome, string cpf, string cargo)
        {

            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O nome do funcionário não pode ser vazio");

            this.Nome = nome;
            this.Cpf = cpf;
            this.Cargo = cargo;
            
       
        }


        public Funcionario(int id, string nome, string cpf, string cargo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Cargo = cargo;
        }


        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Cargo { get => cargo; set => cargo = value; }




        public Funcionario(int id)
        {
            this.Id = id;
        }

       



        public static int Inserir(Funcionario funcionario)
        {
            string sql = "INSERT INTO `Funcionario`(`Nome`, `CPF`, `Cargo`) VALUES (@Nome, @CPF, @Cargo)";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@CPF", funcionario.Cpf);
                cmd.Parameters.AddWithValue("@Cargo", funcionario.Cargo);

                return Banco.executarComando(cmd);

            }
        }





        public static int Deletar(Funcionario funcionario)
        {
            string sql = "DELETE FROM `Funcionario` WHERE `ID` = @id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", funcionario.id);

                return Banco.executarComando(cmd);

            }



        }




        public static List<Funcionario> ListarTodos()
        {
            string sql = "SELECT * FROM `Funcionario`";

            List<Funcionario> listaFuncionarios = new List<Funcionario>();

            using (var cmd = new MySqlCommand(sql))
            {

                // Executa a leitura. 0 bloco 'using' aqui é FUNDAMENTAL para garantir que o
                // reader seja fechado no final, o que por sua vez fecha a conexão com o banco.
                using (MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd))
                {

                    // O while vai rodar uma vez para CADA linha que existir na tabela Cliente
                    while (reader.Read())
                    {

                        int id = reader.GetInt32("Id");
                        string nome = validarCampo(reader["Nome"]);
                        string cpf = validarCampo(reader["CPF"]);
                        string cargo = validarCampo(reader["Cargo"]);
                     




                        // Cria o objeto Cliente com os dados extraídos
                        Funcionario funcionario = new Funcionario(id, nome, cpf, cargo);


                        // Adiciona este cliente à nossa lista
                        listaFuncionarios.Add(funcionario);
                    }

                }
                // Retorna a lista completa (se a tabela estiver vazia, retorna uma lista com 0 itens)
                return listaFuncionarios;

            }
        }





        public static Funcionario? listarPorId(int id)
        {
            string sql = "SELECT * FROM `Funcionario` WHERE `id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd);

                Funcionario? funcionario = null;

                while (reader.Read())
                {

              
                    string nome = validarCampo(reader["Nome"]);
                    string cpf = validarCampo(reader["CPF"]);
                    string cargo = validarCampo(reader["Cargo"]);
                    

                    // Cria o objeto Cliente com os dados extraídos
                    funcionario = new Funcionario(id,  nome, cpf, cargo);


                }

                return funcionario;

            }


        }




        public static int Atualizar(Funcionario funcionario)
        {
            string sql = "UPDATE `Funcionario` SET `Nome` = @Nome,  `Cargo` = @Cargo WHERE `Id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
               
                cmd.Parameters.AddWithValue("@Cargo", funcionario.Cargo);


                cmd.Parameters.AddWithValue("@Id", funcionario.id);

                return Banco.executarComando(cmd);
            }
        }














        private static string validarCampo(object campo)
        {
            if (campo == DBNull.Value || campo == null)
            {
                return "";
            }
            else
            {
                return campo.ToString();
            }

        }
    }
}
