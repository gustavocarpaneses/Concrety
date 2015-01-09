﻿using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class ItemVerificacaoServicoUnidadeConfiguration : EntityBaseConfiguration<ItemVerificacaoServicoUnidade>
    {
        public ItemVerificacaoServicoUnidadeConfiguration()
        {
            ToTable("ItensVerificacaoServicoUnidades");

            Property(s => s.Resultado).IsRequired();

            HasRequired(s => s.FichaVerificacaoUnidade)
                .WithMany(f => f.Itens)
                .HasForeignKey(s => s.IdFichaVerificacaoServicoUnidade);

            HasRequired(s => s.ItemVerificacao)
                .WithMany()
                .HasForeignKey(s => s.IdItemVerificacaoServico);

        }
    }
}