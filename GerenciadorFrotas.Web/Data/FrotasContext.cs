using GerenciadorFrotas.Web.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GerenciadorFrotas.Web.Data
{
    public class FrotasContext : DbContext
    {
        public FrotasContext() : base ("FrotaContext")
        {

        }

        public DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<GerenciadorFrotas.Model.Veiculo> Veiculoes { get; set; }
    }
}