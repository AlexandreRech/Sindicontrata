using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosContexts;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon 
{
    public class UnitOfWork : IUnitOfWork
    {
        private SindicontrataContext dbContext;
        private readonly IDatabaseFactory dbFactory;
        protected SindicontrataContext DbContext
        {
            get
            {
                return dbContext ?? dbFactory.Get();
            }
        }

        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}