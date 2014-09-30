
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosContexts;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private SindicontrataContext dataContext;
        public SindicontrataContext Get()
        {
            return dataContext ?? (dataContext = new SindicontrataContext());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
