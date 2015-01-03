using Concrety.Domain.Entities;
using Concrety.Domain.Entities.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig.Base
{
    public class UsuarioBaseConfiguration<TEntity> : EntityBaseConfiguration<TEntity>
        where TEntity : UsuarioBase
    {
        public UsuarioBaseConfiguration()
        {
            Property(u => u.Nome).IsRequired();
        }
    }
}
