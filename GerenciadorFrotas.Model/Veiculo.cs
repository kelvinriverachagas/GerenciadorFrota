using GerenciadorFrotas.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorFrotas.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        [Required]
        public string Chassi { get; set; }
        [Required]
        public TipoVeiculo TipoVeiculo { get; set; }

        public byte NumeroPassageiros { get; set; }
        [Required]
        public string Cor { get; set; }
    }
}