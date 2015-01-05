using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class Unidade : EntityBase
    {
        public string Nome { get; set; }

        public virtual EstruturaServico EstruturaServico { get; set; }
        public int IdEstruturaServico { get; set; }

        public virtual Unidade UnidadePai { get; set; }
        public int? IdUnidadePai { get; set; }

        public virtual ICollection<Unidade> SubUnidades { get; set; }

        public virtual ICollection<FichaVerificacaoServicoUnidade> FichasVerificacaoServico { get; set; }
    }
}
