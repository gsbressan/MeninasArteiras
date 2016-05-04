﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeninasArteiras.Models
{
    public class FormaDePagamento
    {
        public int FormaDePagamentoID { get; set; }
        public string Nome { get; set; }

        //
        //Chave estrangeira de Pedido
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}