using System.Data.Entity;
using Uniplac.Sindicontrata.Dominio.ContractorModule;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon;


namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosRepositories
{
    public class ContractorRepository : RepositoryBase<Contractor>, IContractorRepository
    {
        public ContractorRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
