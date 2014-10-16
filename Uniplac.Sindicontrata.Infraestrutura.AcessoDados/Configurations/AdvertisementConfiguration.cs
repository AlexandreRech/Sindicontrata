using System.Data.Entity.ModelConfiguration;
using Uniplac.Sindicontrata.Dominio.AdvertisementModule;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosConfigurations
{
    internal class AdvertisementConfiguration : EntityTypeConfiguration<Advertisement>
    {
        public AdvertisementConfiguration()
        {            
            HasKey(x => x.Id);

            //Property(x => x.Name);
        }
    }
}