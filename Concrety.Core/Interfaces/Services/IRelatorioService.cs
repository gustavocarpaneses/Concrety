
using Concrety.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Concrety.Core.Interfaces.Services
{
    public interface IRelatorioService : IServiceBase<Relatorio>
    {
        Task<List<dynamic>> ObterAsync(int id, params object[] parametros);
    }
}
