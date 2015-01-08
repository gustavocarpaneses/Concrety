using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class NivelConfiguration : EntityBaseConfiguration<Nivel>
    {
        public NivelConfiguration()
        {
            ToTable("Niveis");

            Property(n => n.Nome).IsRequired();

            HasRequired(n => n.MacroServico)
                .WithMany(m => m.Niveis)
                .HasForeignKey(n => n.IdMacroServico);

            HasOptional(n => n.NivelPai)
                .WithMany()
                .HasForeignKey(n => n.IdNivelPai);

            HasOptional(n => n.NivelFilho)
                .WithMany()
                .HasForeignKey(n => n.IdNivelFilho);
        }
    }
}
