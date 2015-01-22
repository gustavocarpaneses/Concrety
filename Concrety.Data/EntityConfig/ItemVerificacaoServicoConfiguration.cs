using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class ItemVerificacaoServicoConfiguration : EntityBaseConfiguration<ItemVerificacaoServico>
    {
        public ItemVerificacaoServicoConfiguration()
        {
            ToTable("ItensVerificacaoServico");

            Property(s => s.Nome).IsRequired();
            Property(s => s.Validacao).IsRequired();

            Property(s => s.Validacao).HasMaxLength(5000);

            HasRequired(s => s.FichaVerificacao)
                .WithMany(f => f.Itens)
                .HasForeignKey(s => s.IdFichaVerificacaoServico);
        }
    }
}
