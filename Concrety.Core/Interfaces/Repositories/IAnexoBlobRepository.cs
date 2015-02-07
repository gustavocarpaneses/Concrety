using Concrety.Core.Entities;

namespace Concrety.Core.Interfaces.Repositories
{
    public interface IAnexoBlobRepository
    {
        void Adicionar(Anexo anexo);
        void Remover(Anexo anexo);
    }
}
