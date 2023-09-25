using Microsoft.AspNetCore.Mvc;
using TechOil.Entities;

namespace TechOil.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<List<T>> GetAllActivo();
        public Task<List<T>> GetAllTerminado();
        public Task<List<T>> GetAllConfirmado();
        public Task<List<Proyecto>> GetAllPendiente();
        public Task<T> GetById(int id);
        public Task<bool> Insert(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(int id);        
    }
}
