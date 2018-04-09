using Concrety.Core.Entities;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Blob
{
    public interface IBlobManager
    {
        Task UploadAsync(Anexo anexo);
        Task RemoverAsync(Anexo anexo);
    }
}
