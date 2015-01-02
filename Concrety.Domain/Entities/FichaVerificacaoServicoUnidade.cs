using Concrety.Domain.Entities.Base;
using Concrety.Domain.Entities.Enumerators;
using System;
using System.Collections.Generic;

namespace Concrety.Domain.Entities
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

        public virtual IEnumerable<ServicoUnidade> Servicos { get; set; }
    }

    public class ServicoUnidade : EntityBase
    {
        public virtual FichaVerificacaoServicoUnidade FichaVerificacaoServicoUnidade { get; set; }
        public int IdFichaVerificacaoServicoUnidade { get; set; }

        public virtual Servico Servico { get; set; }
        public int IdServico { get; set; }

        public ResultadoServicoUnidade Resultado { get; set; }

        public virtual IEnumerable<Ocorrencia> Ocorrencias { get; set; }
    }    
}
