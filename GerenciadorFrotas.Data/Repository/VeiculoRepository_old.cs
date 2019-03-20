using GerenciadorFrotas.Model;
using GerenciadorFrotas.Web.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GerenciadorFrotas.Data.Repository
{
    public class VeiculoRepository_old
    {
        private readonly FrotaContext _context;

        public VeiculoRepository_old()
        {
            _context = new FrotaContext();
        }

        public void Salvar(Veiculo veiculo)
        {
            _context.Veiculo.Add(veiculo);
            _context.SaveChanges();
        }

        public IEnumerable<Veiculo> BuscarTodos()
        {
            return _context.Veiculo;
        }

        public Veiculo BuscarPorChassi(string chassi)
        {
            return _context.Veiculo.FirstOrDefault(x => x.Chassi.Equals(chassi));
        }

        public bool ExisteVeiculoChassi(string chassi)
        {
            return _context.Veiculo.Any(x => x.Chassi.Equals(chassi));
        }

        public void Atualizar(Veiculo veiculo)
        {
            _context.Entry(veiculo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void ExcluirPorChassi(string chassi)
        {
            Veiculo veiculo = BuscarPorChassi(chassi);
            _context.Veiculo.Remove(veiculo);
            _context.SaveChanges();
        }
    }
}
