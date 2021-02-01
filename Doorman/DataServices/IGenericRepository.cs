using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doorman.DataServices
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity model);
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity GetById(int id);
        bool HasChanges();
        void Remove(TEntity model);
        TEntity GetLastEntity();
        Task SaveAsync();
    }
}