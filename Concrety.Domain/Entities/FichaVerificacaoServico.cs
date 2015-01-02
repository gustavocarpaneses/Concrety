using Concrety.Domain.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Domain.Entities
{
    public class FichaVerificacaoServico : EntityBase
    {
        public string Nome { get; set; }
        public virtual IEnumerable<Servico> Servicos { get; set; }
        
        public virtual Papel Responsavel { get; set; }
        public int IdPapelResponsavel { get; set; }
    }

    public class Servico : EntityBase
    {
        public string Nome { get; set; }
        public string Validacao { get; set; }
        public string Descricao { get; set; }

        public virtual FichaVerificacaoServico FichaVerificacaoServico { get; set; }
        public int IdFichaVerificacaoServico { get; set; }
    }
}
