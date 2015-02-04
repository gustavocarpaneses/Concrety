using Concrety.Core.Entities;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Repositories
{
    public interface IAnexoRepository : IRepositoryBase<Anexo>
    {
        void AdicionarArquivo(Anexo anexo);
    }
}
