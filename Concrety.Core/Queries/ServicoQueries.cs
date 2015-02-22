using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Queries
{
    public static class ServicoQueries
    {

        public static IEnumerable<Servico> ObterDoNivel(
            this IRepositoryBase<Servico> servicoRepository,
            int idNivel)
        {
            var query = from s in servicoRepository.ObterQuery()
                        where
                            s.IdNivel == idNivel &&
                            s.Ativo && !s.Excluido
                        orderby s.Nome
                        select s;

            return query;
        }

    }
}
