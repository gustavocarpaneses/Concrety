using Concrety.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
