using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class ItemVerificacaoMaterialQueries
    {

        public static IEnumerable<ItemVerificacaoMaterial> ObterDaFichaVerificacaoMaterial(
            this IRepositoryBase<ItemVerificacaoMaterial> itemFvmRepository,
            int idFichaVerificacaoMaterial)
        {
            var query = from item in itemFvmRepository.GetQuery()
                        where
                            item.IdFichaVerificacaoMaterial == idFichaVerificacaoMaterial &&
                            item.Ativo && !item.Excluido
                        select item;

            return query;
        }

    }
}
