using GerenciadorFrotas.Models;
using System.Collections.Generic;

namespace GerenciadorFrota.Interface.Data
{
    public interface IVeiculoRepository
    {
        void Salvar(Veiculo veiculo);
        IEnumerable<Veiculo> BuscarTodos();
        Veiculo BuscarPorChassi(string chassi);
        bool ExisteVeiculoChassi(string chassi);
        void Atualizar(Veiculo veiculo);
        void ExcluirPorChassi(string chassi);
    }
}
