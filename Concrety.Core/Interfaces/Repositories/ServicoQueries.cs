using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class ServicoQueries
    {

        public static IEnumerable<Servico> ObterDoNivel(
            this IRepositoryBase<Servico> servicoRepository,
            int idNivel)
        {
            var query = from s in servicoRepository.GetQuery()
                        where
                            s.IdNivel == idNivel &&
                            s.Ativo && !s.Excluido
                        orderby s.Nome
                        select s;

            return query;
        }

        public static Servico ObterAtualDaUnidade(
            this IRepositoryBase<Servico> servicoRepository, 
            IQueryable<ServicoUnidade> servicosUnidades,
            int idUnidade)
        {
            var query = from s in servicoRepository.GetQuery()
                        join su in servicosUnidades on s.Id equals su.IdServico
                        where
                            su.IdUnidade == idUnidade &&
                            s.Ativo && !s.Excluido &&
                            su.Ativo && !su.Excluido
                        orderby s.Nome
                        select s;

            return query.LastOrDefault();
        }
    }
}
