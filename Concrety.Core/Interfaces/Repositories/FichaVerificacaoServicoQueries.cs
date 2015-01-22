using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class FichaVerificacaoServicoQueries
    {
        public static IEnumerable<FichaVerificacaoServico> ObterDoServico(
            this IRepositoryBase<FichaVerificacaoServico> fichaVerificacaoServicoRepository,
            int idServico)
        {
            var query = from f in fichaVerificacaoServicoRepository.GetQuery()
                        where
                            f.IdServico == idServico &&
                            f.Ativo && !f.Excluido
                        select f;

            return query;
        }
    }
}
