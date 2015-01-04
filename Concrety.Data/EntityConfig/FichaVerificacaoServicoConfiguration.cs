﻿using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class FichaVerificacaoServicoConfiguration : EntityBaseConfiguration<FichaVerificacaoServico>
    {
        public FichaVerificacaoServicoConfiguration()
        {
            ToTable("FichasVerificacaoServico");

            Property(f => f.Nome).IsRequired();
        }
    }
}
