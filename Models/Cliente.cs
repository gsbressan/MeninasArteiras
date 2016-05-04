using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MeninasArteiras.Models
{
    public class Cliente
    {
        [Required]
        public int ClienteID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Logradouro { get; set; }

        public int Numero { get; set; }

        [StringLength(50)]
        public string Complemento { get; set; }

        [StringLength(150)]
        public string Bairro { get; set; }

        [StringLength(150)]
        public string Cidade { get; set; }

        public int CEP { get; set; }

        [DisplayName("Telefone Fixo")]
        public int TelefoneFixo { get; set; }

        [DisplayName("Telefone Celular")]
        public int TelefoneCelular { get; set; }

        [Required]
        [DisplayName("E-Mail")]
        [RegularExpression(".+\\@.+\\..+")]
        public string Email { get; set; }

        //
        //Chave estrangeira do Pedido
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}