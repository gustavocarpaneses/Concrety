using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Queries
{
    public static class FichaVerificacaoMaterialUnidadeQueries
    {

        public static IEnumerable<FichaVerificacaoMaterialUnidade> ObterDaUnidade(
            this IRepositoryBase<FichaVerificacaoMaterialUnidade> fvmRepository,
            int idUnidade)
        {
            var query = from fvm in fvmRepository.ObterQuery()
                        where
                            fvm.IdUnidade == idUnidade &&
                            fvm.Ativo && !fvm.Excluido
                        orderby fvm.Data descending
                        select fvm;

            return query;
        }        

    }
}
