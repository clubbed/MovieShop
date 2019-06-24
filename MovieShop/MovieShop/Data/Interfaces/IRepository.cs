using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllByExpression(Expression<Func<T, bool>> predicate);
        int GetCount();
        T GetSingleByExpression(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void DeleteByExpression(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void UpdateByExpression(Expression<Func<T, bool>> predicate, T entity);
        void CommitChanges();
    }
}
