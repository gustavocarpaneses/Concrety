using Concrety.Core.Entities;
using Concrety.Core.Entities.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig.Base
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
