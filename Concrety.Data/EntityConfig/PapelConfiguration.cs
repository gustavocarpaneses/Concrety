using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
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
