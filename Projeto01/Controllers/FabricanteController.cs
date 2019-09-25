using Projeto01.Contexts;
using Projeto01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Controllers
{
    public class FabricanteController : Controller
    {
        private EFContext context = new EFContext();    

        // GET: Fabricante
        public ActionResult Index()
        {
            var fabricante =
                context.Fabricantes.OrderBy(f => f.Nome);

            return View(fabricante);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            context.Fabricantes.Add(fabricante);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}