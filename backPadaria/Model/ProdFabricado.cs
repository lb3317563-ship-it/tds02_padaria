using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class ProdFabricado
    {
        private int ProdutoId;
        private string DescricaoProducao;

        public int ProdutoId1 { get => ProdutoId; set => ProdutoId = value; }
        public string DescricaoProducao1 { get => DescricaoProducao; set => DescricaoProducao = value; }



        public ProdFabricado(int id, string DescricaoProducao)
        {
            this.ProdutoId = ProdutoId;
            this.DescricaoProducao = DescricaoProducao;
        }



        public static int Inserir(ProdFabricado prod)
        {
            string sql = "INSERT INTO `ProdFabricado`(`ProdutoId`, `DescricaoProducao`) VALUES (@ProdutoId1, @DescricaoProducao1)";


            using (var cmd = new MySqlCommand(sql))
            {

                cmd.Parameters.AddWithValue("@Nome", prod.DescricaoProducao);
                cmd.Parameters.AddWithValue("@Telefone", prod.ProdutoId1);


                return Banco.executarComando(cmd);

            }

        }



        public static int Deletar(ProdFabricado prod)
        {
            string sql = "DELETE FROM `ProdFabricado` WHERE `ID` = @ProdutoId";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", prod.ProdutoId1);

                return Banco.executarComando(cmd);


            }



        }




        public static List<ProdFabricado> ListarTodos()
        {
            string sql = "SELECT * FROM `ProdFabricado`";

            List<ProdFabricado> listaProdFabricados = new List<ProdFabricado>();

            using (var cmd = new MySqlCommand(sql))
            {

                using (MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd))
                {

                    while (reader.Read())
                    {

                        int id = reader.GetInt32("ProdutoId");
                        string descricaoProd = validarCampo(reader["Descrição"]);




                        // Cria o objeto Cliente com os dados extraídos
                        ProdFabricado produto = new ProdFabricado(id, descricaoProd);


                        // Adiciona este cliente à nossa lista
                        listaProdFabricados.Add(produto);
                    }

                }
                // Retorna a lista completa (se a tabela estiver vazia, retorna uma lista com 0 itens)
                return listaProdFabricados;

            }
        }



        public static ProdFabricado? listarPorId(int id)
        {
            string sql = "SELECT * FROM `ProdFabricado` WHERE `id` = @ProdutoId";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@ProdutoId", id);

                MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd);

                ProdFabricado? produto = null;

                while (reader.Read())
                {


                    int Id = reader.GetInt32("ProdutoId");
                    string descricaoProd = validarCampo(reader["Descrição"]);


                    // Cria o objeto Cliente com os dados extraídos
                    produto = new ProdFabricado(id, descricaoProd);


                }

                return produto;

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
