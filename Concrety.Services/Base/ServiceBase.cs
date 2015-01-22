using Concrety.Core.Entities.Base;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
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

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
            UnitOfWork.SaveChanges();
        }

        public async Task<int> AddAsync(TEntity obj)
        {
            _repository.Add(obj);
            return await UnitOfWork.SaveChangesAsync();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
            UnitOfWork.SaveChanges();
        }

        public async Task<int> UpdateAsync(TEntity obj)
        {
            _repository.Update(obj);
            return await UnitOfWork.SaveChangesAsync();
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
            UnitOfWork.SaveChanges();
        }

        public async Task<int> RemoveAsync(TEntity obj)
        {
            _repository.Remove(obj);
            return await UnitOfWork.SaveChangesAsync();
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
    }
}
