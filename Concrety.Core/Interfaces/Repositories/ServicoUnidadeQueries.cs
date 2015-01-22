using Concrety.Core.Entities;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class ServicoUnidadeQueries
    {
        public static ServicoUnidade ObterAtualDaUnidade(
            this IRepositoryBase<ServicoUnidade> servicoUnidadeRepository, 
            int idUnidade)
        {
            var query = from su in servicoUnidadeRepository.GetQuery()
                        where
                            su.IdUnidade == idUnidade &&
                            su.Ativo && !su.Excluido
                        orderby su.Servico.Nome descending
                        select su;

            return query.FirstOrDefault();
        }

        public static ServicoUnidade Obter(
            this IRepositoryBase<ServicoUnidade> servicoUnidadeRepository,
            int idUnidade,
            int idServico)
        {
            var query = from su in servicoUnidadeRepository.GetQuery()
                        where
                            su.IdUnidade == idUnidade &&
                            su.IdServico == idServico &&
                            su.Ativo && !su.Excluido
                        select su;

            return query.FirstOrDefault();
        }

    }
}
