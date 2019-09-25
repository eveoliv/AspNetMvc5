using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto01.Models;
using System.Data.Entity;
using MySql.Data.Entity;

namespace Projeto01.Contexts
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class EFContext : DbContext
    {
        public EFContext() : base("asp_net_mvc_cs") { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
    }
}
/*
 * Enable-Migrations 
 * Add-migration <nome>
 * Update-Database -Verbose
*/
