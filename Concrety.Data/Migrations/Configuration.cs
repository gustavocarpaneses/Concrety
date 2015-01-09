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

            var fvm01 = new FichaVerificacaoMaterial
            {
                CriterioAceite = "",
                Material = "Material 01",
                Nome = "FVM 01"
            };

            var fvm02 = new FichaVerificacaoMaterial
            {
                CriterioAceite = "",
                Material = "Material 02",
                Nome = "FVM 02"
            };

            var fvs01 = new FichaVerificacaoServico
            {
                Nome = "FVS 01",
                Descricao = "Verificação 1",
                Itens = new[] 
                {
                    new ItemVerificacaoServico
                    { 
                        Nome = "Verificar 01", 
                        Validacao = "Validar 01", 
                        Patologias = new []
                        {
                            new Patologia
                            {
                                Nome = "Patologia 01",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 01", Norma = "Norma 01" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 02",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 02", Norma = "Norma 02" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 03",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 03", Norma = "Norma 03" }
                                }
                            }
                        }
                    },
                    new ItemVerificacaoServico
                    { 
                        Nome = "Verificar 02", 
                        Validacao = "Validar 02", 
                        Patologias = new []
                        {
                            new Patologia
                            {
                                Nome = "Patologia 01",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 01", Norma = "Norma 01" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 02",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 02", Norma = "Norma 02" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 03",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 03", Norma = "Norma 03" }
                                }
                            }
                        }
                    },
                    new ItemVerificacaoServico
                    { 
                        Nome = "Verificar 03", 
                        Validacao = "Validar 03", 
                        Patologias = new []
                        {
                            new Patologia
                            {
                                Nome = "Patologia 01",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 01", Norma = "Norma 01" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 02",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 02", Norma = "Norma 02" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 03",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 03", Norma = "Norma 03" }
                                }
                            }
                        }
                    }
                }
            };

            var fvs02 = new FichaVerificacaoServico
            {
                Nome = "FVS 02",
                Descricao = "Verificação 2",
                Itens = new[] 
                {
                    new ItemVerificacaoServico
                    { 
                        Nome = "Verificar 01", 
                        Validacao = "Validar 01", 
                        Patologias = new []
                        {
                            new Patologia
                            {
                                Nome = "Patologia 01",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 01", Norma = "Norma 01" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 02",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 02", Norma = "Norma 02" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 03",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 03", Norma = "Norma 03" }
                                }
                            }
                        }
                    },
                    new ItemVerificacaoServico
                    { 
                        Nome = "Verificar 02", 
                        Validacao = "Validar 02", 
                        Patologias = new []
                        {
                            new Patologia
                            {
                                Nome = "Patologia 01",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 01", Norma = "Norma 01" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 02",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 02", Norma = "Norma 02" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 03",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 03", Norma = "Norma 03" }
                                }
                            }
                        }
                    },
                    new ItemVerificacaoServico
                    { 
                        Nome = "Verificar 03", 
                        Validacao = "Validar 03", 
                        Patologias = new []
                        {
                            new Patologia
                            {
                                Nome = "Patologia 01",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 01", Norma = "Norma 01" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 02",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 02", Norma = "Norma 02" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 03",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 03", Norma = "Norma 03" }
                                }
                            }
                        }
                    }
                }
            };

            var fvs03 = new FichaVerificacaoServico
            {
                Nome = "FVS 01",
                Descricao = "Verificação 3",
                Itens = new[] 
                {
                    new ItemVerificacaoServico
                    { 
                        Nome = "Verificar 01", 
                        Validacao = "Validar 01", 
                        Patologias = new []
                        {
                            new Patologia
                            {
                                Nome = "Patologia 01",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 01", Norma = "Norma 01" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 02",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 02", Norma = "Norma 02" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 03",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 03", Norma = "Norma 03" }
                                }
                            }
                        }
                    },
                    new ItemVerificacaoServico
                    { 
                        Nome = "Verificar 02", 
                        Validacao = "Validar 02", 
                        Patologias = new []
                        {
                            new Patologia
                            {
                                Nome = "Patologia 01",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 01", Norma = "Norma 01" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 02",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 02", Norma = "Norma 02" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 03",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 03", Norma = "Norma 03" }
                                }
                            }
                        }
                    },
                    new ItemVerificacaoServico
                    { 
                        Nome = "Verificar 03", 
                        Validacao = "Validar 03", 
                        Patologias = new []
                        {
                            new Patologia
                            {
                                Nome = "Patologia 01",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 01", Norma = "Norma 01" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 02",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 02", Norma = "Norma 02" }
                                }
                            },
                            new Patologia
                            {
                                Nome = "Patologia 03",
                                Solucoes = new []
                                {
                                    new Solucao { Nome = "Solução 03", Norma = "Norma 03" }
                                }
                            }
                        }
                    }
                }
            };

            var pes01 = new Servico
            {
                Nome = "PES 01",
                Norma = "",
                Descricao = "Serviço 1",
                FichasVerificacaoServico = new[] { fvs01 }
            };

            var pes02 = new Servico
            {
                Nome = "PES 02",
                Norma = "",
                Descricao = "Serviço 2",
                FichasVerificacaoServico = new[] { fvs02 }
            };

            var pes03 = new Servico
            {
                Nome = "PES 03",
                Norma = "",
                Descricao = "Serviço 3",
                FichasVerificacaoServico = new[] { fvs03 }
            };

            var nivelUnidade = new Nivel
            {
                Nome = "Unidade",
                Servicos = new[] 
                {
                    pes02,
                    pes03
                }
            };

            var nivelBloco = new Nivel
            {
                Nome = "Bloco",
                NivelFilho = nivelUnidade
            };

            var nivelObra = new Nivel
            {
                Nome = "Obra",
                NivelFilho = nivelBloco,
                FichasVerificacaoMaterial = new[] 
                {
                    fvm01,
                    fvm02
                },
                Servicos = new[] 
                {
                    pes01
                }
            };

            var macroServico = new MacroServico
            {
                Nome = "Unidades Habitacionais",
                Niveis = new[] { 
                    nivelObra,
                    nivelBloco,
                    nivelUnidade
                }
            };

            var dataInicio = DateTime.Today;
            var dataFim = DateTime.Today.AddYears(1);

            var empreendimentos = new[]
            {
                new Empreendimento { Nome = "Empreendimento 01", DataInicioConstrucao = dataInicio, DataFimConstrucao = dataFim, MacrosServicos = new [] { macroServico } },
                new Empreendimento { Nome = "Empreendimento 02", DataInicioConstrucao = dataInicio, DataFimConstrucao = dataFim },
                new Empreendimento { Nome = "Empreendimento 03", DataInicioConstrucao = dataInicio, DataFimConstrucao = dataFim }
            };

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
