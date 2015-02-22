using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Queries
{
    public static class PatologiaQueries
    {

        public static IEnumerable<Patologia> ObterDoItemVerificacao(
            this IRepositoryBase<Patologia> patologiaRepository,
            int idItemVerificacaoServico)
        {
            var query = from p in patologiaRepository.ObterQuery()
                        where
                            p.IdItemVerificacaoServico == idItemVerificacaoServico &&
                            p.Ativo && !p.Excluido
                        orderby p.Nome
                        select p;

            return query;
        }

    }
}
