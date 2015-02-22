using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Queries
{
    public static class UnidadeQueries
    {
        public static IEnumerable<Unidade> ObterDoNivel(
            this IRepositoryBase<Unidade> unidadeRepository, 
            int idNivel)
        {
            var query = from u in unidadeRepository.ObterQuery()
                        where
                            u.IdNivel == idNivel &&
                            u.Ativo && !u.Excluido
                        orderby u.Nome
                        select u;

            return query;
        }
    }
}
