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
                .WithOptionalDependent(n => n.NivelFilho)
                .Map(_ => _.MapKey("IdNivelPai"));
        }
    }
}
