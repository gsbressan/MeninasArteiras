using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeninasArteiras.Models
{
    public class ItemDoPedido
    {
        public int ItemDoPedidoID { get; set; }
        public int QuantidadeDoItem { get; set; }
        public decimal ValorTotalDoItem { get; set; }

        //
        //Chave estrangeira do Produto
        public int ProdutoID { get; set; }
        public virtual Produto Produto { get; set; }

        //
        //Chave estrangeira do Pedido
        public int PedidoID { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}