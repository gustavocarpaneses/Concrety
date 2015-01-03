using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class UsuarioTelefoneConfiguration : EntityBaseConfiguration<UsuarioTelefone>
    {
        public UsuarioTelefoneConfiguration()
        {
            ToTable("UsuarioTelefones");

            Property(u => u.DDD).IsRequired().HasMaxLength(2);
            Property(u => u.Telefone).IsRequired().HasMaxLength(9);

            HasRequired(u => u.Usuario)
                .WithMany(u => u.Telefones)
                .HasForeignKey(u => u.IdUsuario);
        }
    }
}
