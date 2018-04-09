using Concrety.Core.Entities;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Repositories
{
    public interface IAnexoBlobRepository
    {
        Task AdicionarAsync(Anexo anexo);
        Task RemoverAsync(Anexo anexo);
    }
}
