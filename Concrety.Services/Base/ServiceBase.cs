using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Core.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Services.Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        private readonly IRepositoryBase<TEntity> _repository;
        private bool _disposed;

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repository = UnitOfWork.Repository<TEntity>();
        }

        public EntityResultBase Criar(TEntity obj)
        {
            if (ValidarAsync != null)
            {
                var erros = ValidarAsync(obj).Result;

                if (erros != null)
                {
                    return new EntityResultBase(erros, false);
                }
            }

            if (PreCriar != null)
            {
                PreCriar(obj);
            }

            _repository.Criar(obj);

            var qtdeRegistros = UnitOfWork.SaveChanges();
            if (qtdeRegistros == 0)
            {
                return new EntityResultBase(new List<string>() { ServiceBaseMessages.NENHUM_REGISTRO_CRIADO }, false);
            }

            return new EntityResultBase(null, true);
        }

        public async Task<EntityResultBase> CriarAsync(TEntity obj)
        {
            if (ValidarAsync != null)
            {
                var erros = await ValidarAsync(obj).ConfigureAwait(false);

                if (erros != null)
                {
                    return new EntityResultBase(erros, false);
                }
            }

            if (PreCriar != null)
            {
                PreCriar(obj);
            }

            _repository.Criar(obj);
            
            var qtdeRegistros = await UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
            if (qtdeRegistros == 0)
            {
                return new EntityResultBase(new List<string>() { ServiceBaseMessages.NENHUM_REGISTRO_CRIADO }, false);
            }

            return new EntityResultBase(null, true);
        }

        public EntityResultBase Atualizar(TEntity obj)
        {
            if (ValidarAsync != null)
            {
                var erros = ValidarAsync(obj).Result;

                if (erros != null)
                {
                    return new EntityResultBase(erros, false);
                }
            }

            if (PreAtualizar != null)
            {
                PreAtualizar(obj);
            }

            _repository.Atualizar(obj);

            var qtdeRegistros = UnitOfWork.SaveChanges();
            if (qtdeRegistros == 0)
            {
                return new EntityResultBase(new List<string>() { ServiceBaseMessages.NENHUM_REGISTRO_ATUALIZADO }, false);
            }

            return new EntityResultBase(null, true);
        }

        public async Task<EntityResultBase> AtualizarAsync(TEntity obj)
        {
            if (ValidarAsync != null)
            {
                var erros = await ValidarAsync(obj).ConfigureAwait(false);

                if (erros != null)
                {
                    return new EntityResultBase(erros, false);
                }
            }

            if (PreAtualizar != null)
            {
                PreAtualizar(obj);
            }

            _repository.Atualizar(obj);

            var qtdeRegistros = await UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
            if (qtdeRegistros == 0)
            {
                return new EntityResultBase(new List<string>() { ServiceBaseMessages.NENHUM_REGISTRO_ATUALIZADO }, false);
            }

            return new EntityResultBase(null, true);   
        }

        public EntityResultBase Remover(int id)
        {
            var obj = ObterPeloId(id);
            return Remover(obj);
        }

        public async Task<EntityResultBase> RemoverAsync(int id)
        {
            var obj = await ObterPeloIdAsync(id).ConfigureAwait(false);
            return await RemoverAsync(obj).ConfigureAwait(false);
        }

        public EntityResultBase Remover(TEntity obj)
        {
            _repository.Remover(obj);
            var qtdeRegistros = UnitOfWork.SaveChanges();
            if (qtdeRegistros == 0)
            {
                return new EntityResultBase(new List<string>() { ServiceBaseMessages.NENHUM_REGISTRO_EXCLUIDO}, false);
            }

            return new EntityResultBase(null, true);
        }

        public async Task<EntityResultBase> RemoverAsync(TEntity obj)
        {
            _repository.Remover(obj);
            var qtdeRegistros = await UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
            if (qtdeRegistros == 0)
            {
                return new EntityResultBase(new List<string>() { ServiceBaseMessages.NENHUM_REGISTRO_EXCLUIDO }, false);
            }

            return new EntityResultBase(null, true);
        }

        public TEntity ObterPeloId(int id)
        {
            return _repository.ObterPeloId(id);
        }

        public async Task<TEntity> ObterPeloIdAsync(int id)
        {
            return await _repository.ObterPeloIdAsync(id).ConfigureAwait(false);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync().ConfigureAwait(false);
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
                UnitOfWork.Dispose();
            }
            _disposed = true;
        }
        
        /// <summary>
        /// Ação a ser executada antes dos métodos de criação e atualização (sync e async)
        /// </summary>
        protected Func<TEntity, Task<IEnumerable<string>>> ValidarAsync;

        /// <summary>
        /// Ação a ser executada antes de criar um objeto (sync e async)
        /// </summary>
        protected Action<TEntity> PreCriar;

        /// <summary>
        /// Ação a ser executada antes de atualizar um objeto (sync e async)
        /// </summary>
        protected Action<TEntity> PreAtualizar;

    }
}
