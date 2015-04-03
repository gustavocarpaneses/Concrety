using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class EmpreendimentoDiarioConfiguration : EntityBaseConfiguration<EmpreendimentoDiario>
    {
        public EmpreendimentoDiarioConfiguration()
        {
            ToTable("EmpreendimentoDiarios");

            Property(d => d.Data).IsRequired();
            
            Property(d => d.ServicosExecutados).HasColumnType("text");
            Property(d => d.ServicosExecutados).IsMaxLength();

            HasRequired(d => d.Empreendimento)
                .WithMany(e => e.Diarios)                
                .HasForeignKey(d => d.IdEmpreendimento);
        }
    }
}
