using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class CondicaoClimaticaConfiguration : EntityBaseConfiguration<CondicaoClimatica>
    {
        public CondicaoClimaticaConfiguration()
        {
            ToTable("CondicoesClimaticas");

            Property(c => c.Descricao).IsRequired();
        }
    }
}
