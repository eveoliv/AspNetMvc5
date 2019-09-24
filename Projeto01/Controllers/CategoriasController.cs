using System;
using System.Linq;
using System.Web;
using Projeto01.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Projeto01.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria() {CategoriaId = 1, Nome = "Notebooks"},
            new Categoria() {CategoriaId = 2, Nome = "Monitores"},
            new Categoria() {CategoriaId = 3, Nome = "Impressoras"},
            new Categoria() {CategoriaId = 4, Nome = "Mouses"},
            new Categoria() {CategoriaId = 5, Nome = "Desktops"}
        };

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }
    }
}