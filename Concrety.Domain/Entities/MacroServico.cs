using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class MacroServico : EntityBase
    {
        public string Nome { get; set; }

        public virtual Empreendimento Empreendimento { get; set; }
        public int IdEmpreendimento { get; set; }

        public virtual ICollection<EstruturaServico> EstruturasServico { get; set; }

        public virtual ICollection<FichaVerificacaoServicoUnidade> FichasVerificacaoServico { get; set; }
    }
}
