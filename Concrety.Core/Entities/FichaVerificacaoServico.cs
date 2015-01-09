using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class FichaVerificacaoServico : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual Servico Servico { get; set; }
        public int IdServico { get; set; }

        public virtual ICollection<ItemVerificacaoServico> Itens { get; set; }
    }
}
