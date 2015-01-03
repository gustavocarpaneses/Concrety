using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
{
    public class ServicoConfiguration : EntityBaseConfiguration<Servico>
    {
        public ServicoConfiguration()
        {
            ToTable("Servicos");

            Property(s => s.Nome).IsRequired();
            Property(s => s.Validacao).IsRequired();

            Property(s => s.Validacao).HasMaxLength(5000);

            HasRequired(s => s.FichaVerificacaoServico)
                .WithMany(f => f.Servicos)
                .HasForeignKey(s => s.IdFichaVerificacaoServico);
        }
    }
}
