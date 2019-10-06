using Modelo.Cadastros;
using Persistencia.Contexts;
using Servicos.Cadastros;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Controllers
{
    public class FabricantesController : Controller
    {
        // Private Methods >>>>>>>>>>>>>>>>>>>>>>>>>
        private FabricanteServico fabricanteServico = new FabricanteServico();

        private ActionResult ObterVisaoFabricantePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);

            if (fabricante == null)
            {
                return HttpNotFound();
            }

            return View(fabricante);
        }
         
        private void PopularViewBag(Fabricante fabricante = null)
        {
            if (fabricante == null)
            {
                ViewBag.FabricanteId = new SelectList(fabricanteServico
                    .ObterFabricantesClassificadosPorNome(), "FabricanteId", "Nome");
            }
            else
            {
                ViewBag.FabricanteId = new SelectList(fabricanteServico
                    .ObterFabricantesClassificadosPorNome(), "FabricanteId", "Nome", fabricante.FabricanteId);
            }
        }

        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch 
            {
                return View(fabricante);
            }
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<       

        // GET: Fabricante
        public ActionResult Index()
        {
            var fabricante = fabricanteServico.ObterFabricantesClassificadosPorNome();
            return View(fabricante);
        }

        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        public ActionResult Edit(long? id)
        {
            PopularViewBag(fabricanteServico.ObterFabricantePorId((long)id));
            return ObterVisaoFabricantePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Fabricante fabricante = fabricanteServico.EliminarFabricantePorId(id);
                TempData["Message"] = $"Fabricante {fabricante.Nome.ToUpper()} foi removido.";
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }
    }
}