﻿using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class OcorrenciaAnexoService : ServiceBase<OcorrenciaAnexo>, IOcorrenciaAnexoService
    {
        private IRepositoryBase<OcorrenciaAnexo> _repository;
        private IAnexoService _anexoService;

        public OcorrenciaAnexoService(IUnitOfWork unitOfWork, IAnexoService anexoService)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<OcorrenciaAnexo>();
            _anexoService = anexoService;
        }
        
        public async Task<EntityResultBase> RemoverAnexo(OcorrenciaAnexo ocorrenciaAnexo)
        {
            await _anexoService.Remover(ocorrenciaAnexo.Anexo);

            await base.RemoveAsync(ocorrenciaAnexo);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }
    }
}