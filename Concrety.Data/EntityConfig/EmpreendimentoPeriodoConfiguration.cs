using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class EmpreendimentoPeriodoConfiguration : EntityBaseConfiguration<EmpreendimentoPeriodo>
    {
        public EmpreendimentoPeriodoConfiguration()
        {
            ToTable("EmpreendimentoPeriodos");

            Property(p => p.Nome).IsRequired();
            
            HasRequired(d => d.Empreendimento)
                .WithMany(e => e.Periodos)                
                .HasForeignKey(d => d.IdEmpreendimento);
        }
    }
}
