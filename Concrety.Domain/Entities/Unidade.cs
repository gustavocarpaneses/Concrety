using Concrety.Domain.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Domain.Entities
{
    public class Unidade : EntityBase
    {
        public string Nome { get; set; }

        public virtual EstruturaServico EstruturaServico { get; set; }
        public int IdEstruturaServico { get; set; }

        public virtual Unidade UnidadePai { get; set; }
        public int IdUnidadePai { get; set; }

        public virtual IEnumerable<Unidade> SubUnidades { get; set; }

        public virtual IEnumerable<FichaVerificacaoServicoUnidade> FichasVerificacaoServico { get; set; }
    }
}
