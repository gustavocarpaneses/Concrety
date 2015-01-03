using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
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
