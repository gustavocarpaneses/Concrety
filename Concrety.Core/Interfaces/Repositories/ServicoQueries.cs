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

    }
}
