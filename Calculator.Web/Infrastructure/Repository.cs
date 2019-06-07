
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Calculator.Web.Models;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CalculatorContext Context { get; set; }

        public RepositoryBase(CalculatorContext repositoryContext)
        {
            this.Context = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.Context.Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.Context.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }

        public void Create(T entity)
        {
            this.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.Context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
        }
    }
}