using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Queries
{
    public static class ItemVerificacaoMaterialQueries
    {

        public static IEnumerable<ItemVerificacaoMaterial> ObterDaFichaVerificacaoMaterial(
            this IRepositoryBase<ItemVerificacaoMaterial> itemFvmRepository,
            int idFichaVerificacaoMaterial)
        {
            var query = from item in itemFvmRepository.ObterQuery()
                        where
                            item.IdFichaVerificacaoMaterial == idFichaVerificacaoMaterial &&
                            item.Ativo && !item.Excluido
                        select item;

            return query;
        }

    }
}
