using GerenciadorFrotas.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GerenciadorFrotas.Web.Context
{
    public class FrotaContext : DbContext
    {
        public FrotaContext() : base ("FrotaContext")
        {

        }

        public DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}