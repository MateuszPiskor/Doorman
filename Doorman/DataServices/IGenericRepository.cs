﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doorman.DataServices
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity model);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        bool HasChanges();
        void Remove(TEntity model);
        TEntity GetLastEntity();
        Task SaveAsync();
    }
}