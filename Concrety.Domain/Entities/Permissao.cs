using Concrety.Domain.Entities.Enumerators;

namespace Concrety.Domain.Entities
{
    public class Permissao
    {
        public Funcionalidades Funcionalidade { get; set; }
        public bool Listar { get; set; }
        public bool Editar { get; set; }
        public bool Incluir { get; set; }
        public bool Remover { get; set; }
    }
}
