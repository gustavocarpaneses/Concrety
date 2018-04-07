using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Queries
{
    public static class EmpreendimentoQueries
    {
        public static IEnumerable<Empreendimento> ObterPeloNome(
            this IRepositoryBase<Empreendimento> empreendimentoRepository, 
            string nome)
        {
            var query = from e in empreendimentoRepository.ObterQuery()
                        where
                            e.Nome.Equals(nome, StringComparison.InvariantCultureIgnoreCase) &&
                            e.Ativo && !e.Excluido
                        orderby e.Nome
                        select e;

            return query;
        }
    }
}
