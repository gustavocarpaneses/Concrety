using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface INivelService : IServiceBase<Nivel>
    {
        Task<IEnumerable<Nivel>> ObterNiveisDeServicoAsync(int idMacroServico);
        Task<IEnumerable<Nivel>> ObterNiveisDeVerificacaoDeMaterialAsync(int idMacroServico);
        Task<IEnumerable<Nivel>> ObterNiveisSuperioresAsync(int idNivel);
    }
}
