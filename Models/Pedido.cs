using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MeninasArteiras.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }

        //
        //Chave estrangeira do Cliente
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }

        public string TemaDoEvento { get; set; }

        public DateTime DataDoEvento { get; set; }

        [DisplayName("Data de entrega:")]
        public DateTime DataDeEntrega { get; set; }

        //
        //Chave estrangeira de Forma de Pagamento
        public int FormaDePagamentoID { get; set; }
        public virtual FormaDePagamento FormaDePagamento { get; set; }

        [DisplayName("Está Pago?")]
        public bool EstaPago { get; set; }

        //
        //Chave estrangeira de Forma de Entrega
        public int FormaDeEntregaID { get; set; }
        public virtual FormaDeEntrega FormaDeEntrega { get; set; }

        [DisplayName("Foi Entregue?")]
        public bool FoiEntregue { get; set; }

        [DisplayName("Valor total do pedido:")]
        public decimal ValorTotal { get; set; }

        //
        //Chave estrangeira dos Itens do Pedido
        public virtual ICollection<ItemDoPedido> ItensDoPedido { get; set; }

        public void CalculaValorTotal()
        {
            foreach (var item in IDP)
            {
                this.ValorTotal += (item.QuantidadeDoItem * item.Produto.ValorUnitario);
            }
        }
    }
}