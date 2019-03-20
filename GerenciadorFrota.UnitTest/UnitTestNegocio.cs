using System;
using GerenciadorFrota.Interface.Data;
using GerenciadorFrotas.Data.Repository;
using GerenciadorFrotas.Model.Enum;
using GerenciadorFrotas.Negocio;
using GerenciadorFrotas.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GerenciadorFrota.UnitTest
{
    [TestClass]
    public class UnitTestNegocio
    {
        [TestMethod]
        public void TestarSalvarVeiculo()
        {
            IVeiculoRepository repositorio = new VeiculoRepository();
            VeiculoNegocio negocio = new VeiculoNegocio(repositorio);

            Veiculo veiculo = new Veiculo();
            veiculo.Chassi = "123456789";
            veiculo.TipoVeiculo = TipoVeiculo.Caminhao;
            veiculo.NumeroPassageiros = 2;
            veiculo.Cor = "Azul";
            negocio.Salvar(veiculo);

            Assert.AreEqual(veiculo, repositorio.BuscarPorChassi(veiculo.Chassi));
        }

        [TestMethod]
        public void TestarSalvarVeiculoMesmoChassi()
        {
            IVeiculoRepository repositorio = new VeiculoRepository();
            VeiculoNegocio negocio = new VeiculoNegocio(repositorio);

            Veiculo veiculo = new Veiculo();
            veiculo.Chassi = "123456789";
            veiculo.TipoVeiculo = TipoVeiculo.Caminhao;
            veiculo.NumeroPassageiros = 2;
            veiculo.Cor = "Azul";
            negocio.Salvar(veiculo);

            veiculo = new Veiculo();
            veiculo.Chassi = "123456789";
            veiculo.TipoVeiculo = TipoVeiculo.Onibus;
            veiculo.NumeroPassageiros = 42;
            veiculo.Cor = "Verde";

            var retorno = negocio.Salvar(veiculo);

            Assert.AreEqual(retorno.Item1, false);
        }

        [TestMethod]
        public void TestarExcluirVeiculo()
        {
            IVeiculoRepository repositorio = new VeiculoRepository();
            VeiculoNegocio negocio = new VeiculoNegocio(repositorio);

            Veiculo veiculo = new Veiculo();
            veiculo.Chassi = "123456789";
            veiculo.TipoVeiculo = TipoVeiculo.Caminhao;
            veiculo.NumeroPassageiros = 2;
            veiculo.Cor = "Azul";
            negocio.Salvar(veiculo);
            negocio.Excluir(veiculo.Chassi);

            Assert.AreNotEqual(veiculo, repositorio.BuscarPorChassi(veiculo.Chassi));
        }

        [TestMethod]
        public void TestarBuscarVeiculoChassi()
        {
            IVeiculoRepository repositorio = new VeiculoRepository();
            VeiculoNegocio negocio = new VeiculoNegocio(repositorio);

            Veiculo veiculo = new Veiculo();
            veiculo.Chassi = "123456789";
            veiculo.TipoVeiculo = TipoVeiculo.Caminhao;
            veiculo.NumeroPassageiros = 2;
            veiculo.Cor = "Azul";
            negocio.Salvar(veiculo);
            var retorno = negocio.BuscarPorChassi(veiculo.Chassi);

            Assert.AreEqual(veiculo, retorno);
        }

        [TestMethod]
        public void TestarBuscarVeiculoChassiInvalido()
        {
            IVeiculoRepository repositorio = new VeiculoRepository();
            VeiculoNegocio negocio = new VeiculoNegocio(repositorio);

            var retorno = negocio.Buscar("");

            Assert.AreEqual(retorno.Item2, "Chassi inválido");
        }
    }
}
