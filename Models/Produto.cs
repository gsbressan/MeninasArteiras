using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MeninasArteiras.Models
{
    public class Produto
    {
        [Required]
        public int ProdutoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(250)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [MaxLength]
        [DisplayName("Foto do Produto")]
        public byte[] FotoDoProduto { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        [Required]
        [DisplayName("Valor Unitário em R$")]
        public decimal ValorUnitario { get; set; }

        //
        //Chave estrangeira de Item do Pedido
        public virtual ICollection<ItemDoPedido> ItensDoPedido { get; set; }
    }
}