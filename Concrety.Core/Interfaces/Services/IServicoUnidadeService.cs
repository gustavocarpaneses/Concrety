using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IServicoUnidadeService : IServiceBase<ServicoUnidade>
    {
        Task<ServicoUnidade> Obter(int idUnidade, int idServico);
    }
}
