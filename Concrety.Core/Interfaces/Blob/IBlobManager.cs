using Concrety.Core.Entities;

namespace Concrety.Core.Interfaces.Blob
{
    public interface IBlobManager
    {
        void Upload(Anexo anexo);
        void Remover(Anexo anexo);
    }
}
