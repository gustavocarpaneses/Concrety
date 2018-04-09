using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Blob;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Concrety.Data.Azure
{
    public class BlobManager : IBlobManager
    {

        public async Task UploadAsync(Anexo anexo)
        {
            var container = GetContainer(anexo.IdObra);

            var blockBlob = container.GetBlockBlobReference(anexo.NomeBlob);

            blockBlob.Properties.ContentType = anexo.Tipo;

            await blockBlob.UploadFromFileAsync(anexo.NomeArquivoUpload, FileMode.Open).ConfigureAwait(false);

            anexo.UrlPrimaria = blockBlob.StorageUri.PrimaryUri.ToString();
            anexo.UrlSecundaria = blockBlob.StorageUri.SecondaryUri.ToString();
        }

        public async Task RemoverAsync(Anexo anexo)
        {
            var container = GetContainer(anexo.IdObra);

            var blockBlob = container.GetBlockBlobReference(anexo.NomeBlob);

            await blockBlob.DeleteIfExistsAsync().ConfigureAwait(false);
        }
        
        private CloudBlobContainer GetContainer(int idObra)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["AzureStorage"]);

            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference("obra-" + idObra.ToString());

            container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

            return container;
        }

    }
}
