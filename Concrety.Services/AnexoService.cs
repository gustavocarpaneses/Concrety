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

        public async Task<EntityResultBase> Criar(Anexo anexo)
        {
            var indiceInicioExtensao = anexo.Tipo.IndexOf("/") + 1;
            var extensao = anexo.Tipo.Substring(indiceInicioExtensao);

            anexo.NomeBlob = Guid.NewGuid().ToString() + "." + extensao;
            
            _anexoBlobRepository.Adicionar(anexo);

            await base.AddAsync(anexo);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }
        
        

        public async Task<EntityResultBase> Remover(Anexo anexo)
        {
            _anexoBlobRepository.Remover(anexo);

            await base.RemoveAsync(anexo);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }
    }
}
