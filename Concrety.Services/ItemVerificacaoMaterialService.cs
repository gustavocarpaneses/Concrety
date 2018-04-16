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
    public class ItemVerificacaoMaterialService : ServiceBase<ItemVerificacaoMaterial>, IItemVerificacaoMaterialService
    {
        private IRepositoryBase<ItemVerificacaoMaterial> _repository;

        public ItemVerificacaoMaterialService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<ItemVerificacaoMaterial>();
        }
    }
}
