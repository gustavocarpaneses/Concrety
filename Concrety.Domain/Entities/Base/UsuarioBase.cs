using Concrety.Domain.Interfaces.Entities;

namespace Concrety.Domain.Entities.Base
{
    public abstract class UsuarioBase : EntityBase, IUsuarioBase
    {
        public string Nome { get; set; }
    }
}
