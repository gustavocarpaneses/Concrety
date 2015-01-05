using Concrety.Core.Entities.Base;

namespace Concrety.Core.Entities
{
    public class Servico : EntityBase
    {
        public string Nome { get; set; }
        public string Validacao { get; set; }
        public string Descricao { get; set; }

        public virtual FichaVerificacaoServico FichaVerificacaoServico { get; set; }
        public int IdFichaVerificacaoServico { get; set; }
    }
}
