using Concrety.Domain.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

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
