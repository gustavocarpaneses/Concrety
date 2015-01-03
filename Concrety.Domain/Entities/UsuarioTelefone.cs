using Concrety.Domain.Entities.Base;

namespace Concrety.Domain.Entities
{
    public class UsuarioTelefone : EntityBase
    {
        public string DDD { get; set; }
        public string Telefone { get; set; }

        public virtual Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
    }
}
