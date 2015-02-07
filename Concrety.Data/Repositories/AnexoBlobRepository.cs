using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Data.Azure;
using Concrety.Data.Context;
using Microsoft.AspNet.Identity;

namespace Concrety.Data.Repositories
{
    public class AnexoBlobRepository : IAnexoBlobRepository
    {
        public void Adicionar(Anexo anexo)
        {
            new BlobManager().Upload(anexo);
        }

        public void Remover(Anexo anexo)
        {
            new BlobManager().Remover(anexo);
        }
    }
}
