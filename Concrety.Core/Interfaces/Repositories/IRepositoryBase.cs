using Concrety.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace Concrety.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable
        where TEntity : IEntityBase
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
