using Concrety.Core.Entities;
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
            var resultado = await _anexoService.RemoverAsync(ocorrenciaAnexo.Anexo);

            if (!resultado.Sucesso)
            {
                return resultado;
            }

            if (ocorrenciaAnexo.Id > 0)
            {
                return await base.RemoverAsync(ocorrenciaAnexo);
            }
            else
            {
                return resultado;
            }
        }
    }
}
