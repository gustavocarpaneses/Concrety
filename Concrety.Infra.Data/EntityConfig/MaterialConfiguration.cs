using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
{
    public class MaterialConfiguration : EntityBaseConfiguration<Material>
    {
        public MaterialConfiguration()
        {
            ToTable("Materiais");

            Property(m => m.Nome).IsRequired();
            Property(m => m.CriterioAceite).HasColumnType("text");
        }
    }
}
