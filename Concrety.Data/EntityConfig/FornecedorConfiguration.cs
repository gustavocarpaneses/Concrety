using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
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
