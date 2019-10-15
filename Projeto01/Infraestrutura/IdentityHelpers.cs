using Microsoft.AspNet.Identity.Owin;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Infraestrutura
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            GerenciadorUsuario mgr = HttpContext.Current.GetOwinContext().GetUserManager<GerenciadorUsuario>();

            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }
    }
}
/*
 * Enable-Migrations 
 * Add-migration <nome>
 * Update-Database -Verbose
*/
