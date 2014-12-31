using Concrety.Application.Interfaces;
using Concrety.Domain.Interfaces.Entities;
using Concrety.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Concrety.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity>
        where TEntity : IEntityBase
    {

        private readonly IServiceBase<TEntity> _service;

        public AppServiceBase(IServiceBase<TEntity> service)
        {
            _service = service;
        }

        public void Add(TEntity obj)
        {
            _service.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _service.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public void Update(TEntity obj)
        {
            _service.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _service.Remove(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
