using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Queries
{
    public static class ItemVerificacaoMaterialUnidadeQueries
    {

        public static IEnumerable<ItemVerificacaoMaterialUnidade> ObterDaFichaVerificacaoMaterialUnidade(
            this IRepositoryBase<ItemVerificacaoMaterialUnidade> itemFvmRepository,
            int idFichaVerificacaoMaterialUnidade)
        {
            var query = from item in itemFvmRepository.ObterQuery()
                        where
                            item.IdFichaVerificacaoMaterialUnidade == idFichaVerificacaoMaterialUnidade &&
                            item.Ativo && !item.Excluido
                        select item;

            return query;
        }

    }
}
