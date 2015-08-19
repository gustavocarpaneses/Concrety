
using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Concrety.Core.Interfaces.Services
{
    public interface IRelatorioService : IServiceBase<Relatorio>
    {
        Task<IEnumerable<object[]>> ObterAsync(int id, params object[] parametros);
    }
}
