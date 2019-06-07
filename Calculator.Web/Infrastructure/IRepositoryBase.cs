using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
         IQueryable<T> Find(Expression<Func<T, bool>> expression);
      
         void Create(T entity);
        void Update(T entity);
           void Delete(T entity);
    }
}