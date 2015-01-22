using Concrety.Core.Entities;
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
                        select d;

            return query;
        }
    }
}
