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
    public class CondicaoClimaticaService : ServiceBase<CondicaoClimatica>, ICondicaoClimaticaService
    {

        private IRepositoryBase<CondicaoClimatica> _repository;

        public CondicaoClimaticaService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<CondicaoClimatica>();
        }

        public async Task<IEnumerable<CondicaoClimatica>> Obter()
        {
            return await Task.Factory.StartNew(() => { return _repository.Obter(); });
        }
    }
}
