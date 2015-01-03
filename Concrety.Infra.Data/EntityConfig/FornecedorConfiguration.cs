using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
{
    public class FornecedorConfiguration : EntityBaseConfiguration<Fornecedor>
    {
        public FornecedorConfiguration()
        {
            ToTable("Fornecedores");

            Property(f => f.Nome).IsRequired();
        }
    }
}
