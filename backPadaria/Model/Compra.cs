using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Compra
    {
        private int id;
        private DateTime dataHora;
        private int funcionarioId;
        private int clienteId;

        private List<ItemCompra> itens = new List<ItemCompra>();

        public int Id { get => id; set => id = value; }
        public DateTime DataHora { get => dataHora; set => dataHora = value; }
        public int FuncionarioId { get => funcionarioId; set => funcionarioId = value; }
        public int ClienteId { get => clienteId; set => clienteId = value; }
        internal List<ItemCompra> Itens { get => itens; set => itens = value; }

        public Compra(DateTime dataHora, int funcionarioId, int clienteId)
        {
            if (funcionarioId <= 0) throw new ArgumentOutOfRangeException("O funcionário responsável é inválido");

            this.DataHora = dataHora;
            this.FuncionarioId = funcionarioId;
            this.ClienteId = clienteId;
        }


        public Compra(int id, DateTime dataHora, int funcionarioId, int clienteId)
            :this(dataHora, funcionarioId, clienteId)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException("Id da compra inválido");
            this.Id = id;

           
        }


        public decimal CalcularTotal()
        {


            return Itens.Sum(item=> item.CalcularSubtotal());
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            if (produto == null) throw new Exception("Produto inexistente");

            ItemCompra novoItem = new ItemCompra(produto.Id1, quantidade, produto.Preco1);
            this.Itens.Add(novoItem);
        }


        public void RemoverItem(ItemCompra item)
        {
            this.Itens.Remove(item);
        }


        public static int Inserir(Compra compra)
        {
            using (var cmd = new MySqlCommand("sp_inserirCompra"))
            {
                cmd.Parameters.AddWithValue("p_DataHora", compra.DataHora);
                cmd.Parameters.AddWithValue("p_FuncionarioId", compra.FuncionarioId); 
                cmd.Parameters.AddWithValue("p_ClienteId", compra.ClienteId);

                object resultado = Banco.executarComandoComRetornoId(cmd);

                if(resultado != null && int.TryParse(resultado.ToString(), out int idGerado))
                {
                   compra.Id = idGerado;
                    return idGerado;
                } 

                return -1;

            }
        }




    }
}
