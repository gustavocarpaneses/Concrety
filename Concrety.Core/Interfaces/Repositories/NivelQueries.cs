using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class NivelQueries
    {
        public static IEnumerable<Nivel> GetNiveisServico(
            this IRepositoryBase<Nivel> nivelRepository, 
            IQueryable<Servico> servicos, 
            int idMacroServico)
        {
            var query = from n in nivelRepository.GetQuery()
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

        public static IEnumerable<Nivel> GetNiveisVerificacaoMaterial(
            this IRepositoryBase<Nivel> nivelRepository, 
            IQueryable<FichaVerificacaoMaterial> fichasVerificacao, 
            int idMacroServico)
        {
            var query = from n in nivelRepository.GetQuery()
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
