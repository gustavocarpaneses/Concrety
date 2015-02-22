using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IOcorrenciaService : IServiceBase<Ocorrencia>
    {
        Task<IEnumerable<Ocorrencia>> ObterDoServicoUnidadeAsync(int idServicoUnidade);
        Task<IEnumerable<Ocorrencia>> ObterPendentesAsync(int idMacroServico);
    }
}
