using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
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
