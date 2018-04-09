using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Blob;
using Concrety.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Concrety.Data.Repositories
{
    public class AnexoBlobRepository : IAnexoBlobRepository
    {
        private readonly IBlobManager _blobManager;

        public AnexoBlobRepository(IBlobManager blobManager)
        {
            _blobManager = blobManager;
        }

        public async Task AdicionarAsync(Anexo anexo)
        {
            await _blobManager.UploadAsync(anexo).ConfigureAwait(false);
        }

        public async Task RemoverAsync(Anexo anexo)
        {
            await _blobManager.RemoverAsync(anexo).ConfigureAwait(false);
        }
    }
}
