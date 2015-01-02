using Concrety.Domain.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Domain.Entities
{
    public class Patologia : EntityBase
    {
        public string Nome { get; set; }

        public virtual IEnumerable<Solucao> Solucoes { get; set; }
    }
}
