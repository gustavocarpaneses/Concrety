using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IUnidadeService : IServiceBase<Unidade>
    {
        Task<IEnumerable<Unidade>> GetByIdNivel(int idNivel);
    }
}
