using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class AnexoConfiguration : EntityBaseConfiguration<Anexo>
    {
        public AnexoConfiguration()
        {
            ToTable("Anexos");

            Property(a => a.Extensao).HasMaxLength(10);

            Ignore(a => a.Conteudo);
            Ignore(a => a.ContentType);
        }
    }
}
