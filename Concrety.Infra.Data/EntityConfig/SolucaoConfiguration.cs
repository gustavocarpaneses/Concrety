using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
{
    public class SolucaoConfiguration : EntityBaseConfiguration<Solucao>
    {
        public SolucaoConfiguration()
        {
            ToTable("Solucoes");

            Property(s => s.Descricao).IsRequired().HasMaxLength(5000);

            HasRequired(s => s.Patologia)
                .WithMany(p => p.Solucoes)
                .HasForeignKey(s => s.IdPatologia);
        }
    }
}
