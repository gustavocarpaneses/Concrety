using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Data.Azure;
using Concrety.Data.Context;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concrety.Data.Repositories
{
    public class AnexoRepository : RepositoryBase<Anexo>, IAnexoRepository
    {

        public AnexoRepository(IEntitiesContext context, IUser<int> user)
            : base(context, user)
        {

        }

        public void AdicionarArquivo(Anexo anexo)
        {
            new BlobManager().UploadOcorrencia(anexo);
        }
    }
}
