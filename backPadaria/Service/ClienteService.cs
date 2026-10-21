using backPadaria.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace backPadaria.Services
{
    public static class ClienteService
    {
        public static void MenuCliente()
        {

            bool sair = false;

            while (!sair)
            {

                Console.WriteLine("===== GESTÃO DE CLIENTES =====");

                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Listar todos os clientes");
                Console.WriteLine("3 - Buscar Cliente por ID");
                Console.WriteLine("4 - Atualizar Cliente");
                Console.WriteLine("5 - Excluir Cliente");
                Console.WriteLine("6 - Visualizar Pontuação");
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
                            Console.WriteLine("----- CADASTRAR CLIENTE -----");

                            Console.WriteLine("Digite o nome do cliente: ");
                            string nomeCliente = Console.ReadLine();

                            Console.WriteLine("Digite o endereço do cliente:");
                            string enderecoCliente = Console.ReadLine();

                            Console.WriteLine("Digite o CPF do cliente");
                            string cpfCliente = Console.ReadLine();

                            Console.WriteLine("Digite o Telefone do cliente");
                            string telefoneCliente = Console.ReadLine();

                            Console.WriteLine("Digite os Pontos do cliente");
                            int pontosCliente = int.Parse(Console.ReadLine());

                            Cliente NovoCliente = new Cliente(
                            nome: nomeCliente,
                            cpf: cpfCliente,
                            telefone: telefoneCliente,
                            endereco: enderecoCliente,
                            pontos: pontosCliente);


                            int resultadoInsert = Cliente.Inserir(NovoCliente);
                            if(resultadoInsert > 0)
                            {
                                Console.WriteLine("Cliente cadastrado com sucesso!");
                            }


                        break;

                            case "2":

                             listarClientesMenu();

                            break;

                            case "3":
                            listarPorIdMenu();

                            break;

                            case "4":
                            atualizarClientesMenu();


                            break;
                    }

                }
                catch(Exception ex) 
                {
                    Console.WriteLine($"\n[ERRO DE VALIDAÇÃO]: {ex.Message}");
                }

            }

        }



        private static void listarClientesMenu()
        {
            Console.WriteLine("------ LISTA DE CLIENTES ------");

            List<Cliente> lista = Cliente.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado no sistema");
            }
            else
            {
                foreach (var cliente in lista)
                {
                    Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | Pontos: {cliente.Pontos} | CPF: {cliente.Cpf}" );
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

            Cliente cli = Cliente.listarPorId(idCli);

            Console.WriteLine($"ID: {cli.Id} | Nome: {cli.Nome} | CPF: {cli.Cpf} | Telefone: {cli.Telefone} | Endereço: {cli.Endereco} | Pontos: {cli.Pontos}\n\n\n\n\n");

            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            
        }




        private static void atualizarClientesMenu()
        {
            Console.WriteLine("------ ATUALIZAR CLIENTE POR ID ------");

            Console.WriteLine("Digite o ID do cliente para atualizar: ");

            int idCli = 0;

            int.TryParse(Console.ReadLine(), out idCli);

            Cliente? clienteAtualizar = Cliente.listarPorId(idCli);

            if (clienteAtualizar != null) {

                Console.WriteLine("--- Informações atuais ----");
                Console.WriteLine($"ID: {clienteAtualizar.Id} | Nome: {clienteAtualizar.Nome} | CPF: {clienteAtualizar.Cpf} | Telefone: {clienteAtualizar.Telefone} | Endereço: {clienteAtualizar.Endereco} | Pontos: {clienteAtualizar.Pontos}");


                Console.WriteLine("Caso não deseje alterar o dado, pressione o enter");

                Console.WriteLine("Digite o novo nome do cliente: ");
                string nomeCliente = Console.ReadLine();

                Console.WriteLine("Digite o novo telefone: ");
                string telefoneCliente = Console.ReadLine();


                Console.WriteLine("Digite o novo endereço: ");
                string enderecoCliente = Console.ReadLine();


                Console.WriteLine("Digite a nova pontuação: ");
                int pontosCliente;

                int.TryParse(Console.ReadLine(), out pontosCliente);


                if (!string.IsNullOrEmpty(nomeCliente)) clienteAtualizar.Nome = nomeCliente;
                if (!string.IsNullOrEmpty(telefoneCliente)) clienteAtualizar.Nome = telefoneCliente;
                if (!string.IsNullOrEmpty(enderecoCliente)) clienteAtualizar.Nome = enderecoCliente;
                //if (!int.(pontosCliente)) clienteAtualizar.Nome = pontosCliente;
                



                Cliente.Atualizar(clienteAtualizar);

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
