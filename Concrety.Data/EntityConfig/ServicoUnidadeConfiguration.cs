using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class ServicoUnidadeConfiguration : EntityBaseConfiguration<ServicoUnidade>
    {
        public ServicoUnidadeConfiguration()
        {
            ToTable("ServicosUnidades");

            Property(s => s.DataInicio).IsRequired();
            Property(s => s.Status).IsRequired();

            HasRequired(s => s.Servico)
                .WithMany()
                .HasForeignKey(s => s.IdServico);

            HasRequired(s => s.Unidade)
                .WithMany(u => u.Servicos)
                .HasForeignKey(s => s.IdUnidade);
        }
    }
}
