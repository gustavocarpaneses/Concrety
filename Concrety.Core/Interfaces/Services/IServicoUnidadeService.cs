using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IServicoUnidadeService : IServiceBase<ServicoUnidade>
    {
        Task<ServicoUnidade> ObterAsync(int idUnidade, int idServico);
        Task<ServicoUnidadeResult> Salvar(ServicoUnidade servicoUnidade);
    }
}
