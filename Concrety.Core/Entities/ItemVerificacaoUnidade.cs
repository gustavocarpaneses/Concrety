using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Enumerators;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class ItemVerificacaoUnidade : EntityBase
    {
        public virtual FichaVerificacaoServicoUnidade FichaVerificacaoServicoUnidade { get; set; }
        public int IdFichaVerificacaoServicoUnidade { get; set; }

        public virtual ItemVerificacao ItemVerificacao { get; set; }
        public int IdItemVerificacao { get; set; }

        public ResultadoServicoUnidade Resultado { get; set; }

        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; }
    } 
}
