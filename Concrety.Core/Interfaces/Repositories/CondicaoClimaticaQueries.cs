using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class CondicaoClimaticaQueries
    {
        public static IEnumerable<CondicaoClimatica> Obter(
            this IRepositoryBase<CondicaoClimatica> condicaoClimaticaRepository)
        {
            var query = from c in condicaoClimaticaRepository.GetQuery()
                        where
                            c.Ativo && !c.Excluido
                        select c;

            return query;
        }
    }
}
