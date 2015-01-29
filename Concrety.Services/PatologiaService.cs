using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class PatologiaService : ServiceBase<Patologia>, IPatologiaService
    {
        private IRepositoryBase<Patologia> _repository;

        public PatologiaService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<Patologia>();
        }

        public async Task<IEnumerable<Patologia>> ObterDoItemVerificacao(int idItemVerificacaoServico)
        {
            return await Task.Factory.StartNew(() => { return _repository.ObterDoItemVerificacao(idItemVerificacaoServico); });
        }
    }
}
