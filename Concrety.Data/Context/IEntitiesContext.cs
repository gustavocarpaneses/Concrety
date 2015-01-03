using Concrety.Domain.Entities.Base;
using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Concrety.Data.Context
{
    public interface IEntitiesContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase;
        void SetAsAdded<TEntity>(TEntity entity) where TEntity : EntityBase;
        void SetAsModified<TEntity>(TEntity entity) where TEntity : EntityBase;
        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : EntityBase;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void BeginTransaction();
        int Commit();
        void Rollback();
        Task<int> CommitAsync();
    }
}
