using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerenciadorFrota.Interface.Negocio;
using GerenciadorFrotas.Model;
using GerenciadorFrotas.Model.Enum;
using GerenciadorFrotas.Negocio;
using GerenciadorFrotas.Web.Data;

namespace GerenciadorFrotas.Web.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoNegocio _negocio;

        public VeiculoController(IVeiculoNegocio negocio)
        {
            _negocio = negocio;
        }

        public ActionResult Index()
        {
            return View(_negocio.BuscarTodos());
        }

        public ActionResult Details(string chassi)
        {
            var retorno = _negocio.Buscar(chassi);
            ModelState.AddModelError(string.Empty, retorno.Item2);
            return View(retorno.Item1);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Chassi,TipoVeiculo,NumeroPassageiros,Cor")] Veiculo veiculo)
        public ActionResult Create([Bind(Include = "Id,Chassi,TipoVeiculo,NumeroPassageiros,Cor")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                var retorno = _negocio.Salvar(veiculo);

                if (retorno.Item1)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError(string.Empty, retorno.Item2);
            }

            return View(veiculo);
        }

        public ActionResult Edit(string chassi)
        {
            var retorno = _negocio.Buscar(chassi);

            if (!string.IsNullOrEmpty(retorno.Item2))
                ModelState.AddModelError(string.Empty, retorno.Item2);

            return View(retorno.Item1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Chassi,TipoVeiculo,NumeroPassageiros,Cor")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                var retorno = _negocio.Editar(veiculo);

                if (string.IsNullOrEmpty(retorno))
                    return RedirectToAction("Index");

                ModelState.AddModelError(string.Empty, retorno);
            }
            return View(veiculo);
        }

        public ActionResult Delete(string chassi)
        {
            var retorno = _negocio.Buscar(chassi);

            if (string.IsNullOrEmpty(retorno.Item2))
                return View(retorno.Item1);

            ModelState.AddModelError(string.Empty, retorno.Item2);
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string chassi)
        {
            var retorno = _negocio.Excluir(chassi);

            if (string.IsNullOrEmpty(retorno))
                return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, retorno);
            return View();
        }
    }
}
