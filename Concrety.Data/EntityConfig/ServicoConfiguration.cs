using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class ServicoConfiguration : EntityBaseConfiguration<ItemVerificacao>
    {
        public ServicoConfiguration()
        {
            ToTable("Servicos");

            Property(s => s.Nome).IsRequired();
            Property(s => s.Validacao).IsRequired();

            Property(s => s.Validacao).HasMaxLength(5000);

            HasRequired(s => s.FichaVerificacaoServico)
                .WithMany(f => f.Itens)
                .HasForeignKey(s => s.IdFichaVerificacaoServico);
        }
    }
}
