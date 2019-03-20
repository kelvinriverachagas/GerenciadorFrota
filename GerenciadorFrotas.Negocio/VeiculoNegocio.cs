using GerenciadorFrota.Interface.Data;
using GerenciadorFrota.Interface.Negocio;
using GerenciadorFrotas.Data.Repository;
using GerenciadorFrotas.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorFrotas.Negocio
{
    public class VeiculoNegocio : IVeiculoNegocio
    {
        private readonly IVeiculoRepository _repositorio;

        public VeiculoNegocio(IVeiculoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public Tuple<Veiculo, string> Buscar(string chassi)
        {
            string mensagem = string.Empty;
            Veiculo veiculo = new Veiculo();

            try
            {
                if (string.IsNullOrEmpty(chassi))
                    mensagem = "Chassi inválido";
                else
                {
                    veiculo = BuscarPorChassi(chassi);

                    if (veiculo == null)
                        mensagem = "Veículo não encontrado";
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao buscar veículo";
            }

            return new Tuple<Veiculo, string>(veiculo, mensagem);
        }

        public Tuple<bool, string> ValidarCamposObrigatorios(Veiculo veiculo)
        {
            try
            {
                if (string.IsNullOrEmpty(veiculo.Chassi) ||
                    string.IsNullOrEmpty(veiculo.NumeroPassageiros.ToString()) ||
                    string.IsNullOrEmpty(veiculo.Cor))
                    return new Tuple<bool, string>(false, "Campos obrigatórios devem ser preenchidos");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, "Erro ao validar campos");
            }

            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> Salvar(Veiculo veiculo)
        {
            string mensagem = string.Empty;

            try
            {
                var retorno = ValidarCamposObrigatorios(veiculo);

                if (!retorno.Item1)
                    mensagem = retorno.Item2;
                else
                {

                    if (!_repositorio.ExisteVeiculoChassi(veiculo.Chassi))
                    {
                        _repositorio.Salvar(veiculo);
                        return new Tuple<bool, string>(true, mensagem);
                    }
                    else
                        mensagem = "Chassi já cadastrado!";
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao salvar veículo";
            }

            return new Tuple<bool, string>(false, mensagem);
        }

        public string Editar(Veiculo veiculo)
        {
            string mensagem = string.Empty;

            try
            {
                if (_repositorio.ExisteVeiculoChassi(veiculo.Chassi))
                    _repositorio.Atualizar(veiculo);
                else
                    mensagem = "Chassi não encontrado!";
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao atualizar veículo";
            }

            return mensagem;

        }

        public string Excluir(string chassi)
        {
            string mensagem = string.Empty;

            try
            {
                if (_repositorio.ExisteVeiculoChassi(chassi))
                    _repositorio.ExcluirPorChassi(chassi);
                else
                    mensagem = "Chassi não encontrado!";
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao excluir veículo";
            }

            return mensagem;

        }

        public Veiculo BuscarPorChassi(string chassi)
        {
            return _repositorio.BuscarPorChassi(chassi);
        }

        public List<Veiculo> BuscarTodos()
        {
            return _repositorio.BuscarTodos().ToList();
        }
    }
}
