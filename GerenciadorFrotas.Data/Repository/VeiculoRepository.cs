using GerenciadorFrota.Interface.Data;
using GerenciadorFrotas.Model;
using GerenciadorFrotas.Web.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GerenciadorFrotas.Data.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public VeiculoRepository()
        {
            if (Session._veiculos == null)
                Session._veiculos = new List<Veiculo>();
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
    }
}
