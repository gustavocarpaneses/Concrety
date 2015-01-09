using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Enumerators;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class ItemVerificacaoMaterialUnidade : EntityBase
    {
        public virtual FichaVerificacaoMaterialUnidade FichaVerificacaoUnidade { get; set; }
        public int IdFichaVerificacaoMaterialUnidade { get; set; }

        public virtual ItemVerificacaoMaterial ItemVerificacao { get; set; }
        public int IdItemVerificacaoMaterial { get; set; }

        public string Resultado { get; set; }
    } 
}
