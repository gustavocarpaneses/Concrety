using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IFichaVerificacaoMaterialUnidadeService : IServiceBase<FichaVerificacaoMaterialUnidade>
    {
        Task<IEnumerable<FichaVerificacaoMaterialUnidade>> ObterDaUnidade(int idUnidade);
    }
}
