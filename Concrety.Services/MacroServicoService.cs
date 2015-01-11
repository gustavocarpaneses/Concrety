using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;

namespace Concrety.Services
{
    public class MacroServicoService : ServiceBase<MacroServico>, IMacroServicoService
    {
        public MacroServicoService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
