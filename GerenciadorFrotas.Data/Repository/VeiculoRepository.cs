using GerenciadorFrota.Interface.Data;
using GerenciadorFrotas.Model.Enum;
using GerenciadorFrotas.Models;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorFrotas.Data.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public VeiculoRepository()
        {
            if (Session._veiculos == null)
            {
                Session._veiculos = new List<Veiculo>();
                PopularLista();
            }
        }

        public void Salvar(Veiculo veiculo)
        {
            Session._veiculos.Add(veiculo);
        }

        public IEnumerable<Veiculo> BuscarTodos()
        {
            return Session._veiculos;
        }

        public Veiculo BuscarPorChassi(string chassi)
        {
            return Session._veiculos.FirstOrDefault(x => x.Chassi.Equals(chassi));
        }

        public bool ExisteVeiculoChassi(string chassi)
        {
            return Session._veiculos.Any(x => x.Chassi.Equals(chassi));
        }

        public void Atualizar(Veiculo veiculo)
        {
            ExcluirPorChassi(veiculo.Chassi);
            Salvar(veiculo);
        }

        public void ExcluirPorChassi(string chassi)
        {
            Veiculo veiculo = BuscarPorChassi(chassi);
            Session._veiculos.Remove(veiculo);
        }

        private void PopularLista()
        {
            Veiculo veiculo = new Veiculo();
            veiculo.Chassi = "123456789";
            veiculo.TipoVeiculo = TipoVeiculo.Caminhao;
            veiculo.NumeroPassageiros = 2;
            veiculo.Cor = "Azul";
            Session._veiculos.Add(veiculo);

            veiculo = new Veiculo();
            veiculo.Chassi = "987654321";
            veiculo.TipoVeiculo = TipoVeiculo.Onibus;
            veiculo.NumeroPassageiros = 42;
            veiculo.Cor = "Verde";
            Session._veiculos.Add(veiculo);
        }
    }
}
