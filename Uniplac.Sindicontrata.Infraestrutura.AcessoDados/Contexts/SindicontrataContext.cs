using System.Data.Entity;
using Uniplac.Sindicontrata.Dominio.FornecedorModule;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosConfigurations;


namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosContexts
{
    public class SindicontrataContext : DbContext
    {
        public SindicontrataContext()
            : base("SindicontrataContext")
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FornecedorConfiguration());
        }
    }

 
}