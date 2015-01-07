using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;

namespace Concrety.Services
{
    public class EmpreendimentoService : ServiceBase<Empreendimento>, IEmpreendimentoService
    {
        public EmpreendimentoService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
