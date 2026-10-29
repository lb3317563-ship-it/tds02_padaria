using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Produto 
    {
        private int Id;
        private string Nome;
        private decimal Preco;
        private string Categoria;
        private bool Fabricado;
        private int MarcaId;
         

        public int Id1 { get => Id; set => Id = value; }
        public string Nome1 { get => Nome; set => Nome = value; }
        public decimal Preco1 { get => Preco; set => Preco = value; }
        public string Categoria1 { get => Categoria; set => Categoria = value; }
        public bool Fabricado1 { get => Fabricado; set => Fabricado = value; }
        public int MarcaId1 { get => MarcaId; set => MarcaId = value; }



        public Produto(int Id, string Nome, decimal Preco, string Categoria, bool Fabricado, int MarcaId)
            : this(Nome, Preco, Categoria, Fabricado, MarcaId)
        {
            if (Id <= 0) throw new Exception("O ID do produto é inválido"); 


            this.Id = Id;

        }





        public Produto(string nome, decimal preco, string categoria, bool fabricado, int marcaId)
        {

            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O nome do produto não pode ser vazio");
            if (preco < 0) throw new Exception("O preço do produto não pode ser negativo");
            if (string.IsNullOrWhiteSpace(categoria)) throw new Exception("A categoria não pode ser vazia");
            if (marcaId <= 0) throw new Exception("O ID da marca deve ser maior que 0");

            this.Nome = nome;
            this.Preco = preco;
            this.Categoria = categoria;
            this.Fabricado = fabricado;
            this.MarcaId = marcaId;
        }



        public static int Inserir(Produto produto)
        {
            string sql = "INSERT INTO `Produto`(`Nome`, `Preco`, `Categoria`, `Fabricado`, `MarcaId`) VALUES (@Nome, @Preco, @Categoria, @Fabricado, @MarcaId)";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco);
                cmd.Parameters.AddWithValue("@Categoria", produto.Categoria);
                cmd.Parameters.AddWithValue("@Fabricado", produto.Fabricado);
                cmd.Parameters.AddWithValue("@MarcaId", produto.MarcaId);


                return Banco.executarComando(cmd);

            }
        }



        public static int Deletar(Produto produto)
        {
            string sql = "DELETE FROM `Produto` WHERE `ID` = @id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", produto.Id1);

                return Banco.executarComando(cmd);

            }



        }



        public static List<Produto> ListarTodos()
        {
            string sql = "SELECT * FROM `Produto`";

            List<Produto> listaProdutos = new List<Produto>();

            using (var cmd = new MySqlCommand(sql))
            {

                using (MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd))
                {

                    while (reader.Read())
                    {

                        int id = reader.GetInt32("Id");
                        string nome = reader.GetString("Nome");
                        decimal preco = reader.GetDecimal("Preco");
                        string categoria = reader.GetString("Categoria");
                        bool fabricado = reader.GetBoolean("Fabricado");
                        int marcaId = reader.GetInt32("MarcaId");


                        Produto produto = new Produto(id, nome, preco, categoria, fabricado, marcaId);


                        listaProdutos.Add(produto);
                    }

                }
 
                return listaProdutos;

            }
        }



        public static Produto? listarPorId(int id)
        {
            string sql = "SELECT * FROM `Produto` WHERE `id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd);

                Produto? produto = null;

                while (reader.Read())
                {


                    int Id = reader.GetInt32("Id");
                    string nome = reader.GetString("Nome");
                    decimal preco = reader.GetDecimal("Preco");
                    string categoria = reader.GetString("Categoria");
                    bool fabricado = reader.GetBoolean("Fabricado");
                    int marcaId = reader.GetInt32("MarcaId");


                    // Cria o objeto Cliente com os dados extraídos
                    produto = new Produto(id, nome, preco, categoria, fabricado, marcaId);


                }

                return produto;

            }


        }




        public static int Atualizar(Produto produto)
        {
            string sql = "UPDATE `Produto` SET `Nome` = @Nome,  `Preco` = @Preco, `Categoria` = @Categoria, `Fabricado` = @Fabricado, `MarcaId` = @MarcaId WHERE `Id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", produto.Nome1);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco1);
                cmd.Parameters.AddWithValue("@Categoria", produto.Categoria1);
                cmd.Parameters.AddWithValue("@Fabricado", produto.Fabricado1);
                cmd.Parameters.AddWithValue("@MarcaId", produto.MarcaId1);


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

