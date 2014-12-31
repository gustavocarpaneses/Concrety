using Concrety.Domain.Interfaces.Entities;
using System.Collections.Generic;

namespace Concrety.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : IEntityBase
    {

        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();

    }
}
