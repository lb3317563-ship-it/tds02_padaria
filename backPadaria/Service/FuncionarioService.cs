using backPadaria.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Service
{
    internal class FuncionarioService
    {
        public static void listarMenuFuncionario()
        {
            bool sair = false;

            while (!sair)
            {

                Console.WriteLine("===== GESTÃO DE FUNCIONÁRIOS =====");

                Console.WriteLine("1 - Cadastrar Funcionários");
                Console.WriteLine("2 - Listar todos os funcuonários");
                Console.WriteLine("3 - Buscar Funcionário por ID");
                Console.WriteLine("4 - Atualizar Funcionário");
                Console.WriteLine("5 - Excluir Funcionário");
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
                            Console.WriteLine("----- CADASTRAR FUNCIONÁRIO -----");

                            Console.WriteLine("Digite o nome do funcionário: ");
                            string nomeFuncionario = Console.ReadLine();

                            Console.WriteLine("Digite o CPF do funcionário:");
                            string cpfFuncionario = Console.ReadLine();

                            Console.WriteLine("Digite o Cargo do funcionário");
                            string cargoFuncionario = Console.ReadLine();

                            Funcionario NovoFuncionario = new Funcionario(
                            nome: nomeFuncionario,
                            cpf: cpfFuncionario,
                            cargo: cargoFuncionario);
                            


                            int resultadoInsert = Funcionario.Inserir(NovoFuncionario);
                            if (resultadoInsert > 0)
                            {
                                Console.WriteLine("Funcionário cadastrado com sucesso!");
                            }


                            break;

                        case "2":

                            listarFuncionariosMenu();

                            break;

                        case "3":

                            listarPorIdMenu();

                            break;

                        case "4":


                            atualizarFuncionariosMenu();


                            break;
                            case "5":

                            excluirFuncionario();

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



        private static void listarFuncionariosMenu()
        {
            Console.WriteLine("------ LISTA DE FUNCIONÁRIOS ------");

            List<Funcionario> funcionarios = Funcionario.ListarTodos();

            if (funcionarios.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado no sistema");
            }
            else
            {
                foreach (var funcionario in funcionarios)
                {
                    Console.WriteLine($"ID: {funcionario.Id} | Nome: {funcionario.Nome} | CPF: {funcionario.Cpf}");
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


            int idCli = 0;


            int.TryParse(Console.ReadLine(), out idCli);

            Funcionario cli = Funcionario.listarPorId(idCli);

            Console.WriteLine($"ID: {cli.Id} | Nome: {cli.Nome} | CPF: {cli.Cpf} | Cargo: {cli.Cargo}\n");

            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }



        private static void atualizarFuncionariosMenu()
        {
            Console.WriteLine("------ ATUALIZAR FUNCIONÁRIO POR ID ------");

            Console.WriteLine("Digite o ID do funcionário para atualizar: ");

            int idFun = 0;

            int.TryParse(Console.ReadLine(), out idFun);

            Funcionario? funcionarioAtualizar = Funcionario.listarPorId(idFun);

            if (funcionarioAtualizar != null)
            {

                Console.WriteLine("--- Informações atuais ----");
                Console.WriteLine($"ID: {funcionarioAtualizar.Id} | Nome: {funcionarioAtualizar.Nome} | CPF: {funcionarioAtualizar.Cpf} | Cargo: {funcionarioAtualizar.Cargo}");


                Console.WriteLine("Caso não deseje alterar o dado, pressione o enter");

                Console.WriteLine("Digite o novo nome do funcionário: ");
                string nomeFuncionario = Console.ReadLine();

                Console.WriteLine("Digite o novo cargo do funcionário: ");
                string cargoFuncionario = Console.ReadLine();


                
                if (!string.IsNullOrEmpty(nomeFuncionario)) funcionarioAtualizar.Nome = nomeFuncionario;
                if (!string.IsNullOrEmpty(cargoFuncionario)) funcionarioAtualizar.Nome = cargoFuncionario;
               
                //if (!int.(pontosCliente)) clienteAtualizar.Nome = pontosCliente;

                Funcionario.Atualizar(funcionarioAtualizar);

                Console.WriteLine("Atualização concluída...\n");

            }


        }



        public static int excluirFuncionario()
        {

            Console.WriteLine("------ EXCLUIR FUNCIONÁRIO ------");

            Console.WriteLine("Digite o ID para excluir: ");

            int idFun = 0;

            int.TryParse(Console.ReadLine(), out idFun);

            Funcionario? funcionarioAtualizar = Funcionario.listarPorId(idFun);
            Console.WriteLine("Funcionário excluído com sucesso!\n");


            string sql = "DELETE FROM `Funcionario` WHERE `ID` = @id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", idFun);

                return Banco.executarComando(cmd);

                Console.WriteLine("Funcionário excluído com sucesso!\n");

            }

            


        }





    }
}

