using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Blob;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Concrety.Data.AWS
{
    public class BlobManager : IBlobManager
    {
        public async Task UploadAsync(Anexo anexo)
        {
            var transferUtility = new TransferUtility(RegionEndpoint.USEast1);

            var request = new TransferUtilityUploadRequest
            {
                BucketName = ConfigurationManager.AppSettings["OcorrenciasBucket"],
                FilePath = anexo.NomeArquivoUpload,
                Key = GetKey(anexo),
                CannedACL = S3CannedACL.PublicRead,
                PartSize = 6 * 1024 * 1024 //6MB
            };

            await transferUtility.UploadAsync(request).ConfigureAwait(false);
            anexo.UrlPrimaria = Path.Combine("https://s3.amazonaws.com/", request.BucketName, request.Key);
            anexo.UrlSecundaria = string.Empty;
        }

        public async Task RemoverAsync(Anexo anexo)
        {
            var client = new AmazonS3Client(RegionEndpoint.USEast1);

            var request = new DeleteObjectRequest
            {
                BucketName = ConfigurationManager.AppSettings["OcorrenciasBucket"],
                Key = GetKey(anexo)
            };

            await client.DeleteObjectAsync(request).ConfigureAwait(false);
        }

        private string GetKey(Anexo anexo)
        {
            return $"obra-{anexo.IdObra.ToString()}/{anexo.NomeBlob}";
        }
    }
}
