using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IEmpreendimentoDiarioService : IServiceBase<EmpreendimentoDiario>
    {
        Task<IEnumerable<EmpreendimentoDiario>> ObterDoEmpreendimento(int idEmpreendimento);
        Task<EntityResultBase> Criar(EmpreendimentoDiario empreendimentoDiario);
        Task<EntityResultBase> Atualizar(EmpreendimentoDiario empreendimentoDiario);
    }
}
