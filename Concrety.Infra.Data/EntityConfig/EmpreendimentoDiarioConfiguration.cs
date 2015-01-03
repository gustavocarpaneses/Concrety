﻿using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Infra.Data.EntityConfig
{
    public class EmpreendimentoDiarioConfiguration : EntityBaseConfiguration<EmpreendimentoDiario>
    {
        public EmpreendimentoDiarioConfiguration()
        {
            ToTable("EmpreendimentoDiarios");

            Property(d => d.Data).IsRequired();

            Property(d => d.ServicosExecutados).HasColumnType("text");

            HasRequired(d => d.Empreendimento)
                .WithMany(e => e.Diarios)                
                .HasForeignKey(d => d.IdEmpreendimento);
        }
    }
}
