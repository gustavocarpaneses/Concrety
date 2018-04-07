using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Core.Queries;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class EmpreendimentoService : ServiceBase<Empreendimento>, IEmpreendimentoService
    {
        private IRepositoryBase<Empreendimento> _repository;

        public EmpreendimentoService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<Empreendimento>();
        }

        public async Task<IEnumerable<Empreendimento>> ObterPeloNomeAsync(string nome)
        {
            var query = _repository.ObterPeloNome(nome);
            return await Task.Factory.StartNew(() => { return query; });
        }
    }
}
