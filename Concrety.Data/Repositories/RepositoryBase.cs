using Concrety.Core.Entities.Base;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Concrety.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {

        private readonly IEntitiesContext _context;
        private readonly DbSet<TEntity> _dbEntitySet;
        private bool _disposed;
        private IUser<int> _user;

        public RepositoryBase(IEntitiesContext context, IUser<int> user)
        {
            _context = context;
            _user = user;
            _dbEntitySet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            ValidateUserArgument();

            entity.IdUsuarioCadastro = _user.Id;
            _context.SetAsAdded(entity);
        }

        public TEntity GetById(int id)
        {
            return _dbEntitySet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbEntitySet.FindAsync(id);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _dbEntitySet.AsQueryable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbEntitySet.ToList();
        }

        public void Update(TEntity entity)
        {
            ValidateUserArgument();

            entity.IdUsuarioUltimaAtualizacao = _user.Id;
            _context.SetAsModified(entity);
        }

        public void Remove(TEntity entity)
        {
            ValidateUserArgument();

            entity.IdUsuarioExclusao = _user.Id;
            _context.SetAsDeleted(entity);
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
            }
            _disposed = true;
        }

        private void ValidateUserArgument()
        {
            if (_user == null)
            {
                throw new ArgumentNullException("_user");
            }
        }

    }
}
