using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Enumerators;
using System;

namespace Concrety.Core.Entities
{
    public class ServicoUnidade : EntityBase
    {

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public StatusServicoUnidade Status { get; set; }

        public virtual Servico Servico { get; set; }
        public int IdServico { get; set; }
                
        public virtual Unidade Unidade { get; set; }
        public int IdUnidade { get; set; }

        public virtual FichaVerificacaoServicoUnidade FichaVerificacaoServico { get; set; }
        public int IdFichaVerificacaoServicoUnidade { get; set; }

    }
}
