using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Blob;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.IO;

namespace Concrety.Data.Azure
{
    public class AzureBlobManager : IBlobManager
    {

        public void Upload(Anexo anexo)
        {
            var container = GetContainer(anexo.IdObra);

            var blockBlob = container.GetBlockBlobReference(anexo.NomeBlob);

            blockBlob.Properties.ContentType = anexo.Tipo;

            blockBlob.UploadFromFile(anexo.NomeArquivoUpload, FileMode.Open);

            anexo.UrlPrimaria = blockBlob.StorageUri.PrimaryUri.ToString();
            anexo.UrlSecundaria = blockBlob.StorageUri.SecondaryUri.ToString();
        }

        public void Remover(Anexo anexo)
        {
            var container = GetContainer(anexo.IdObra);

            var blockBlob = container.GetBlockBlobReference(anexo.NomeBlob);

            blockBlob.DeleteIfExistsAsync();
        }
        
        private CloudBlobContainer GetContainer(int idObra)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["ConcretyStorage"]);

            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference("obra-" + idObra.ToString());

            container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

            return container;
        }

    }
}
