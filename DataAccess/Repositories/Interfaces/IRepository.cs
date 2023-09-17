﻿namespace TechOil.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<bool> Insert(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(int id);
    }
}
