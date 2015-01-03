using Concrety.Domain.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
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
