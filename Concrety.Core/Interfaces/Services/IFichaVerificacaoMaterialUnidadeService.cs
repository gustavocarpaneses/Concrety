using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IFichaVerificacaoMaterialUnidadeService : IServiceBase<FichaVerificacaoMaterialUnidade>
    {
        Task<IEnumerable<FichaVerificacaoMaterialUnidade>> ObterDaUnidadeAsync(int idUnidade);
        Task<IEnumerable<ItemVerificacaoMaterialUnidade>> CriarItensAsync(int idFichaVerificacaoMaterial);
        Task<IEnumerable<ItemVerificacaoMaterialUnidade>> ObterItensAsync(int idFichaVerificacaoMaterialUnidade);
    }
}
