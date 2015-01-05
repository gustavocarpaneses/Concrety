using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Enumerators;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class ServicoUnidade : EntityBase
    {
        public virtual FichaVerificacaoServicoUnidade FichaVerificacaoServicoUnidade { get; set; }
        public int IdFichaVerificacaoServicoUnidade { get; set; }

        public virtual Servico Servico { get; set; }
        public int IdServico { get; set; }

        public ResultadoServicoUnidade Resultado { get; set; }

        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; }
    } 
}
