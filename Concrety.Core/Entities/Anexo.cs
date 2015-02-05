using Concrety.Core.Entities.Base;

namespace Concrety.Core.Entities
{
    public class Anexo : EntityBase
    {
        public string Nome { get; set; }
        public string NomeBlob { get; set; }
        public int Tamanho { get; set; }
        public string Tipo { get; set; }
        public string Extensao { get; set; }

        public string ObterNomeBlobComExtensao()
        {
            return string.Format("{0}.{1}", NomeBlob, Extensao);
        }

        public byte[] Conteudo { get; set; }
    }
}
