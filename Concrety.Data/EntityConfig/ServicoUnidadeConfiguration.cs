using Concrety.Domain.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class ServicoUnidadeConfiguration : EntityBaseConfiguration<ServicoUnidade>
    {
        public ServicoUnidadeConfiguration()
        {
            ToTable("ServicosUnidades");

            Property(s => s.Resultado).IsRequired();

            HasRequired(s => s.FichaVerificacaoServicoUnidade)
                .WithMany(f => f.Servicos)
                .HasForeignKey(s => s.IdFichaVerificacaoServicoUnidade);

            HasRequired(s => s.Servico)
                .WithMany()
                .HasForeignKey(s => s.IdServico);

        }
    }
}
