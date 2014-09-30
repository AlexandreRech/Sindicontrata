using System.Data.Entity;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosConfigurations;


namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosContexts
{
    public class SindicontrataContext : DbContext
    {
        public SindicontrataContext()
            : base("SindicontrataConnectionString")
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FornecedorConfiguration());
        }
    }

 
}