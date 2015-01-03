using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class EmpreendimentoConfiguration : EntityBaseConfiguration<Empreendimento>
    {
        public EmpreendimentoConfiguration()
        {
            ToTable("Empreendimentos");

            Property(e => e.Nome).IsRequired();

            Property(e => e.Numero).HasMaxLength(10);
            Property(e => e.Complemento).HasMaxLength(50);
            Property(e => e.CEP).HasMaxLength(8);
            Property(e => e.Estado).HasMaxLength(2);

        }
    }
}
