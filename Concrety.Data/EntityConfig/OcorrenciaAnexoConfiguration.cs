using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class OcorrenciaAnexoConfiguration : EntityBaseConfiguration<OcorrenciaAnexo>
    {
        public OcorrenciaAnexoConfiguration()
        {
            ToTable("OcorrenciasAnexos");

            HasRequired(oa => oa.Ocorrencia)
                .WithMany(o => o.Anexos)
                .HasForeignKey(oa => oa.IdOcorrencia);

            HasRequired(oa => oa.Anexo)
                .WithMany()
                .HasForeignKey(oa => oa.IdAnexo);
        }
    }
}
