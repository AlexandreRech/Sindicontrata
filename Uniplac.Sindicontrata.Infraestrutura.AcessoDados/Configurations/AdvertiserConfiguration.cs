using System.Data.Entity.ModelConfiguration;
using Uniplac.Sindicontrata.Dominio.AdvertiserModule;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosConfigurations
{
    internal class AdvertiserConfiguration : EntityTypeConfiguration<Advertiser>
    {
        public AdvertiserConfiguration()
        {            
            HasKey(x => x.Id);

            Property(x => x.Name);
        }
    }
}