using Concrety.Core.Entities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Concrety.Data.Azure
{
    public class BlobManager
    {

        public async void UploadOcorrencia(Anexo anexo)
        {
            var container = GetOcorrenciasContainer();

            var blockBlob = container.GetBlockBlobReference(anexo.ObterNomeComExtensao());

            blockBlob.Properties.ContentType = anexo.ContentType;

            await blockBlob.UploadFromByteArrayAsync(anexo.Conteudo, 0, anexo.Conteudo.Length);
        }

        public Uri GetFileUri(string nomeArquivo)
        {
            var container = GetOcorrenciasContainer();            

            // Retrieve reference to a blob named "myblob".
            var blockBlob = container.GetBlockBlobReference(nomeArquivo);

            // Create or overwrite the "myblob" blob with contents from a local file.
            return blockBlob.Uri;
        }

        private CloudBlobContainer GetOcorrenciasContainer()
        {
            // Retrieve storage account from connection string.
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["ConcretyStorage"]);

            // Create the blob client.
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            return blobClient.GetContainerReference("ocorrencias");
        }

    }
}
