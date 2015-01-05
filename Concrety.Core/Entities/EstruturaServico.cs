using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    /// <summary>
    /// Sub-divisões existentes dentro de um Macro-Serviço
    /// Ex.: Para o Macro-Serviço "Unidades Habitacionais" em um Empreendimento de Apartamentos, 
    /// poderíamos ter as seguintes Estruturas de Serviço:
    /// Quadra
    ///     Bloco
    ///         Unidade
    /// </summary>
    public class EstruturaServico : EntityBase
    {

        public string Nome { get; set; }

        public virtual MacroServico MacroServico { get; set; }
        public int IdMacroServico { get; set; }

        public virtual EstruturaServico EstruturaServicoPai { get; set; }
        public int? IdEstruturaServicoPai { get; set; }

        public virtual EstruturaServico EstruturaServicoFilho { get; set; }
        public int? IdEstruturaServicoFilho { get; set; }

        public virtual ICollection<Unidade> Unidades { get; set; }

    }
}
