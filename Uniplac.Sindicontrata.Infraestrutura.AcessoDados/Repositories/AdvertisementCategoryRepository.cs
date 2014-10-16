using System.Data.Entity;
using Uniplac.Sindicontrata.Dominio.AdvertisementCategoryModule;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosRepositories
{
    public class AdvertisementCategoryRepository : RepositoryBase<AdvertisementCategory>, IAdvertisementCategoryRepository
    {
        public AdvertisementCategoryRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
