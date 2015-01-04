using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class FichaVerificacaoServico : EntityBase
    {
        public string Nome { get; set; }
        public virtual ICollection<Servico> Servicos { get; set; }
    }
}
