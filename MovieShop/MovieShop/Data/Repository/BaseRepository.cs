using MovieShop.Data.Interfaces;
using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteByExpression(Expression<Func<T, bool>> predicate)
        {
            var entity = _context.Set<T>().Where(predicate).FirstOrDefault();
            if (entity == null)
            {
                throw new NotImplementedException();
            }

            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAllByExpression(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public int GetCount()
        {
            return _context.Set<T>().Count();
        }

        public T GetSingleByExpression(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateByExpression(Expression<Func<T, bool>> predicate, T entity)
        {
            var oldEntity = _context.Set<T>().Where(predicate).FirstOrDefault();
            oldEntity = entity;
        }
    }
}
