using System.Data.Entity.ModelConfiguration;
using Uniplac.Sindicontrata.Dominio.AdvertisementCategoryModule;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosConfigurations
{
    internal class AdvertisementCategoryConfiguration : EntityTypeConfiguration<AdvertisementCategory>
    {
        public AdvertisementCategoryConfiguration()
        {            
            HasKey(x => x.Id);

            Property(x => x.Name);
        }
    }
}