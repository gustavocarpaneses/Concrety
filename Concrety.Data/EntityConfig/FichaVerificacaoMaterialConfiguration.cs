using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class FichaVerificacaoMaterialConfiguration : EntityBaseConfiguration<FichaVerificacaoMaterial>
    {
        public FichaVerificacaoMaterialConfiguration()
        {
            ToTable("FichasVerificacaoMaterial");

            Property(f => f.Data).IsRequired();
            Property(f => f.Status).IsRequired();

            HasRequired(f => f.Unidade)
                .WithMany(u => u.FichasVerificacaoMaterial)
                .HasForeignKey(f => f.IdUnidade);

            HasRequired(f => f.Material)
                .WithMany()
                .HasForeignKey(f => f.IdMaterial);

            HasRequired(f => f.Fornecedor)
                .WithMany()
                .HasForeignKey(f => f.IdFornecedor);

        }
    }
}
