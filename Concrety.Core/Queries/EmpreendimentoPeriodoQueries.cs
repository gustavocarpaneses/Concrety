using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Queries
{
    public static class EmpreendimentoPeriodoQueries
    {
        public static IEnumerable<EmpreendimentoPeriodo> ObterDoEmpreendimento(
            this IRepositoryBase<EmpreendimentoPeriodo> empreendimentoPeriodoRepository,
            int idEmpreendimento)
        {
            var query = from p in empreendimentoPeriodoRepository.ObterQuery()
                        where
                            p.IdEmpreendimento == idEmpreendimento &&
                            p.Ativo && !p.Excluido
                        orderby p.Ordem ascending
                        select p;

            return query;
        }
    }
}
