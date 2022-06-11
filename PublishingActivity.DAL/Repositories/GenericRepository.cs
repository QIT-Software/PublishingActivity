using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PublishingActivity.DAL.EF;
using PublishingActivity.DAL.Entities.Abstract;
using PublishingActivity.DAL.Interfaces;

namespace PublishingActivity.DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : AbstractDbObject
    {
        private readonly ApplicationContext _context;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T GetById(int id)
        {
            var entity = _dbSet.FirstOrDefault(e => e.Id == id);

            return entity;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            var query = _dbSet as IQueryable<T>;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = _dbSet.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (obj is null)
                return;
            _dbSet.Remove(obj);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}