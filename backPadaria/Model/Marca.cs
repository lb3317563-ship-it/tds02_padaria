using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Marca
    {
        private int Id;
        private string Nome;
        private string Telefone;
        private object nome;
        private object telefone;

        public int Id1 { get => Id; set => Id = value; }
        public string Nome1 { get => Nome; set => Nome = value; }
        public string Telefone1 { get => Telefone; set => Telefone = value; }



        public Marca(int Id, string nome, string telefone)
        {
            this.Id = Id;
            this.Nome = nome;
            this.Telefone = telefone;
        }




        public Marca(string nome, string telefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("O nome da marca não pode ser vazio");

            this.Nome = nome;
            this.Telefone = telefone;
        }


        public Marca(object nome, object telefone)
        {
            this.nome = nome;
            this.telefone = telefone;
        }


        public static int Inserir(Marca marca)
        {
                     string sql = "INSERT INTO `Marca`(`Nome`, `Telefone`) VALUES (@Nome, @Telefone)";

          
            using (var cmd = new MySqlCommand(sql))
            {
              
                cmd.Parameters.AddWithValue("@Nome", marca.Nome);
                cmd.Parameters.AddWithValue("@Telefone", marca.Telefone);


                return Banco.executarComando(cmd);

            }

        }




        public static int Deletar(Marca marca)
        {
            string sql = "DELETE FROM `Marca` WHERE `ID` = @id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", marca.Id);

                return Banco.executarComando(cmd);


            }



        }




        public static List<Marca> ListarTodos()
        {
            string sql = "SELECT * FROM `Marca`";

            List<Marca> listaMarcas = new List<Marca>();

            using (var cmd = new MySqlCommand(sql))
            {

                using (MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd))
                {

                    while (reader.Read())
                    {

                        int id = reader.GetInt32("Id");
                        string nome = validarCampo(reader["Nome"]);
                        string telefone = validarCampo(reader["Telefone"]);




                        Marca marca = new Marca(id, nome, telefone);


                        listaMarcas.Add(marca);
                    }

                }
                return listaMarcas;

            }
        }




        public static Marca? listarPorId(int id)
        {
            string sql = "SELECT * FROM `Marca` WHERE `id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd);

                Marca? marca = null;

                while (reader.Read())
                {

                    int idBanco = reader.GetInt32("Id");
                    string nome = validarCampo(reader["Nome"]);
                    string telefone = validarCampo(reader["Telefone"]);


                    // Cria o objeto Cliente com os dados extraídos
                    marca = new Marca(idBanco, nome, telefone);


                }

                return marca;

            }

        }





        public static int Atualizar(Marca marca)
        {
            string sql = "UPDATE `Marca` SET `Nome` = @Nome, `Telefone` = @Telefone WHERE `Id` = @Id";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", marca.Nome);
                cmd.Parameters.AddWithValue("@Telefone", marca.Telefone);

                cmd.Parameters.AddWithValue("@Id", marca.Id);

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
