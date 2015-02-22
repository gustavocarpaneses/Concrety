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
    public class UnidadeService : ServiceBase<Unidade>, IUnidadeService
    {

        private IRepositoryBase<Unidade> _repository;

        public UnidadeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<Unidade>();
        }
        
        public async Task<IEnumerable<Unidade>> ObterDoNivelAsync(int idNivel)
        {
            var query = _repository.ObterDoNivel(idNivel);
            return await Task.Factory.StartNew(() => { return query; });
        }

    }
}
