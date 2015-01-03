using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class UsuarioConfiguration : UsuarioBaseConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuarios");

            Property(u => u.Email).IsRequired();
            Property(u => u.Senha).IsRequired();
        }
    }
}
