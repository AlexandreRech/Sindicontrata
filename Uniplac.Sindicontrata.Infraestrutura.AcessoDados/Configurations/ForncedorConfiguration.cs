using System.Data.Entity.ModelConfiguration;
using Uniplac.Sindicontrata.Dominio.FornecedorModule;


namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosConfigurations
{
    internal class FornecedorConfiguration : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfiguration()
        {            
            HasKey(x => x.Id);

            Property(x => x.Nome);
        }
    }
}
