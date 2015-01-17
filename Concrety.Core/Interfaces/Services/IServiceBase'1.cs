using Concrety.Core.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IServiceBase
        where TEntity : IEntityBase
    {
        void Add(TEntity obj);
        Task<int> AddAsync(TEntity obj);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        Task<int> UpdateAsync(TEntity obj);
        void Remove(TEntity obj);
        Task<int> RemoveAsync(TEntity obj);
    }
}
