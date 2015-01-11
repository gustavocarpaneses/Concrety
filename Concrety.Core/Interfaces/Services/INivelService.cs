using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface INivelService : IServiceBase<Nivel>
    {
        Task<IEnumerable<Nivel>> GetNiveisServico(int idMacroServico);
        Task<IEnumerable<Nivel>> GetNiveisVerificacaoMaterial(int idMacroServico);
    }
}
