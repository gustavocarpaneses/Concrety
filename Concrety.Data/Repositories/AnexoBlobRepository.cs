using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Blob;
using Concrety.Core.Interfaces.Repositories;

namespace Concrety.Data.Repositories
{
    public class AnexoBlobRepository : IAnexoBlobRepository
    {
        private readonly IBlobManager _blobManager;

        public AnexoBlobRepository(IBlobManager blobManager)
        {
            _blobManager = blobManager;
        }

        public void Adicionar(Anexo anexo)
        {
            _blobManager.Upload(anexo);
        }

        public void Remover(Anexo anexo)
        {
            _blobManager.Remover(anexo);
        }
    }
}
