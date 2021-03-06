﻿using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class FichaVerificacaoMaterialConfiguration : EntityBaseConfiguration<FichaVerificacaoMaterial>
    {
        public FichaVerificacaoMaterialConfiguration()
        {
            ToTable("FichasVerificacaoMaterial");

            Property(f => f.CriterioAceite).IsRequired().HasColumnType("varchar(max)");

            Property(f => f.Material).IsRequired();
            Property(f => f.Nome).IsRequired();

            HasRequired(f => f.Nivel)
                .WithMany(n => n.FichasVerificacaoMaterial)
                .HasForeignKey(f => f.IdNivel);
        }
    }
}
