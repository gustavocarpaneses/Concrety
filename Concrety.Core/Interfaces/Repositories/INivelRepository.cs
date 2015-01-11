using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Repositories
{
    public interface INivelRepository : IRepositoryBase<Nivel>
    {
        Task<IEnumerable<Nivel>> GetNiveisServico(int idMacroServico);
        Task<IEnumerable<Nivel>> GetNiveisVerificacaoMaterial(int idMacroServico);
    }
}
