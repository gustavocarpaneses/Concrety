using Concrety.Domain.Entities.Base;

namespace Concrety.Domain.Entities
{
    public class Solucao : EntityBase
    {
        public string Descricao { get; set; }

        public virtual Patologia Patologia { get; set; }
        public int IdPatologia { get; set; }
    }
}
