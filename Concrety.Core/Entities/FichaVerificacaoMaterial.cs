using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class FichaVerificacaoMaterial : EntityBase
    {

        public string Nome { get; set; }
        public string Material { get; set; }
        public string CriterioAceite { get; set; }

        public virtual Nivel Nivel { get; set; }
        public int IdNivel { get; set; }

        public ICollection<ItemVerificacaoMaterial> Itens { get; set; }
                
    }
}
