using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class FichaVerificacaoMaterialUnidadeConfiguration : EntityBaseConfiguration<FichaVerificacaoMaterialUnidade>
    {
        public FichaVerificacaoMaterialUnidadeConfiguration()
        {
            ToTable("FichasVerificacaoMaterialUnidades");

            Property(f => f.Data).IsRequired();
            Property(f => f.AmostraValidacao).IsRequired();
            Property(f => f.Aprovado).IsRequired();
            Property(f => f.NotaFiscal).IsRequired();
            Property(f => f.NumeroPedido).IsRequired();
            Property(f => f.QuantidadeTotal).IsRequired();

            HasRequired(f => f.Unidade)
                .WithMany(u => u.FichasVerificacaoMaterial)
                .HasForeignKey(f => f.IdUnidade);

            HasRequired(f => f.Fornecedor)
                .WithMany()
                .HasForeignKey(f => f.IdFornecedor);

            HasRequired(f => f.FichaVerificacaoMaterial)
                .WithMany()
                .HasForeignKey(f => f.IdFichaVerificacaoMaterial);

        }
    }
}
