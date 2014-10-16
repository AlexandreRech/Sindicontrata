using System.Data.Entity.ModelConfiguration;
using Uniplac.Sindicontrata.Dominio.AddressModule;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosConfigurations
{
    internal class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {            
            HasKey(x => x.Id);

            //Property(x => x.Name);
        }
    }
}