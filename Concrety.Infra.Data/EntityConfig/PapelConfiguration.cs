using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
{
    public class PapelConfiguration : EntityBaseConfiguration<Papel>
    {
        public PapelConfiguration()
        {
            ToTable("Papeis");

            Property(p => p.Descricao).IsRequired();
        }
    }
}
