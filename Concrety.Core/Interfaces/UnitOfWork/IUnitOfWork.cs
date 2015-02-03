using Concrety.Core.Entities.Base;
using Concrety.Core.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : EntityBase;
        
        void BeginTransaction();
        int Commit();
        void Rollback();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> CommitAsync();
    }
}
