using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class ItemVerificacaoMaterialConfiguration : EntityBaseConfiguration<ItemVerificacaoMaterial>
    {
        public ItemVerificacaoMaterialConfiguration()
        {
            ToTable("ItensVerificacaoMaterial");

            Property(s => s.Nome).IsRequired();
            Property(s => s.Tipo).IsRequired();

            HasRequired(s => s.FichaVerificacao)
                .WithMany(f => f.Itens)
                .HasForeignKey(s => s.IdFichaVerificacaoMaterial);
        }
    }
}
