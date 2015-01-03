using Concrety.Domain.Entities.Base;
using Concrety.Domain.Interfaces.Entities;
using Concrety.Domain.Interfaces.Repositories;
using Concrety.Domain.Interfaces.Services;
using Concrety.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;

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

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
            UnitOfWork.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
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

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
            UnitOfWork.SaveChanges();
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
