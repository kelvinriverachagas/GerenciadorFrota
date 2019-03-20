using GerenciadorFrotas.Model;
using System;
using System.Collections.Generic;

namespace GerenciadorFrota.Interface.Negocio
{
    public interface IVeiculoNegocio
    {
        Tuple<Veiculo, string> Buscar(string chassi);
        Tuple<bool, string> Salvar(Veiculo veiculo);
        string Editar(Veiculo veiculo);
        string Excluir(string chassi);
        Veiculo BuscarPorChassi(string chassi);
        List<Veiculo> BuscarTodos();
    }
}
