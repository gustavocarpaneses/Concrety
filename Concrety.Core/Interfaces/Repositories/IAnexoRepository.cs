using Concrety.Core.Entities;

namespace Concrety.Core.Interfaces.Repositories
{
    public interface IAnexoRepository : IRepositoryBase<Anexo>
    {
        void AdicionarArquivo(Anexo anexo);
        void RemoverArquivo(Anexo anexo);
    }
}
