using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using Projeto01.Models;
using System.Collections.Generic;
using Projeto01.Contexts;

namespace Projeto01.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Categorias
        public ActionResult Index()
        {
            var categoria =
                context.Categorias.OrderBy(c => c.Nome);

            return View(categoria);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        //public ActionResult Edit(long id)
        //{
        //    var categoria =
        //        categorias.Where(c => c.CategoriaId == id).First();

        //    return View(categoria);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Categoria categoria)
        //{
        //    categorias.Remove(categorias.Where
        //        (c => c.CategoriaId == categoria.CategoriaId).First());

        //    categorias.Add(categoria);

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Details(long id)
        //{
        //    var categoria =
        //        categorias.Where(c => c.CategoriaId == id).First();

        //    return View(categoria);
        //}

        //public ActionResult Delete(long id)
        //{
        //    var categoria = 
        //        categorias.Where(c => c.CategoriaId == id).First();

        //    return View(categoria);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(Categoria categoria)
        //{         
        //     categorias.Remove(categorias.Where
        //         (c => c.CategoriaId == categoria.CategoriaId).First());

        //    return RedirectToAction("Index");
        //}
    }
}