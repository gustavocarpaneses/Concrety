using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IEmpreendimentoDiarioService : IServiceBase<EmpreendimentoDiario>
    {
        Task<IEnumerable<EmpreendimentoDiario>> ObterDoEmpreendimentoAsync(int idEmpreendimento);
    }
}
