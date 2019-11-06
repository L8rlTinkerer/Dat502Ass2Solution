using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Web.Contracts;
using Web.Entities.Mappers;
using Web.Entities.Models;

namespace Web.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected Dat502Ass2DBContext Dat502Ass2DBContext { get; set; }

        public RepositoryBase(Dat502Ass2DBContext dat502Ass2DBContext)
        {
            this.Dat502Ass2DBContext = dat502Ass2DBContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.Dat502Ass2DBContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.Dat502Ass2DBContext.Set<T>().Where(expression).AsNoTracking();
        }

        /*(
        public T Register(T entity)
        {
            var user = Dat502Ass2DBContext.Set<T>().Any(x => x.entity == entity.);

            return user ? null : RegisterResponseToSystemUserMapper.Map(userRego);
            
        }
        */

        public void Create(T entity)
        {
            this.Dat502Ass2DBContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.Dat502Ass2DBContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.Dat502Ass2DBContext.Set<T>().Remove(entity);
        }

       
    }
}
