namespace Concrety.Data.Migrations
{
    using Concrety.Core.Entities;
    using Concrety.Data.Context;
    using Concrety.Identity.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConcretyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConcretyContext context)
        {
            context.Set<CondicaoClimatica>().AddOrUpdate(
                c => c.Descricao,
                new CondicaoClimatica { Descricao = "Ensolarado" },
                new CondicaoClimatica { Descricao = "Nublado" },
                new CondicaoClimatica { Descricao = "Chuvoso" }
            );

            context.Roles.AddOrUpdate(
                r => r.Name,
                new ApplicationIdentityRole { Name = "Engenheiro Calculista" },
                new ApplicationIdentityRole { Name = "Engenheiro de Campo" },
                new ApplicationIdentityRole { Name = "Gerente de projeto" },
                new ApplicationIdentityRole { Name = "Financeiro/Administrativo" }
            );
        }
    }
}
