using Concrety.Core.Entities.Base;

namespace Concrety.Core.Entities
{
    public class Anexo : EntityBase
    {
        public string UrlPrimaria { get; set; }
        public string UrlSecundaria { get; set; }

        public int IdObra { get; set; }
        public string NomeArquivoUpload { get; set; }
        public string NomeBlob { get; set; }
        public string Tipo { get; set; }
    }
}
