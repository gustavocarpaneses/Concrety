using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class MacroServicoConfiguration : EntityBaseConfiguration<MacroServico>
    {
        public MacroServicoConfiguration()
        {
            ToTable("MacroServicos");

            Property(m => m.Nome).IsRequired();

            HasRequired(m => m.Empreendimento)
                .WithMany(e => e.MacrosServicos)
                .HasForeignKey(m => m.IdEmpreendimento);
        }
    }
}
