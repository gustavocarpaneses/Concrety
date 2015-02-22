using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IFichaVerificacaoMaterialService : IServiceBase<FichaVerificacaoMaterial>
    {
        Task<IEnumerable<FichaVerificacaoMaterial>> ObterDoNivelAsync(int idNivel);
    }
}
