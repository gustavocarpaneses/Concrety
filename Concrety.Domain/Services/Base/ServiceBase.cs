using Concrety.Domain.Interfaces.Entities;
using Concrety.Domain.Interfaces.Repositories;
using Concrety.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Concrety.Domain.Services.Base
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : IEntityBase
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
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
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
