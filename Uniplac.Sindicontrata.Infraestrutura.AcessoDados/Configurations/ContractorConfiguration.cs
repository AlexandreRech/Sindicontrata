using System.Data.Entity.ModelConfiguration;
using Uniplac.Sindicontrata.Dominio.ContractorModule;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosConfigurations
{
    internal class ContractorConfiguration : EntityTypeConfiguration<Contractor>
    {
        public ContractorConfiguration()
        {            
            HasKey(x => x.Id);

            Property(x => x.Name);
        }
    }
}