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
            Property(a => a.Tipo).HasMaxLength(50);

            Ignore(a => a.Conteudo);
        }
    }
}
