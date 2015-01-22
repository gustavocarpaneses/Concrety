using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IEmpreendimentoDiarioService : IServiceBase<EmpreendimentoDiario>
    {
        Task<IEnumerable<EmpreendimentoDiario>> ObterDoEmpreendimento(int idEmpreendimento);
    }
}
