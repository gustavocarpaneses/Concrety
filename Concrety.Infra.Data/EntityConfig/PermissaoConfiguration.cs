using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
{
    public class PermissaoConfiguration : EntityBaseConfiguration<Permissao>
    {
        public PermissaoConfiguration()
        {
            ToTable("Permissoes");

            Property(p => p.Funcionalidade).IsRequired();
            Property(p => p.Listar).IsRequired();
            Property(p => p.Editar).IsRequired();
            Property(p => p.Incluir).IsRequired();
            Property(p => p.Remover).IsRequired();

            HasRequired(p => p.Usuario)
                .WithMany(u => u.Permissoes)
                .HasForeignKey(p => p.IdUsuario);
        }
    }
}
