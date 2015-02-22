using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Queries
{
    public static class FichaVerificacaoMaterialQueries
    {

        public static IEnumerable<FichaVerificacaoMaterial> ObterDoNivel(
            this IRepositoryBase<FichaVerificacaoMaterial> fvmRepository,
            int idNivel)
        {
            var query = from fvm in fvmRepository.ObterQuery()
                        where
                            fvm.IdNivel == idNivel &&
                            fvm.Ativo && !fvm.Excluido
                        orderby fvm.Nome
                        select fvm;

            return query;
        }

    }
}
