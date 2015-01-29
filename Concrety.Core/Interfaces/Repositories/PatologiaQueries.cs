using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class PatologiaQueries
    {

        public static IEnumerable<Patologia> ObterDoItemVerificacao(
            this IRepositoryBase<Patologia> patologiaRepository,
            int idItemVerificacaoServico)
        {
            var query = from p in patologiaRepository.GetQuery()
                        where
                            p.IdItemVerificacaoServico == idItemVerificacaoServico &&
                            p.Ativo && !p.Excluido
                        orderby p.Nome
                        select p;

            return query;
        }

    }
}
