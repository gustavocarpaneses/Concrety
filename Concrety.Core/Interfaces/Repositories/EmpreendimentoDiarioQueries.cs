using Concrety.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class EmpreendimentoDiarioQueries
    {
        public static IEnumerable<EmpreendimentoDiario> ObterDoEmpreendimento(
            this IRepositoryBase<EmpreendimentoDiario> empreendimentoDiarioRepository,
            int idEmpreendimento)
        {
            var query = from d in empreendimentoDiarioRepository.GetQuery()
                        where
                            d.IdEmpreendimento == idEmpreendimento &&
                            d.Ativo && !d.Excluido
                        orderby d.Data descending
                        select d;

            return query;
        }

        public static bool ExisteNaData(
            this IRepositoryBase<EmpreendimentoDiario> empreendimentoDiarioRepository,
            int idEmpreendimento,
            int idEmpreendimentoDiario,
            DateTime data)
        {
            var query = from d in empreendimentoDiarioRepository.GetQuery()
                        where
                            d.IdEmpreendimento == idEmpreendimento &&
                            d.Id != idEmpreendimentoDiario &&
                            d.Data == data &&
                            d.Ativo && !d.Excluido
                        select d;

            return query.Any();
        }
    }
}
