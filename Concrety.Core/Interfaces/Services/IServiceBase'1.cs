using Concrety.Core.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IServiceBase
        where TEntity : IEntityBase
    {
        void Add(TEntity obj);
        Task AddAsync(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void UpdateAsync(TEntity obj);
        void Remove(TEntity obj);
        void RemoveAsync(TEntity obj);
    }
}
