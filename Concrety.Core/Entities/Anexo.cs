using Concrety.Core.Entities.Base;

namespace Concrety.Core.Entities
{
    public class Anexo : EntityBase
    {
        public string Nome { get; set; }
        public byte[] Conteudo { get; set; }
    }
}
