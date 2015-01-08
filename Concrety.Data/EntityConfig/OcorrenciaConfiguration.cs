using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class OcorrenciaConfiguration : EntityBaseConfiguration<Ocorrencia>
    {
        public OcorrenciaConfiguration()
        {
            ToTable("Ocorrencias");

            Property(o => o.DataAbertura).IsRequired();
            Property(o => o.Status).IsRequired();

            HasRequired(o => o.ItemVerificacao)
                .WithMany(s => s.Ocorrencias)
                .HasForeignKey(o => o.IdItemVerificacao);

            HasRequired(o => o.Patologia)
                .WithMany()
                .HasForeignKey(o => o.IdPatologia);
        }
    }
}
