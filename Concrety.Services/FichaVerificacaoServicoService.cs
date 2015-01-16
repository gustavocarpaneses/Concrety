using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Concrety.Services
{
    public class FichaVerificacaoServicoService : ServiceBase<FichaVerificacaoServico>, IFichaVerificacaoServicoService
    {

        private IRepositoryBase<FichaVerificacaoServico> _repository;

        public FichaVerificacaoServicoService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<FichaVerificacaoServico>();
        }

        internal async Task<IEnumerable<FichaVerificacaoServico>> ObterDoServico(int idServico)
        {
            return await Task.Factory.StartNew(() => { return _repository.ObterDoServico(idServico); });
        }
    }
}
