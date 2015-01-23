using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class EmpreendimentoDiarioService : ServiceBase<EmpreendimentoDiario>, IEmpreendimentoDiarioService
    {

        private IRepositoryBase<EmpreendimentoDiario> _repository;

        public EmpreendimentoDiarioService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<EmpreendimentoDiario>();
        }

        public async Task<IEnumerable<EmpreendimentoDiario>> ObterDoEmpreendimento(int idEmpreendimento)
        {
            return await Task.Factory.StartNew(() => { return _repository.ObterDoEmpreendimento(idEmpreendimento); });
        }


        public async Task<EntityResultBase> Criar(EmpreendimentoDiario empreendimentoDiario)
        {
            await base.AddAsync(empreendimentoDiario);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }

        public async Task<EntityResultBase> Atualizar(EmpreendimentoDiario empreendimentoDiario)
        {
            await base.UpdateAsync(empreendimentoDiario);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }
    }
}
