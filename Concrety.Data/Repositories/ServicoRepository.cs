using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Data.Context;
using Microsoft.AspNet.Identity;

namespace Concrety.Data.Repositories
{
    public class ServicoRepository : RepositoryBase<Servico>, IServicoRepository
    {
        public ServicoRepository(IEntitiesContext context, IUser<int> user)
            : base(context, user)
        {
        }
    }
}
