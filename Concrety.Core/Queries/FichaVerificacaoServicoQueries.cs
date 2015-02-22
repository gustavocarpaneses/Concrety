using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Queries
{
    public static class FichaVerificacaoServicoQueries
    {
        public static IEnumerable<FichaVerificacaoServico> ObterDoServico(
            this IRepositoryBase<FichaVerificacaoServico> fichaVerificacaoServicoRepository,
            int idServico)
        {
            var query = from f in fichaVerificacaoServicoRepository.ObterQuery()
                        where
                            f.IdServico == idServico &&
                            f.Ativo && !f.Excluido
                        select f;

            return query;
        }
    }
}
