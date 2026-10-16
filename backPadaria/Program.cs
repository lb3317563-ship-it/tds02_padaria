using backPadaria.Model;

namespace backPadaria
{
    internal class Program
    {
        static void Main(string[] args)
        {

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








            //REFATORAÇÃO ///
            Cliente cliente1 = new Cliente
                (nome: nomeCliente, 
                cpf: cpfCliente, 
                telefone: telefoneCliente,
                endereco: enderecoCliente,
                pontos: pontosCliente
                
                );

            Cliente.Inserir (cliente1 );









        }
    }
}
