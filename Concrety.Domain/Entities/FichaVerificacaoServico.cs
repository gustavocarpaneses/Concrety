using Concrety.Domain.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Domain.Entities
{
    public class FichaVerificacaoServico : EntityBase
    {
        public string Nome { get; set; }
        public virtual ICollection<Servico> Servicos { get; set; }
        
        public virtual Papel Responsavel { get; set; }
        public int IdPapelResponsavel { get; set; }
    }
}
