using System.Data.Entity;
using Uniplac.Sindicontrata.Dominio.AddressModule;
using Uniplac.Sindicontrata.Dominio.AdvertisementCategoryModule;
using Uniplac.Sindicontrata.Dominio.AdvertisementModule;
using Uniplac.Sindicontrata.Dominio.AdvertiserModule;
using Uniplac.Sindicontrata.Dominio.ContractorModule;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosConfigurations;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosContexts
{
    public class SindicontrataContext : DbContext
    {
        public SindicontrataContext()
            : base("SindicontrataContext")
        {

        }

        public DbSet<Address> Address { get; set; }
        public DbSet<AdvertisementCategory> AdvertisementCategory { get; set; }
        public DbSet<Advertisement> Advertisement { get; set; }
        public DbSet<Advertiser> Advertiser { get; set; }
        public DbSet<Contractor> Contractor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new AdvertisementCategoryConfiguration());
            modelBuilder.Configurations.Add(new AdvertisementConfiguration());
            modelBuilder.Configurations.Add(new AdvertiserConfiguration());
            modelBuilder.Configurations.Add(new ContractorConfiguration());
        }
    }
}