using Concrety.Core.Entities.Base;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Data.Context;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public void Criar(TEntity entity)
        {
            ValidarUsuarioLogado();

            entity.IdUsuarioCadastro = _user.Id;
            _context.SetAsAdded(entity);
        }

        public TEntity ObterPeloId(int id)
        {
            return _dbEntitySet.Find(id);
        }

        public async Task<TEntity> ObterPeloIdAsync(int id)
        {
            return await _dbEntitySet.FindAsync(id).ConfigureAwait(false);
        }

        public IQueryable<TEntity> ObterQuery()
        {
            return _dbEntitySet.AsQueryable();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _dbEntitySet
                .Where(e => e.Ativo && !e.Excluido)
                .ToList();
        }

        public async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            return await _dbEntitySet
                .Where(e => e.Ativo && !e.Excluido)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public void Atualizar(TEntity entity)
        {
            ValidarUsuarioLogado();

            entity.IdUsuarioUltimaAtualizacao = _user.Id;
            _context.SetAsModified(entity);
        }

        public void Remover(TEntity entity)
        {
            ValidarUsuarioLogado();

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

        private void ValidarUsuarioLogado()
        {
            if (_user == null)
            {
                throw new ArgumentNullException("_user");
            }
        }

    }
}
