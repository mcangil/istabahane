using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IsteBahane.Data
{
    public interface IRepository<T> : IDisposable
    {
        T Add(T entity);
        bool Delete(int key);
        T Update(T updated, int key);
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        void Save();
        T Get(int id);
        T Get(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        List<T> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, DateTime>> orderBy);
        IQueryable<T> GetQueryableList();
        List<T> GetAllBySort(Expression<Func<T, bool>> orderBy);
        List<T> GetPagedList(Expression<Func<T, bool>> predicate, Expression<Func<T, DateTime>> orderBy, int startIndex,int rowCount);
        void RunSql(string sql);
    }
}
