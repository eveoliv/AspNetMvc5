using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto01.Areas.Seguranca.Models
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Papel : IdentityRole
    {

        public Papel() : base() { }
        public Papel(string name) : base(name) { }
    }
}