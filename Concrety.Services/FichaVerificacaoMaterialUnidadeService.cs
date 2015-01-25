using Concrety.Core.Entities;
using Concrety.Core.Entities.Enumerators;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class FichaVerificacaoMaterialUnidadeService : ServiceBase<FichaVerificacaoMaterialUnidade>, IFichaVerificacaoMaterialUnidadeService
    {
        private IRepositoryBase<FichaVerificacaoMaterialUnidade> _repository;

        public FichaVerificacaoMaterialUnidadeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<FichaVerificacaoMaterialUnidade>();
        }

        public async Task<IEnumerable<FichaVerificacaoMaterialUnidade>> ObterDaUnidade(int idUnidade)
        {
            return await Task.Factory.StartNew(() => { return _repository.ObterDaUnidade(idUnidade); });
        }
    }
}
