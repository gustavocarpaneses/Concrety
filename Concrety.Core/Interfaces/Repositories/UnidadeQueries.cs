using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class UnidadeQueries
    {
        public static IEnumerable<Unidade> GetByIdNivel(
            this IRepositoryBase<Unidade> unidadeRepository, 
            int idNivel)
        {
            var query = from u in unidadeRepository.GetQuery()
                        where
                            u.IdNivel == idNivel &&
                            u.Ativo && !u.Excluido
                        orderby u.Nome
                        select u;

            return query;
        }
    }
}
