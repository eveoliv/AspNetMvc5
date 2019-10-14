using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Data.Entity;
using Modelo.Tabelas;
using Persistencia.Contexts;
using Servicos.Tabelas;

namespace Projeto01.Areas.Tabelas.Controllers
{
    public class CategoriasController : Controller
    {
        // Private Methods >>>>>>>>>>>>>>>>>>>>>>>>
        private CategoriaServico categoriaServico = new CategoriaServico();

        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = categoriaServico.ObterCategoriaPorId((long)id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        private void PopularViewBag(Categoria categoria = null)
        {
            if (categoria == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico
                    .ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome");                       
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico
                    .ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome", categoria.CategoriaId);
            }
        }

        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }

                PopularViewBag(categoria);
                return View(categoria);
            }
            catch 
            {
                PopularViewBag(categoria);
                return View(categoria);
            }
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // GET: Categorias
        [Authorize]
        public ActionResult Index()
        {
            var categoria = categoriaServico.ObterCategoriasClassificadasPorNome();
            return View(categoria);
        }

        // GET: Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        public ActionResult Edit(long? id)
        {
            PopularViewBag(categoriaServico.ObterCategoriaPorId((long)id));
            return ObterVisaoCategoriaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        public ActionResult Details(long? id)
        {                       
            return ObterVisaoCategoriaPorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Categoria categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = $"Categoria {categoria.Nome.ToUpper()} foi removida.";
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }
    }
}