using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IAnexoService : IServiceBase<Anexo>
    {
        Task<EntityResultBase> Criar(Anexo anexo);
        Task<EntityResultBase> Remover(Anexo anexo);
    }
}
