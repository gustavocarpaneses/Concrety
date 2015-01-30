using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IOcorrenciaService : IServiceBase<Ocorrencia>
    {
        Task<EntityResultBase> Criar(Ocorrencia ocorrencia);
        Task<EntityResultBase> Atualizar(Ocorrencia ocorrencia);
        Task<IEnumerable<Ocorrencia>> ObterDoServicoUnidade(int idServicoUnidade);
    }
}
