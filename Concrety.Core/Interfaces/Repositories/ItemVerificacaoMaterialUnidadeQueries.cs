using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class ItemVerificacaoMaterialUnidadeQueries
    {

        public static IEnumerable<ItemVerificacaoMaterialUnidade> ObterDaFichaVerificacaoMaterialUnidade(
            this IRepositoryBase<ItemVerificacaoMaterialUnidade> itemFvmRepository,
            int idFichaVerificacaoMaterialUnidade)
        {
            var query = from item in itemFvmRepository.GetQuery()
                        where
                            item.IdFichaVerificacaoMaterialUnidade == idFichaVerificacaoMaterialUnidade &&
                            item.Ativo && !item.Excluido
                        select item;

            return query;
        }

    }
}
