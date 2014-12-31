using Concrety.Domain.Interfaces.Entities;
using System.Collections.Generic;

namespace Concrety.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : IEntityBase
    {

        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();

    }
}
