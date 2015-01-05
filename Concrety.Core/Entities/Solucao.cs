using Concrety.Core.Entities.Base;

namespace Concrety.Core.Entities
{
    public class Solucao : EntityBase
    {
        public string Descricao { get; set; }

        public virtual Patologia Patologia { get; set; }
        public int IdPatologia { get; set; }
    }
}
