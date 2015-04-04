using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class EmpreendimentoDiarioPeriodoConfiguration : EntityBaseConfiguration<EmpreendimentoDiarioPeriodo>
    {
        public EmpreendimentoDiarioPeriodoConfiguration()
        {
            ToTable("EmpreendimentoDiariosPeriodos");

            HasRequired(d => d.EmpreendimentoDiario)
                .WithMany(d => d.DiariosPeriodos)                
                .HasForeignKey(d => d.IdEmpreendimentoDiario);

            HasRequired(d => d.EmpreendimentoPeriodo)
                .WithMany()
                .HasForeignKey(d => d.IdEmpreendimentoPeriodo);

            HasOptional(d => d.CondicaoClimatica)
                .WithMany()
                .HasForeignKey(d => d.IdCondicaoClimatica);
        }
    }
}
