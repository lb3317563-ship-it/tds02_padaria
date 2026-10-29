using backPadaria.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Service
{
    public static class MarcaService
    {
        public static void MenuMarca()
        {

            bool sair = false;

            while (!sair)
            {

                Console.WriteLine("===== GESTÃO DE MARCAS =====");

                Console.WriteLine("1 - Cadastrar Marca");
                Console.WriteLine("2 - Listar todas as marcas");
                Console.WriteLine("3 - Buscar Marca por ID");
                Console.WriteLine("4 - Atualizar Marca");
                Console.WriteLine("5 - Excluir Marca");
                Console.WriteLine("0 - Sair do Programa");

                Console.WriteLine("=============================\n");
                Console.WriteLine("Digite uma opção");

                string opcao = Console.ReadLine();

                Console.Clear();


                try
                {
                    switch (opcao)
                    {
                        case "1": // Cadastrar
                            Console.WriteLine("----- CADASTRAR MARCA -----");

                            Console.WriteLine("Digite o nome da marca: ");
                            string nomeMarca = Console.ReadLine();

                            Console.WriteLine("Digite o Telefone do cliente");
                            string telefoneMarca = Console.ReadLine();


                            Marca NovaMarca = new Marca(
                            nome: nomeMarca,
                            telefone: telefoneMarca
                            );


                            int resultadoInsert = Marca.Inserir(NovaMarca);
                            if (resultadoInsert > 0)
                            {
                                Console.WriteLine("Marca cadastrada com sucesso!");
                            }
                        break;
                        case "2":

                            listarMarcasMenu();

                        break;
                        case "3":

                            listarPorIdMenu();

                        break;
                        case "4":

                            atualizarMarcaMenu();

                        break;
                        case "5":

                            excluirMarca();

                        break;
                        case "0":

                            return;

                        break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ERRO DE VALIDAÇÃO]: {ex.Message}");
                }

            }

        }



        private static void listarMarcasMenu()
        {
            Console.WriteLine("------ LISTA DE MARCAS ------");

            List<Marca> lista = Marca.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma marca cadastrada no sistema");
            }
            else
            {
                foreach (var marca in lista)
                {
                    Console.WriteLine($"ID: {marca.Id1} | Nome: {marca.Nome1} | Telefone: {marca.Telefone1} ");
                }
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }




        private static void listarPorIdMenu()
        {
            Console.WriteLine("------ LISTA POR ID ------");

            Console.WriteLine("Digite o ID desejado: ");


            int idMarca = 0;


            int.TryParse(Console.ReadLine(), out idMarca);

            Marca marca = Marca.listarPorId(idMarca);

            Console.WriteLine($"ID: {marca.Id1} | Nome: {marca.Nome1} | Telefone: {marca.Telefone1}\n");

            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }




        private static void atualizarMarcaMenu()
        {
            Console.WriteLine("------ ATUALIZAR MARCA POR ID ------");

            Console.WriteLine("Digite o ID da marca para atualizar: ");

            int idMarca = 0;

            int.TryParse(Console.ReadLine(), out idMarca);

            Marca? marcaAtualizar = Marca.listarPorId(idMarca);

            if (marcaAtualizar != null)
            {

                Console.WriteLine("--- Informações atuais ----");
                Console.WriteLine($"ID: {marcaAtualizar.Id1} | Nome: {marcaAtualizar.Nome1} | Telefone: {marcaAtualizar.Telefone1} ");


                Console.WriteLine("Caso não deseje alterar o dado, pressione o enter");

                Console.WriteLine("Digite o novo nome da marca: ");
                string nomeMarca = Console.ReadLine();

                Console.WriteLine("Digite o novo telefone: ");
                string telefoneMarca = Console.ReadLine();


               

                if (!string.IsNullOrEmpty(nomeMarca)) marcaAtualizar.Nome1 = nomeMarca;
                if (!string.IsNullOrEmpty(telefoneMarca)) marcaAtualizar.Telefone1 = telefoneMarca;
                //if (!int.(pontosCliente)) clienteAtualizar.Nome = pontosCliente;


                Marca.Atualizar(marcaAtualizar);

            }
        }




        public static int excluirMarca()
        {

            Console.WriteLine("------ EXCLUIR MARCA ------");

            Console.WriteLine("Digite o ID para excluir: ");

            int idMarca = 0;

            int.TryParse(Console.ReadLine(), out idMarca);

            Marca? funcionarioAtualizar = Marca.listarPorId(idMarca);
            Console.WriteLine("Marca excluída com sucesso!\n");


            string sql = "DELETE FROM `Marca` WHERE `ID` = @id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", idMarca);

                return Banco.executarComando(cmd);

                Console.WriteLine("Marca excluído com sucesso!\n");

            }




        }




    }
}
