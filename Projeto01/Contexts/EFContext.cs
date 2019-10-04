using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.Entity;
using Modelo.Tabelas;
using Modelo.Cadastros;

namespace Projeto01.Contexts
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class EFContext : DbContext
    {
        public EFContext() : base("asp_net_mvc_cs") {
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Categoria>  Categorias  { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto>    Produtos    { get; set; }
    }
}
/*
 * Enable-Migrations 
 * Add-migration <nome>
 * Update-Database -Verbose
*/
