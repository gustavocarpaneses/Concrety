using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class FichaVerificacaoMaterialUnidadeQueries
    {

        public static IEnumerable<FichaVerificacaoMaterialUnidade> ObterDaUnidade(
            this IRepositoryBase<FichaVerificacaoMaterialUnidade> fvmRepository,
            int idUnidade)
        {
            var query = from fvm in fvmRepository.GetQuery()
                        where
                            fvm.IdUnidade == idUnidade &&
                            fvm.Ativo && !fvm.Excluido
                        orderby fvm.Data descending
                        select fvm;

            return query;
        }        

    }
}
