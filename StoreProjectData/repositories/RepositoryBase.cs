using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectData.repositories
{
    public class RepositoryBase<TContext> where TContext : DbContext
    {
        private TContext _context;

        public RepositoryBase(TContext context)
        {
            _context = context;
        }

        protected TContext Context
        {
            get
            {
                return _context;
            }
        }

        public T Add<T>(T entity)
            where T : class
        {
            return _context.Set<T>().Add(entity);
        }

        public bool Any<T>(Expression<Func<T, bool>> predicate, params string[] includes)
           where T : class
        {
            return GetAll(predicate, includes).Any();
        }

        public T Attach<T>(T entity)
            where T : class
        {
            return _context.Set<T>().Attach(entity);
        }

        public T Remove<T>(T entity)
            where T : class
        {
            return _context.Set<T>().Remove(entity);
        }

        public T GetFirst<T>(Expression<Func<T, bool>> predicate)
            where T : class
        {
            return GetFirst(predicate, null);
        }

        public T GetFirst<T>(Expression<Func<T, bool>> predicate, params string[] includes)
            where T : class
        {
            return GetAll(predicate, includes).First();
        }

        public T GetFirstOrDefault<T>(Expression<Func<T, bool>> predicate, params string[] includes)
            where T : class
        {
            return GetAll(predicate, includes).FirstOrDefault();
        }

        public IQueryable<T> GetAll<T>(params string[] includes)
            where T : class
        {
            return GetAll<T>(null, includes);
        }

        public T GetMaxId<T>(Expression<Func<T, int>> predicate) where T : class
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            return dbQuery.OrderByDescending(predicate).FirstOrDefault();

        }

        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> predicate, params string[] includes)
           where T : class
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    dbQuery = dbQuery.Include(include);

            if (predicate != null)
                dbQuery = dbQuery.Where(predicate);

            return dbQuery;
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        throw new Exception(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }

                throw dbEx;
            }
        }
    }
}
