using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IServiceBase
        where TEntity : IEntityBase
    {
        EntityResultBase Criar(TEntity obj);
        Task<EntityResultBase> CriarAsync(TEntity obj);
        
        EntityResultBase Atualizar(TEntity obj);
        Task<EntityResultBase> AtualizarAsync(TEntity obj);

        EntityResultBase Remover(int id);
        Task<EntityResultBase> RemoverAsync(int id);

        EntityResultBase Remover(TEntity obj);
        Task<EntityResultBase> RemoverAsync(TEntity obj);

        TEntity ObterPeloId(int id);
        Task<TEntity> ObterPeloIdAsync(int id);
        
        IEnumerable<TEntity> ObterTodos();
        Task<IEnumerable<TEntity>> ObterTodosAsync();
    }
}
