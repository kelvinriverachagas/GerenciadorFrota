using GerenciadorFrotas.Model.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorFrotas.Web.Models
{
    public class Veiculo
    {
        //public int Id { get; set; }
        //[Required(ErrorMessage = "*Campo Obrigatório")]
        //public string Chassi { get; set; }
        //[Required(ErrorMessage = "*Campo Obrigatório")]
        //[DisplayName("Tipo de veículo")]
        //public TipoVeiculo TipoVeiculo { get; set; }
        //[Required(ErrorMessage = "*Campo Obrigatório")]
        //[DisplayName("Número de passageiros")]
        //public byte NumeroPassageiros { get; set; }
        //[Required(ErrorMessage = "*Campo Obrigatório")]
        //public string Cor { get; set; }
        public int Id { get; set; }
        [Required]
        public string Chassi { get; set; }
        [Required]
        public TipoVeiculo TipoVeiculo { get; set; }
        [Required]
        public byte NumeroPassageiros { get; set; }
        [Required]
        public string Cor { get; set; }
    }
}