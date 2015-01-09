using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Enumerators;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class ItemVerificacaoServicoUnidade : EntityBase
    {
        public virtual FichaVerificacaoServicoUnidade FichaVerificacaoUnidade { get; set; }
        public int IdFichaVerificacaoServicoUnidade { get; set; }

        public virtual ItemVerificacaoServico ItemVerificacao { get; set; }
        public int IdItemVerificacaoServico { get; set; }

        public ResultadoServicoUnidade Resultado { get; set; }

        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; }
    } 
}
