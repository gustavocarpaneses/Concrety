using Concrety.Core.Entities.Base;
using System;

namespace Concrety.Core.Entities
{
    public class EmpreendimentoPeriodo : EntityBase
    {
        public string Nome { get; set; }
        public int Ordem { get; set; }

        public virtual Empreendimento Empreendimento { get; set; }
        public int IdEmpreendimento { get; set; }
    }
}
