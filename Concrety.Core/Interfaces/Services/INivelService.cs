using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface INivelService : IServiceBase<Nivel>
    {
        Task<IEnumerable<Nivel>> ObterNiveisDeServico(int idMacroServico);
        Task<IEnumerable<Nivel>> ObterNiveisDeVerificacaoDeMaterial(int idMacroServico);
        Task<IEnumerable<Nivel>> ObterNiveisSuperiores(int idNivel);
    }
}
