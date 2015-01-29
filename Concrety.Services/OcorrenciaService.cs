using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;

namespace Concrety.Services
{
    public class OcorrenciaService : ServiceBase<Ocorrencia>, IOcorrenciaService
    {
        private IRepositoryBase<Ocorrencia> _repository;

        public OcorrenciaService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<Ocorrencia>();
        }
    }
}
