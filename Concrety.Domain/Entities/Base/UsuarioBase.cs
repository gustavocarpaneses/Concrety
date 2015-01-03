using Concrety.Core.Interfaces.Entities;

namespace Concrety.Core.Entities.Base
{
    public abstract class UsuarioBase : EntityBase, IUsuarioBase
    {
        public string Nome { get; set; }
    }
}
