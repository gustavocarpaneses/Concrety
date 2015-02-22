using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IServicoService : IServiceBase<Servico>
    {
        Task<IEnumerable<Servico>> ObterDaUnidadeAsync(int idUnidade, int idNivel);
    }
}
