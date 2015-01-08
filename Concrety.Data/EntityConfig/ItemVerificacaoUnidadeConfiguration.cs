using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class ItemVerificacaoUnidadeConfiguration : EntityBaseConfiguration<ItemVerificacaoUnidade>
    {
        public ItemVerificacaoUnidadeConfiguration()
        {
            ToTable("ItensVerificacaoUnidades");

            Property(s => s.Resultado).IsRequired();

            HasRequired(s => s.FichaVerificacaoServicoUnidade)
                .WithMany(f => f.Itens)
                .HasForeignKey(s => s.IdFichaVerificacaoServicoUnidade);

            HasRequired(s => s.ItemVerificacao)
                .WithMany()
                .HasForeignKey(s => s.IdItemVerificacao);

        }
    }
}
