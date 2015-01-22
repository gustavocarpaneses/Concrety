using Concrety.Core.Entities;
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
    }
}
