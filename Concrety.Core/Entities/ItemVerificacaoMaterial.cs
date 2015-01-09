using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Enumerators;

namespace Concrety.Core.Entities
{
    public class ItemVerificacaoMaterial : EntityBase
    {
        public string Nome { get; set; }
        public TipoVerificacaoMaterial Tipo { get; set; }

        public virtual FichaVerificacaoMaterial FichaVerificacao { get; set; }
        public int IdFichaVerificacaoMaterial { get; set; }
    }
}
