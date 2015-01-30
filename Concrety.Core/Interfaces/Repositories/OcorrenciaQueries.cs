using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class OcorrenciaQueries
    {
        public static IEnumerable<Ocorrencia> ObterDoServicoUnidade(
            this IRepositoryBase<Ocorrencia> ocorrenciaRepository, 
            IQueryable<ItemVerificacaoServicoUnidade> itensVerificacao,
            IQueryable<FichaVerificacaoServicoUnidade> fichasVerificacao, 
            int idServicoUnidade)
        {
            var query = from o in ocorrenciaRepository.GetQuery()
                        join i in itensVerificacao on o.IdItemVerificacaoUnidade equals i.Id
                        join f in fichasVerificacao on i.IdFichaVerificacaoServicoUnidade equals f.Id
                        where
                            f.IdServicoUnidade == idServicoUnidade &&
                            f.Ativo && !f.Excluido &&
                            i.Ativo && !i.Excluido &&
                            o.Ativo && !o.Excluido                            
                        select o;

            return query;
        }

    }
}
