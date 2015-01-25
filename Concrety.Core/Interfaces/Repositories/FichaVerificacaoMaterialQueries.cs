using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Concrety.Core.Interfaces.Repositories
{
    public static class FichaVerificacaoMaterialQueries
    {

        public static IEnumerable<FichaVerificacaoMaterial> ObterDoNivel(
            this IRepositoryBase<FichaVerificacaoMaterial> fvmRepository,
            int idNivel)
        {
            var query = from fvm in fvmRepository.GetQuery()
                        where
                            fvm.IdNivel == idNivel &&
                            fvm.Ativo && !fvm.Excluido
                        orderby fvm.Nome
                        select fvm;

            return query;
        }

    }
}
