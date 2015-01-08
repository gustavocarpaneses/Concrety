using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class EstruturaServicoConfiguration : EntityBaseConfiguration<Nivel>
    {
        public EstruturaServicoConfiguration()
        {
            ToTable("EstruturasServico");

            Property(e => e.Nome).IsRequired();

            HasRequired(e => e.MacroServico)
                .WithMany(m => m.EstruturasServico)
                .HasForeignKey(e => e.IdMacroServico);

            HasOptional(e => e.NivelPai)
                .WithMany()
                .HasForeignKey(e => e.IdNivelPai);

            HasOptional(e => e.NivelFilho)
                .WithMany()
                .HasForeignKey(e => e.IdNivelFilho);
        }
    }
}
