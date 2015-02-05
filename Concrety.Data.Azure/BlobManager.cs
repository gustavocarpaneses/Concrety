using Concrety.Core.Entities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace Concrety.Data.Azure
{
    public class BlobManager
    {

        public async void UploadOcorrencia(Anexo anexo)
        {
            var container = GetOcorrenciasContainer();

            var blockBlob = container.GetBlockBlobReference(anexo.ObterNomeBlobComExtensao());

            blockBlob.Properties.ContentType = anexo.Tipo;

            await blockBlob.UploadFromByteArrayAsync(anexo.Conteudo, 0, anexo.Conteudo.Length);
        }

        public async void RemoverOcorrencia(Anexo anexo)
        {
            var container = GetOcorrenciasContainer();

            var blockBlob = container.GetBlockBlobReference(anexo.ObterNomeBlobComExtensao());

            await blockBlob.DeleteIfExistsAsync();
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
