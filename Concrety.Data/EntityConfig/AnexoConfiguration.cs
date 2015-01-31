using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class AnexoConfiguration : EntityBaseConfiguration<Anexo>
    {
        public AnexoConfiguration()
        {
            ToTable("Anexos");

            Ignore(a => a.Conteudo);
        }
    }
}
