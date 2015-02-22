using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;

namespace Concrety.Services
{
    public class CondicaoClimaticaService : ServiceBase<CondicaoClimatica>, ICondicaoClimaticaService
    {
        public CondicaoClimaticaService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
