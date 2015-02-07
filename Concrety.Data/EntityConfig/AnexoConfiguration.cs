using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class AnexoConfiguration : EntityBaseConfiguration<Anexo>
    {
        public AnexoConfiguration()
        {
            ToTable("Anexos");

            Property(a => a.UrlPrimaria).HasMaxLength(500);
            Property(a => a.UrlSecundaria).HasMaxLength(500);

            Ignore(a => a.IdObra);
            Ignore(a => a.NomeArquivoUpload);
            Ignore(a => a.Tipo);
        }
    }
}
