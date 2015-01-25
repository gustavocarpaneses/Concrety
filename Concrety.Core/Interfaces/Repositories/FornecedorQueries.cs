using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class FornecedorQueries
    {
        public static IEnumerable<Fornecedor> Obter(
            this IRepositoryBase<Fornecedor> fornecedorRepository)
        {
            var query = from f in fornecedorRepository.GetQuery()
                        where
                            f.Ativo && !f.Excluido
                        select f;

            return query;
        }
    }
}
