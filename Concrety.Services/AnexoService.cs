using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class AnexoService : ServiceBase<Anexo>, IAnexoService
    {
        private IAnexoRepository _repository;

        public AnexoService(IUnitOfWork unitOfWork, IAnexoRepository anexoRepository)
            : base(unitOfWork)
        {
            _repository = anexoRepository;
        }

        public async Task<EntityResultBase> Criar(Anexo anexo)
        {
            anexo.NomeBlob = DateTime.Now.Ticks.ToString();

            await base.AddAsync(anexo);

            _repository.AdicionarArquivo(anexo);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }


        public async Task<EntityResultBase> Excluir(Anexo anexo)
        {
            await base.RemoveAsync(anexo);

            _repository.RemoverArquivo(anexo);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }
    }
}
