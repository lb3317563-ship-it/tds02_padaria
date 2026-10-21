using backPadaria.Model;
using backPadaria.Service;
using backPadaria.Services;

namespace backPadaria
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Digite o nome do cliente: ");
            //string nomeCliente = Console.ReadLine();

            //Console.WriteLine("Digite o endereço do cliente:");
            //string enderecoCliente = Console.ReadLine();

            //Console.WriteLine("Digite o CPF do cliente");
            //string cpfCliente = Console.ReadLine();

            //Console.WriteLine("Digite o Telefone do cliente");
            //string telefoneCliente = Console.ReadLine();

            //Console.WriteLine("Digite os Pontos do cliente");
            //int pontosCliente = int.Parse(Console.ReadLine());








            ////REFATORAÇÃO ///
            //Cliente cliente1 = new Cliente
            //    (nome: nomeCliente, 
            //    cpf: cpfCliente, 
            //    telefone: telefoneCliente,
            //    endereco: enderecoCliente,
            //    pontos: pontosCliente

            //    );

            //Cliente.Inserir (cliente1 );

            //Cliente clienteParaDeletar = new Cliente(5);
            //if (Cliente.Deletar(clienteParaDeletar) >= 1)
            //{
            //    Console.WriteLine("Cliente excluído com sucesso. Graças a Deus.");
            //}
            //else
            //{
            //    Console.WriteLine("Deu bom não. Cliente presente!");
            //}

            //List<Cliente> clientes = Cliente.ListarTodos();

            //foreach (Cliente cliente in clientes) 
            //{
            //    Console.WriteLine("-------------------");
            //    Console.WriteLine($"ID: {cliente.Id}");
            //    Console.WriteLine($"Nome: {cliente.Nome}");
            //    Console.WriteLine($"CPF: {cliente.Cpf}");
            //    Console.WriteLine($"Telefone: {cliente.Telefone}");
            //    Console.WriteLine($"Endereço: {cliente.Endereco}");
            //    Console.WriteLine($"Pontos: {cliente.Pontos}");
            //    Console.WriteLine("--------------------");

            //}


            //Cliente? cli01 = Cliente.listarPorId(5);

            // if(cli01 != null)
            // {
            //     Console.WriteLine("=========================");

            //     Console.WriteLine($"ID {cli01.Id}");
            //     Console.WriteLine($"Nome {cli01.Nome}");
            //     Console.WriteLine($"CPF {cli01.Cpf}");
            //     Console.WriteLine($"Telefone {cli01.Telefone}");
            //     Console.WriteLine($"Endereço {cli01.Endereco}");
            //     Console.WriteLine($"Pontos {cli01.Pontos}");

            //     Console.WriteLine("=========================");

            // }
            // else
            // {
            //     Console.WriteLine("O cliente não foi encontrado!");
            // }





            //Cliente? meuCliente = Cliente.listarPorId(1);

            //if (meuCliente != null)
            //{
            //    Console.WriteLine(meuCliente.Cpf);

            //    meuCliente.Endereco = "Rua Luana, 171";
            //    meuCliente.Telefone = "1199999-1010";


            //    int resultado = Cliente.Atualizar(meuCliente);
            //    if (resultado > 0)
            //    {
            //        Console.WriteLine("Cliente Atualizado com sucesso!");
            //    }
            //}


            // Funcionario método inserir!!!!!!!!!!!!!!!!!
            //Funcionario funcionario1 = new Funcionario(nome: "Luana", cpf: "333999000", cargo: "Chefe");

            //Funcionario.Inserir(funcionario1);

            //Console.WriteLine(funcionario1);




            //// Funcionario método Deletar!!!!!!!!!!!!!!!!!!
            //Funcionario funcionarioParaDeletar = new Funcionario(8);
            //if(Funcionario.Deletar(funcionarioParaDeletar) >= 1)
            //{
            //    Console.WriteLine("Funcionário excluido!");
            //}
            //else
            //{
            //    Console.WriteLine("Deu errado!");
            //}




            //ClienteService.MenuCliente();



            // Funcionario método LISTAR POR ID!!!!!!!!!!!!!!!!!!!
            //Funcionario? funcionario = Funcionario.listarPorId(1);

            //if (funcionario != null)
            //{
            //    Console.WriteLine("=========================");

            //    Console.WriteLine($"ID: {funcionario.Id}");
            //    Console.WriteLine($"Nome: {funcionario.Nome}");
            //    Console.WriteLine($"CPF: {funcionario.Cpf}");
            //    Console.WriteLine($"Cargo: {funcionario.Cargo}");


            //    Console.WriteLine("=========================");

            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("O cliente não foi encontrado!");
            //    //}






            // Funcionario Método LISTAR TODOS !!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //List<Funcionario> funcionarios = Funcionario.ListarTodos();
            //foreach (Funcionario funcionario in funcionarios)
            //{
            //    Console.WriteLine("-------------------");
            //    Console.WriteLine($"ID: {funcionario.Id}");
            //    Console.WriteLine($"Nome: {funcionario.Nome}");
            //    Console.WriteLine($"CPF: {funcionario.Cpf}");
            //    Console.WriteLine($"Telefone: {funcionario.Cargo}");

            //    Console.WriteLine("--------------------");

            //}




            // FUNCIONARIO METODO ATUALIZAR!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //Funcionario? meuFuncionario = Funcionario.listarPorId(7);

            //if (meuFuncionario != null)
            //{
            //    meuFuncionario.Cargo = "porteiro";
            //    meuFuncionario.Nome = "Victor Samuel";

            //    int resultado = Funcionario.Atualizar(meuFuncionario);

            //    if (resultado > 0)
            //    {
            //        Console.WriteLine("Funcionario atualizado com sucesso.");
            //    }





            FuncionarioService.listarMenuFuncionario();







            }
      }
    }

