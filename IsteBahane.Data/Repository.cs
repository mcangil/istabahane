using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IsteBahane.Data.DB;

namespace IsteBahane.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IsteBahaneEntities _context = new IsteBahaneEntities();

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
            return entity;
        }

        public bool Delete(int key)
        {
            var entity = _context.Set<T>().Find(key);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                Save();
            }
            return true;
        }

        public T Update(T updated, int key)
        {
            if (updated == null)
                return null;

            T existing = _context.Set<T>().Find(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                _context.SaveChanges();
            }
            return existing;
        }


        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Count(predicate);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T Get(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy)
        {
            return _context.Set<T>().OrderByDescending(orderBy).FirstOrDefault(predicate);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            Save();
            return _context.Set<T>().Where(predicate).ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, DateTime>> orderBy)
        {
            return _context.Set<T>().Where(predicate).OrderByDescending(orderBy).ToList();
        }

        public IQueryable<T> GetQueryableList()
        {
            return _context.Set<T>().AsQueryable();
        }

        public List<T> GetPagedList(Expression<Func<T, bool>> predicate, Expression<Func<T, DateTime>> orderBy, int startIndex, int rowCount)
        {
            return _context.Set<T>().Where(predicate).OrderByDescending(orderBy).Skip(startIndex).Take(rowCount).ToList();
        }


        public List<T> GetAllBySort(Expression<Func<T, bool>> orderBy)
        {
            throw new NotImplementedException();
        }

        public void RunSql(string sql)
        {
            _context.Database.ExecuteSqlCommand(sql);
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.SaveChanges();
            GC.SuppressFinalize(this);
        }
    }
}
