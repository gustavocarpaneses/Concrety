using Concrety.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Concrety.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IServiceBase
        where TEntity : IEntityBase
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
