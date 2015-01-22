using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class PatologiaConfiguration : EntityBaseConfiguration<Patologia>
    {
        public PatologiaConfiguration()
        {
            ToTable("Patologias");

            Property(p => p.Nome).IsRequired();

            HasRequired(p => p.ItemVerificacao)
                .WithMany(s => s.Patologias)
                .HasForeignKey(p => p.IdItemVerificacaoServico);

        }
    }
}
