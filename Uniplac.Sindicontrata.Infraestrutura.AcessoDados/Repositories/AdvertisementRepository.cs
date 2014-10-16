using System.Data.Entity;
using Uniplac.Sindicontrata.Dominio.AdvertisementModule;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosRepositories
{
    public class AdvertisementRepository : RepositoryBase<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
