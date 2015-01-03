using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
{
    public class PatologiaConfiguration : EntityBaseConfiguration<Patologia>
    {
        public PatologiaConfiguration()
        {
            ToTable("Patologias");

            Property(p => p.Nome).IsRequired();
        }
    }
}
