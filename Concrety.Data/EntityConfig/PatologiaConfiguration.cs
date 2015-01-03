﻿using Concrety.Domain.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class PatologiaConfiguration : EntityBaseConfiguration<Patologia>
    {
        public PatologiaConfiguration()
        {
            ToTable("Patologias");

            Property(p => p.Nome).IsRequired();
        }
    }
}