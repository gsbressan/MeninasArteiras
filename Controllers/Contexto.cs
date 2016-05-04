using MeninasArteiras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeninasArteiras.Controllers
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemDoPedido> ItensDoPedido { get; set; }
        public DbSet<FormaDeEntrega> FormasDeEntrega { get; set; }
        public DbSet<FormaDePagamento> FormasDePagamento { get; set; }
    }
}