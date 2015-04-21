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

            Property(o => o.Descricao).HasColumnType("text");
            Property(o => o.Descricao).IsMaxLength();

            Property(o => o.Solucao).HasColumnType("text");
            Property(o => o.Solucao).IsMaxLength();

            HasRequired(o => o.ItemVerificacao)
                .WithMany(i => i.Ocorrencias)
                .HasForeignKey(o => o.IdItemVerificacaoUnidade);

            HasRequired(o => o.Patologia)
                .WithMany()
                .HasForeignKey(o => o.IdPatologia);
        }
    }
}
