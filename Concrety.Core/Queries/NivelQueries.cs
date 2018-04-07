using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Queries
{
    public static class NivelQueries
    {
        public static IEnumerable<Nivel> ObterNiveisDoMacroServico(
            this IRepositoryBase<Nivel> nivelRepository,
            IQueryable<Servico> servicos,
            int idMacroServico)
        {
            var query = from n in nivelRepository.ObterQuery()
                        where
                            n.IdMacroServico == idMacroServico &&
                            n.Ativo && !n.Excluido
                        select n;

            return query;
        }

        public static IEnumerable<Nivel> ObterNiveisDeServico(
            this IRepositoryBase<Nivel> nivelRepository, 
            IQueryable<Servico> servicos, 
            int idMacroServico)
        {
            var query = from n in nivelRepository.ObterQuery()
                        join s in servicos on n.Id equals s.IdNivel
                        where
                            n.IdMacroServico == idMacroServico &&
                            s.Ativo && !s.Excluido &&
                            n.Ativo && !n.Excluido
                        select n;

            return query
                .GroupBy(n => n.Id)
                .Select(g => g.FirstOrDefault());
        }

        public static IEnumerable<Nivel> ObterNiveisDeVerificacaoDeMaterial(
            this IRepositoryBase<Nivel> nivelRepository, 
            IQueryable<FichaVerificacaoMaterial> fichasVerificacao, 
            int idMacroServico)
        {
            var query = from n in nivelRepository.ObterQuery()
                        join fvm in fichasVerificacao on n.Id equals fvm.IdNivel
                        where
                            n.IdMacroServico == idMacroServico &&
                            fvm.Ativo && !fvm.Excluido &&
                            n.Ativo && !n.Excluido
                        select n;

            return query
                .GroupBy(n => n.Id)
                .Select(g => g.FirstOrDefault());
        }
    }
}
