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
    public class AnexoService : ServiceBase<Anexo>, IAnexoService
    {
        private IAnexoBlobRepository _anexoBlobRepository;

        public AnexoService(IUnitOfWork unitOfWork, IAnexoBlobRepository anexoBlobRepository)
            : base(unitOfWork)
        {
            _anexoBlobRepository = anexoBlobRepository;
        }

        public new async Task<EntityResultBase> CriarAsync(Anexo anexo)
        {
            var indiceInicioExtensao = anexo.Tipo.IndexOf("/") + 1;
            var extensao = anexo.Tipo.Substring(indiceInicioExtensao);

            anexo.NomeBlob = Guid.NewGuid().ToString() + "." + extensao;
            
            _anexoBlobRepository.Adicionar(anexo);

            return await base.CriarAsync(anexo);
        }

        public new async Task<EntityResultBase> RemoverAsync(Anexo anexo)
        {
            _anexoBlobRepository.Remover(anexo);
            return await base.RemoverAsync(anexo);
        }
    }
}
