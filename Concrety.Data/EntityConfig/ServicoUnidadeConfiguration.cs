﻿using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class ServicoUnidadeConfiguration : EntityBaseConfiguration<ItemVerificacaoUnidade>
    {
        public ServicoUnidadeConfiguration()
        {
            ToTable("ServicosUnidades");

            Property(s => s.Resultado).IsRequired();

            HasRequired(s => s.FichaVerificacaoServicoUnidade)
                .WithMany(f => f.Itens)
                .HasForeignKey(s => s.IdFichaVerificacaoServicoUnidade);

            HasRequired(s => s.ItemVerificacao)
                .WithMany()
                .HasForeignKey(s => s.IdItemVerificacao);

        }
    }
}
