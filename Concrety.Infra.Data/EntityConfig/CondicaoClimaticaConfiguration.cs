using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
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
