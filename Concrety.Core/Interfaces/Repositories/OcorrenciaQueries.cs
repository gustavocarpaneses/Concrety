using Concrety.Core.Entities;
using Concrety.Core.Entities.Enumerators;
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

        public static IEnumerable<Ocorrencia> ObterPendentes(
            this IRepositoryBase<Ocorrencia> ocorrenciaRepository,
            IQueryable<ItemVerificacaoServicoUnidade> itensVerificacao,
            IQueryable<FichaVerificacaoServicoUnidade> fichasVerificacao,
            IQueryable<ServicoUnidade> servicosUnidades,
            IQueryable<Servico> servicos,
            IQueryable<Nivel> niveis,
            int idMacroServico)
        {
            var query = from o in ocorrenciaRepository.GetQuery()
                        join i in itensVerificacao on o.IdItemVerificacaoUnidade equals i.Id
                        join f in fichasVerificacao on i.IdFichaVerificacaoServicoUnidade equals f.Id
                        join su in servicosUnidades on f.IdServicoUnidade equals su.Id
                        join s in servicos on su.IdServico equals s.Id
                        join n in niveis on s.IdNivel equals n.Id
                        where
                            n.IdMacroServico == idMacroServico &&
                            n.Ativo && !n.Excluido &&
                            s.Ativo && !s.Excluido &&
                            su.Ativo && !su.Excluido &&
                            f.Ativo && !f.Excluido &&
                            i.Ativo && !i.Excluido &&
                            o.Ativo && !o.Excluido && o.Status == StatusOcorrencia.Pendente
                        select o;

            return query;
        }
    }
}
