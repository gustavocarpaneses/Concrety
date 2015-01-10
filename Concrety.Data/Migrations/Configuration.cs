namespace Concrety.Data.Migrations
{
    using Concrety.Core.Entities;
    using Concrety.Core.Entities.Enumerators;
    using Concrety.Core.Interfaces.Logging;
    using Concrety.Data.Context;
    using Concrety.Identity;
    using Concrety.Identity.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConcretyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConcretyContext context)
        {

            var userManager = IdentityFactory.CreateUserManager(context);

            var usuario = new ApplicationIdentityUser
            {
                UserName = "gcarpane@gmail.com",
                Email = "gcarpane@gmail.com",
                PasswordHash = userManager.PasswordHasher.HashPassword("Teste@123")
            };

            context.Users.AddOrUpdate(
                u => u.UserName,
                usuario);
            context.SaveChanges();

            context.Set<Fornecedor>().AddOrUpdate(
                f => f.Nome,
                new Fornecedor { Ativo = true, Nome = "Fornecedor 01", IdUsuarioCadastro = usuario.Id },
                new Fornecedor { Ativo = true, Nome = "Fornecedor 02", IdUsuarioCadastro = usuario.Id }
            );

            context.Set<CondicaoClimatica>().AddOrUpdate(
                c => c.Descricao,
                new CondicaoClimatica { Ativo = true, Descricao = "Ensolarado", IdUsuarioCadastro = usuario.Id },
                new CondicaoClimatica { Ativo = true, Descricao = "Nublado", IdUsuarioCadastro = usuario.Id },
                new CondicaoClimatica { Ativo = true, Descricao = "Chuvoso", IdUsuarioCadastro = usuario.Id }
            );

            var dataInicio = DateTime.Today;
            var dataFim = DateTime.Today.AddYears(1);

            var empreendimentos = new[]
            {
                new Empreendimento { Nome = "Obra 1", Ativo = true, DataInicioConstrucao = dataInicio, DataFimConstrucao = dataFim, IdUsuarioCadastro = usuario.Id },
                new Empreendimento { Nome = "Obra 2", Ativo = true, DataInicioConstrucao = dataInicio, DataFimConstrucao = dataFim, IdUsuarioCadastro = usuario.Id },
                new Empreendimento { Nome = "Obra 3", Ativo = true, DataInicioConstrucao = dataInicio, DataFimConstrucao = dataFim, IdUsuarioCadastro = usuario.Id }
            };

            context.Set<Empreendimento>().AddOrUpdate(
                e => e.Nome,
                empreendimentos);

            context.SaveChanges();

            usuario.Empreendimentos = empreendimentos;
            context.SaveChanges();

            foreach (var obra in empreendimentos)
            {

                var macroServico = new MacroServico
                {
                    Nome = "Unidades Habitacionais do " + obra.Nome,
                    Ativo = true,
                    IdEmpreendimento = obra.Id,
                    IdUsuarioCadastro = usuario.Id
                };

                context.Set<MacroServico>().AddOrUpdate(
                    m => m.Nome,
                    macroServico);

                var nivelObra = new Nivel
                {
                    Ativo = true,
                    Nome = "Obra (" + macroServico.Nome + ")",
                    IdMacroServico = macroServico.Id,
                    IdUsuarioCadastro = usuario.Id
                };

                var nivelBloco = new Nivel
                {
                    Ativo = true,
                    Nome = "Bloco (" + macroServico.Nome + ")",
                    IdMacroServico = macroServico.Id,
                    NivelPai = nivelObra,
                    IdUsuarioCadastro = usuario.Id
                };

                var nivelUnidade = new Nivel
                {
                    Ativo = true,
                    Nome = "Unidade (" + macroServico.Nome + ")",
                    IdMacroServico = macroServico.Id,
                    NivelPai = nivelBloco,
                    IdUsuarioCadastro = usuario.Id
                };

                context.Set<Nivel>().AddOrUpdate(
                    n => n.Nome,
                    nivelObra,
                    nivelBloco,
                    nivelUnidade);

                context.SaveChanges();

                var unidadeObra = new Unidade
                {
                    Ativo = true,
                    IdNivel = nivelObra.Id,
                    Nome = obra.Nome,
                    IdUsuarioCadastro = usuario.Id
                };

                context.Set<Unidade>().AddOrUpdate(
                    u => u.Nome,
                    unidadeObra);

                context.SaveChanges();
                
                for (int iBloco = 1; iBloco <= 3; iBloco++)
                {
                    var unidadeBloco = new Unidade
                    {
                        Ativo = true,
                        IdUsuarioCadastro = usuario.Id,
                        IdUnidadePai = unidadeObra.Id,
                        IdNivel = nivelBloco.Id,
                        Nome = unidadeObra.Nome + " - Bloco 0" + iBloco
                    };

                    context.Set<Unidade>().AddOrUpdate(
                        u => u.Nome,
                        unidadeBloco);
                    context.SaveChanges();

                    for (int iUnidade = 1; iUnidade <= 9; iUnidade++)
                    {
                        var unidadeUnidade = new Unidade
                        {
                            Ativo = true,
                            IdUsuarioCadastro = usuario.Id,
                            IdUnidadePai = unidadeBloco.Id,
                            IdNivel = nivelUnidade.Id,
                            Nome = unidadeBloco.Nome + " - Unidade 0" + iUnidade
                        };

                        context.Set<Unidade>().AddOrUpdate(
                            u => u.Nome,
                            unidadeUnidade);
                        context.SaveChanges();
                    }
                }

                for (int iPES = 1; iPES <= 3; iPES++)
                {

                    var servico = new Servico
                    {
                        Ativo = true,
                        Nome = "PES 0" + iPES + " (" + macroServico.Nome + ")",
                        Norma = "Norma da PES 0" + iPES,
                        Descricao = "Serviço " + iPES,
                        IdUsuarioCadastro = usuario.Id
                    };

                    if (iPES == 1)
                    {
                        servico.IdNivel = nivelObra.Id;
                    }
                    else
                    {
                        servico.IdNivel = nivelUnidade.Id;
                    }

                    context.Set<Servico>().AddOrUpdate(
                        s => s.Nome,
                        servico);
                    context.SaveChanges();

                    var fvs = new FichaVerificacaoServico
                    {
                        Ativo = true,
                        Nome = "FVS 0" + iPES + " (" + macroServico.Nome + ")",
                        Descricao = "Verificação " + iPES,
                        IdServico = servico.Id,
                        IdUsuarioCadastro = usuario.Id
                    };

                    context.Set<FichaVerificacaoServico>().AddOrUpdate(
                        f => f.Nome,
                        fvs);
                    context.SaveChanges();

                    for (int iItem = 1; iItem <= 3; iItem++)
                    {

                        var item = new ItemVerificacaoServico
                        {
                            Ativo = true,
                            Nome = fvs.Nome + " - Item " + iItem,
                            Validacao = fvs.Nome + " - Verificar Item " + iItem,
                            IdFichaVerificacaoServico = fvs.Id,
                            IdUsuarioCadastro = usuario.Id
                        };

                        context.Set<ItemVerificacaoServico>().AddOrUpdate(
                            i => i.Nome,
                            item);
                        context.SaveChanges();

                        for (int iPatologia = 1; iPatologia <= 3; iPatologia++)
                        {
                            var patologia = new Patologia
                            {
                                Ativo = true,
                                Nome = item.Nome + " - Patologia 0" + iPatologia,
                                IdItemVerificacaoServico = item.Id,
                                IdUsuarioCadastro = usuario.Id
                            };

                            context.Set<Patologia>().AddOrUpdate(
                                p => p.Nome,
                                patologia);
                            context.SaveChanges();

                            var solucao = new Solucao
                            {
                                Ativo = true,
                                Nome = "Solução da Patologia " + patologia.Nome,
                                Descricao = "Aplicar Norma da Solução da Patologia " + patologia.Nome,
                                Norma = "Norma da Solução da Patologia " + patologia.Nome,
                                IdPatologia = patologia.Id,
                                IdUsuarioCadastro = usuario.Id
                            };

                            context.Set<Solucao>().AddOrUpdate(
                                s => s.Nome,
                                solucao);
                            context.SaveChanges();

                        }
                    }
                }

                for (int iFVM = 1; iFVM <= 3; iFVM++)
                {
                    var fvm = new FichaVerificacaoMaterial
                    {
                        Ativo = true,
                        CriterioAceite = "",
                        Material = "Material 0" + iFVM,
                        Nome = "FVM 0" + iFVM + " (" + macroServico.Nome + ")",
                        IdNivel = nivelObra.Id,
                        IdUsuarioCadastro = usuario.Id
                    };

                    context.Set<FichaVerificacaoMaterial>().AddOrUpdate(
                        f => f.Nome,
                        fvm);
                    context.SaveChanges();

                    for (int iItem = 1; iItem <= 3; iItem++)
                    {
                        var itemFVM = new ItemVerificacaoMaterial
                        {
                            Ativo = true,
                            IdFichaVerificacaoMaterial = fvm.Id,
                            Nome = fvm.Nome + " Item 0" + iItem,
                            Tipo = TipoVerificacaoMaterial.Texto,
                            IdUsuarioCadastro = usuario.Id
                        };

                        context.Set<ItemVerificacaoMaterial>().AddOrUpdate(
                            f => f.Nome,
                            itemFVM);
                        context.SaveChanges();
                    }
                }

            }

        }
    }

}
