using Concrety.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class EmpreendimentoDiario : EntityBase
    {
        public DateTime Data { get; set; }
        public string ServicosExecutados { get; set; }

        public virtual Empreendimento Empreendimento { get; set; }
        public int IdEmpreendimento { get; set; }

        public virtual ICollection<EmpreendimentoDiarioPeriodo> DiariosPeriodos { get; set; }
    }
}
