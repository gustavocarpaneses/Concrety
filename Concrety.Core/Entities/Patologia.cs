using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class Patologia : EntityBase
    {
        public string Nome { get; set; }

        public ItemVerificacaoServico ItemVerificacao { get; set; }
        public int IdItemVerificacao { get; set; }

        public virtual ICollection<Solucao> Solucoes { get; set; }
    }
}
