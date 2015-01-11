using Concrety.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable
        where TEntity : IEntityBase
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetQuery();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
