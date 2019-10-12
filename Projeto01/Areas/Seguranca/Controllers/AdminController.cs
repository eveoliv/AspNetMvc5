﻿using Microsoft.AspNet.Identity.Owin;
using Projeto01.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Areas.Seguranca.Controllers
{
    public class AdminController : Controller
    {
        // GET: Seguranca/Admin
        public ActionResult Index()
        {
            var usu = GerenciadorUsuario.Users;
            return View(usu);
        }

       private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext()
                    .GetUserManager<GerenciadorUsuario>();
            }
        }
    }
}