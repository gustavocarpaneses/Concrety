using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class UnidadeConfiguration : EntityBaseConfiguration<Unidade>
    {
        public UnidadeConfiguration()
        {
            ToTable("Unidades");

            Property(u => u.Nome).IsRequired();

            HasRequired(u => u.Nivel)
                .WithMany(n => n.Unidades)
                .HasForeignKey(u => u.IdNivel);

            HasOptional(u => u.UnidadePai)
                .WithMany(u => u.SubUnidades)
                .HasForeignKey(u => u.IdUnidadePai);

        }
    }
}
