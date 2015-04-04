using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IEmpreendimentoDiarioPeriodoService : IServiceBase<EmpreendimentoDiarioPeriodo>
    {
        Task<IEnumerable<EmpreendimentoDiarioPeriodo>> ObterPeriodosDoEmpreendimentoAsync(int idEmpreendimento);
    }
}
