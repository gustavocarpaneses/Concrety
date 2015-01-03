using Concrety.Domain.Entities;
using Concrety.Domain.Entities.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig.Base
{
    public class EntityBaseConfiguration<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
    {
        public EntityBaseConfiguration()
        {
            HasKey(e => e.Id);
            
            Property(e => e.Ativo).IsRequired();
            Property(e => e.Excluido).IsRequired();
            Property(e => e.DataCadastro).IsRequired();

            HasOptional(e => e.UsuarioCadastro)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCadastro);

            HasOptional(e => e.UsuarioUltimaAtualizacao)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioUltimaAtualizacao);

            HasOptional(e => e.UsuarioExclusao)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioExclusao);
        }
    }
}
