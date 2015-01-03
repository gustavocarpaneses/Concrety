using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
{
    public class EstruturaServicoConfiguration : EntityBaseConfiguration<EstruturaServico>
    {
        public EstruturaServicoConfiguration()
        {
            ToTable("EstruturasServico");

            Property(e => e.Nome).IsRequired();

            HasRequired(e => e.MacroServico)
                .WithMany(m => m.EstruturasServico)
                .HasForeignKey(e => e.IdMacroServico);

            HasOptional(e => e.EstruturaServicoPai)
                .WithMany()
                .HasForeignKey(e => e.IdEstruturaServicoPai);

            HasOptional(e => e.EstruturaServicoFilho)
                .WithMany()
                .HasForeignKey(e => e.IdEstruturaServicoFilho);
        }
    }
}
