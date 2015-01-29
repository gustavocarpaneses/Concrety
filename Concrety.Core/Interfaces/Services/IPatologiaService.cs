using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IPatologiaService : IServiceBase<Patologia>
    {
        Task<IEnumerable<Patologia>> ObterDoItemVerificacao(int idItemVerificacaoServico);
    }
}
