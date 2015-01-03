using Concrety.Core.Entities.Base;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace Concrety.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {

        protected readonly IEntitiesContext _context;
        protected readonly IDbSet<TEntity> _dbEntitySet;
        private bool _disposed;
        protected IUser<int> _user;

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
