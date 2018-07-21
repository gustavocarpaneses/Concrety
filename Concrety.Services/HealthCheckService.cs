using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryBase<CondicaoClimatica> _repository;

        public HealthCheckService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<CondicaoClimatica>();
        }

        public async Task<EntityResultBase> CheckAsync()
        {
            try
            {
                var condicoesClimaticas = await _repository.ObterTodosAsync().ConfigureAwait(false);

                if (condicoesClimaticas.Any())
                    return new EntityResultBase(null, true);

                return new EntityResultBase(new List<string>
                {
                    "Nenhuma condição climática cadastrada"
                }, false);
            }
            catch(Exception ex)
            {
                var errors = new List<string>();
                var actualEx = ex;
                while(actualEx != null)
                {
                    errors.Add($"{actualEx.Message} - {actualEx.Source} - {actualEx.StackTrace}");
                    actualEx = actualEx.InnerException;
                }

                return new EntityResultBase(errors, false);
            }
        }
    }
}
