using System.Data.Entity;
using Uniplac.Sindicontrata.Dominio.FornecedorModule;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon;


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
