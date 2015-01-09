using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class ItemVerificacaoMaterialUnidadeConfiguration : EntityBaseConfiguration<ItemVerificacaoMaterialUnidade>
    {
        public ItemVerificacaoMaterialUnidadeConfiguration()
        {
            ToTable("ItensVerificacaoMaterialUnidades");

            Property(s => s.Resultado).IsRequired();

            HasRequired(s => s.FichaVerificacaoUnidade)
                .WithMany(f => f.Itens)
                .HasForeignKey(s => s.IdFichaVerificacaoMaterialUnidade);

            HasRequired(s => s.ItemVerificacao)
                .WithMany()
                .HasForeignKey(s => s.IdItemVerificacaoMaterial);

        }
    }
}
