using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class SolucaoConfiguration : EntityBaseConfiguration<Solucao>
    {
        public SolucaoConfiguration()
        {
            ToTable("Solucoes");

            Property(s => s.Nome).IsRequired();
            Property(s => s.Descricao).IsRequired();
            Property(s => s.Norma).HasColumnType("text");

            HasRequired(s => s.Patologia)
                .WithMany(p => p.Solucoes)
                .HasForeignKey(s => s.IdPatologia);
        }
    }
}
