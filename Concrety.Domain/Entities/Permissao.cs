using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Enumerators;

namespace Concrety.Core.Entities
{
    public class Permissao : EntityBase
    {
        public Funcionalidades Funcionalidade { get; set; }
        public bool Listar { get; set; }
        public bool Editar { get; set; }
        public bool Incluir { get; set; }
        public bool Remover { get; set; }

        public virtual Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
    }
}
