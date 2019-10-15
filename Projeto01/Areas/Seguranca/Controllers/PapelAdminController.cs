using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Projeto01.Areas.Seguranca.Models;
using Projeto01.Infraestrutura;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Areas.Seguranca.Controllers
{
    public class PapelAdminController : Controller
    {
        // GET: Seguranca/PapelAdmin
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        private GerenciadorPapel RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().
                    GetUserManager<GerenciadorPapel>();
            }
        }
    }
}