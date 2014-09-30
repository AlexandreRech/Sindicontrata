using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon;
using Uniplac.ePomar.Modelo.FornecedorModule;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosRepositories
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
