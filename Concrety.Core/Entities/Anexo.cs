using Concrety.Core.Entities.Base;

namespace Concrety.Core.Entities
{
    public class Anexo : EntityBase
    {
        public string Nome { get; set; }
        public string Extensao { get; set; }

        public string ObterNomeComExtensao()
        {
            return string.Format("{0}.{1}", Nome, Extensao);
        }

        public string ContentType { get; set; }
        public byte[] Conteudo { get; set; }
    }
}
