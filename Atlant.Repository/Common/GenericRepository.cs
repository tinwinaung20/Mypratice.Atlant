using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Atlant.Model;

namespace Atlant.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
         where T : Entity
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;


        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public T Add(T entity)
        {
           return _dbset.Add(entity);
        }

        public T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}
