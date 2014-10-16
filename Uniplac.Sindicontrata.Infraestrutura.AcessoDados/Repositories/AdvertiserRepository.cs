using System.Data.Entity;
using Uniplac.Sindicontrata.Dominio.AdvertiserModule;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosRepositories
{
    public class AdvertiserRepository : RepositoryBase<Advertiser>, IAdvertiserRepository
    {
        public AdvertiserRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
