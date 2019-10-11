using Microsoft.AspNet.Identity.EntityFramework;
using Projeto01.Areas.Seguranca.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto01.Areas.DAL
{
    public class IdentityDbContextAplicacao : IdentityDbContext<Usuario>
    {
        public IdentityDbContextAplicacao() : base("identitydb"){}

        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>(new IdentityDbInit()); 
        }

        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();               
        }

        private class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao>{}
    }
}