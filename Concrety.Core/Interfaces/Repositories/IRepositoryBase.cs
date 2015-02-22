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
        void Criar(TEntity obj);
        TEntity ObterPeloId(int id);
        Task<TEntity> ObterPeloIdAsync(int id);
        IEnumerable<TEntity> ObterTodos();
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        IQueryable<TEntity> ObterQuery();
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);
    }
}
