using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;

namespace Concrety.Services
{
    public class ItemVerificacaoServicoService : ServiceBase<ItemVerificacaoServico>, IItemVerificacaoServicoService
    {
        public ItemVerificacaoServicoService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
