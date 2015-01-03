using Concrety.Data.Context;
using Concrety.Data.Repositories;
using Concrety.Domain.Entities.Base;
using Concrety.Domain.Interfaces.Repositories;
using Concrety.Domain.Interfaces.UnitOfWork;
using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace Concrety.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IEntitiesContext _context;
        private readonly IUser<int> _user;
        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(IEntitiesContext context, IUser<int> user)
        {
            _context = context;
            _user = user;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : EntityBase
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IRepositoryBase<TEntity>)_repositories[type];
            }
            var repositoryType = typeof(RepositoryBase<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context, _user));
            return (IRepositoryBase<TEntity>)_repositories[type];
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }

        public int Commit()
        {
            return _context.Commit();
        }

        public void Rollback()
        {
            _context.Rollback();
        }

        public Task<int> CommitAsync()
        {
            return _context.CommitAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
                foreach (IDisposable repository in _repositories.Values)
                {
                    repository.Dispose();// dispose all repositries
                }
            }
            _disposed = true;
        }
    }
}
