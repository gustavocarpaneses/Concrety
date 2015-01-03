using Concrety.Core.Entities.Base;

namespace Concrety.Core.Entities
{
    public class UsuarioTelefone : EntityBase
    {
        public string DDD { get; set; }
        public string Telefone { get; set; }

        public virtual Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
    }
}
