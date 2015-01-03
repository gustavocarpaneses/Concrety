using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Enumerators;
using System;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class FichaVerificacaoServicoUnidade : EntityBase
    {
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }

        public StatusFichaVerificacaoServico Status { get; set; }

        public virtual FichaVerificacaoServico FichaVerificacaoServico { get; set; }
        public int IdFichaVerificacaoServico { get; set; }

        public virtual MacroServico MacroServico { get; set; }
        public int IdMacroServico { get; set; }

        public virtual Unidade Unidade { get; set; }
        public int? IdUnidade { get; set; }

        public virtual ICollection<ServicoUnidade> Servicos { get; set; }
    }   
}
