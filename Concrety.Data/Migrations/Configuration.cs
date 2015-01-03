namespace Concrety.Data.Migrations
{
    using Concrety.Core.Entities;
    using Concrety.Data.Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConcretyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ConcretyContext context)
        {
            context.Set<CondicaoClimatica>().AddOrUpdate(
                c => c.Descricao,
                new CondicaoClimatica { Descricao = "Ensolarado" },
                new CondicaoClimatica { Descricao = "Nublado" },
                new CondicaoClimatica { Descricao = "Chuvoso" }
            );
        }
    }
}
