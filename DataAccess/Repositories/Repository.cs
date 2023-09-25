using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.Repositories.Interfaces;
using TechOil.Entities;

namespace TechOil.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }       

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        
        public virtual async Task<bool> Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<T>> GetAllActivo()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
            
        }

        public Task<List<T>> GetAllTerminado()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllConfirmado()
        {
            throw new NotImplementedException();
        }

        public Task<List<Proyecto>> GetAllPendiente()
        {
            throw new NotImplementedException();
        }
    }
}
