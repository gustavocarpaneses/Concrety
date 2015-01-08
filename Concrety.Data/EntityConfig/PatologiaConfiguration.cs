using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class PatologiaConfiguration : EntityBaseConfiguration<Patologia>
    {
        public PatologiaConfiguration()
        {
            ToTable("Patologias");

            Property(p => p.Nome).IsRequired();

            HasRequired(p => p.Servico)
                .WithMany(s => s.Patologias)
                .HasForeignKey(p => p.IdServico);

        }
    }
}
