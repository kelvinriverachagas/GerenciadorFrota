using GerenciadorFrotas.Model.Enum;

namespace GerenciadorFrotas.Model
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Chassi { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public byte NumeroPassageiros { get; set; }
        public string Cor { get; set; }
    }
}