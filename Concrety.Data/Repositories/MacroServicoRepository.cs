using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Data.Context;
using Microsoft.AspNet.Identity;

namespace Concrety.Data.Repositories
{
    public class MacroServicoRepository : RepositoryBase<MacroServico>, IMacroServicoRepository
    {
        public MacroServicoRepository(IEntitiesContext context, IUser<int> user)
            : base(context, user)
        {
        }
    }
}


