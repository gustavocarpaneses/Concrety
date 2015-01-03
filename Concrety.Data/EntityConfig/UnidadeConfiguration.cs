using Concrety.Domain.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class UnidadeConfiguration : EntityBaseConfiguration<Unidade>
    {
        public UnidadeConfiguration()
        {
            ToTable("Unidades");

            Property(u => u.Nome).IsRequired();

            HasRequired(u => u.EstruturaServico)
                .WithMany(e => e.Unidades)
                .HasForeignKey(u => u.IdEstruturaServico);

            HasOptional(u => u.UnidadePai)
                .WithMany(u => u.SubUnidades)
                .HasForeignKey(u => u.IdUnidadePai);

        }
    }
}
