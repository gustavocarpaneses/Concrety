using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IFichaVerificacaoMaterialUnidadeService : IServiceBase<FichaVerificacaoMaterialUnidade>
    {
        Task<IEnumerable<FichaVerificacaoMaterialUnidade>> ObterDaUnidade(int idUnidade);
        Task<EntityResultBase> Criar(FichaVerificacaoMaterialUnidade fvm);
        Task<EntityResultBase> Atualizar(FichaVerificacaoMaterialUnidade fvm);
    }
}
