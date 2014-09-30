using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Uniplac.Sindicontrata.Dominio
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(long id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}