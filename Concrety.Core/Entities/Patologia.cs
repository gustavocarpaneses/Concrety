using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class Patologia : EntityBase
    {
        public string Nome { get; set; }

        public Servico Servico { get; set; }
        public int IdServico { get; set; }

        public virtual ICollection<Solucao> Solucoes { get; set; }
    }
}
