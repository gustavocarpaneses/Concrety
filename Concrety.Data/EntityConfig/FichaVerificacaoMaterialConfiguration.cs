using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class FichaVerificacaoMaterialConfiguration : EntityBaseConfiguration<FichaVerificacaoMaterial>
    {
        public FichaVerificacaoMaterialConfiguration()
        {
            ToTable("FichasVerificacaoMaterial");

            Property(f => f.CriterioAceite).IsRequired();
            Property(f => f.Material).IsRequired();
            Property(f => f.Nome).IsRequired();

            HasRequired(f => f.Nivel)
                .WithMany(n => n.FichasVerificacaoMaterial)
                .HasForeignKey(f => f.IdNivel);
        }
    }
}
