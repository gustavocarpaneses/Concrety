using Concrety.Core.Entities;
using Concrety.Core.Entities.Enumerators;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Core.Queries;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class FichaVerificacaoMaterialService : ServiceBase<FichaVerificacaoMaterial>, IFichaVerificacaoMaterialService
    {
        private IRepositoryBase<FichaVerificacaoMaterial> _repository;

        public FichaVerificacaoMaterialService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<FichaVerificacaoMaterial>();
        }

        public async Task<IEnumerable<FichaVerificacaoMaterial>> ObterDoNivelAsync(int idNivel)
        {
            return await Task.Factory.StartNew(() => { return _repository.ObterDoNivel(idNivel); });
        }
    }
}
