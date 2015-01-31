using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

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
                .WithMany(i => i.Ocorrencias)
                .HasForeignKey(o => o.IdItemVerificacaoUnidade);

            HasRequired(o => o.Patologia)
                .WithMany()
                .HasForeignKey(o => o.IdPatologia);

            HasMany(o => o.Anexos)
                .WithMany()
                .Map(o => o
                    .ToTable("OcorrenciasAnexos")
                    .MapLeftKey("IdOcorrencia")
                    .MapRightKey("IdAnexo"));
        }
    }
}
