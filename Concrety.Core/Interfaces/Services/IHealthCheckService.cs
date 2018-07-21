using Concrety.Core.Entities.Results;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IHealthCheckService
    {
        Task<EntityResultBase> CheckAsync();
    }
}
