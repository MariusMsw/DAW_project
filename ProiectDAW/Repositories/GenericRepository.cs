using Microsoft.EntityFrameworkCore;
using ProiectDAW.Data;
using ProiectDAW.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProiectDAW.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly Context _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(Context context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void CreateRange(List<T> entities)
        {
            _table.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public T FindById(int id)
        {
            return _table.Find(id);
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}
