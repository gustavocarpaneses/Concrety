namespace Concrety.Data.Migrations
{
    using Concrety.Core.Entities;
    using Concrety.Data.Context;
    using Concrety.Identity;
    using Concrety.Identity.Models;
    using System;
    using System.Data.Entity.Migrations;

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

            var dataInicio = DateTime.Today;
            var dataFim = DateTime.Today.AddYears(1);

            var empreendimentos = new []
            {
                new Empreendimento { Nome = "Empreendimento 01", DataInicioConstrucao = dataInicio, DataFimConstrucao = dataFim },
                new Empreendimento { Nome = "Empreendimento 02", DataInicioConstrucao = dataInicio, DataFimConstrucao = dataFim },
                new Empreendimento { Nome = "Empreendimento 03", DataInicioConstrucao = dataInicio, DataFimConstrucao = dataFim }
            };

            //context.Set<Empreendimento>().AddOrUpdate(
            //    e => e.Nome,
            //    empreendimentos);

            var userManager = IdentityFactory.CreateUserManager(context);

            context.Users.AddOrUpdate(
                u => u.UserName,
                new ApplicationIdentityUser
                {
                    UserName = "gcarpane@gmail.com",
                    Email = "gcarpane@gmail.com",
                    PasswordHash = userManager.PasswordHasher.HashPassword("Teste@123"),
                    Empreendimentos = empreendimentos
                });
        }
    }
}
