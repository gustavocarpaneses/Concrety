
using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Crosscutting.Logging;
using Concrety.Data.Context;
using Concrety.Data.UnitOfWork;
using Concrety.Identity.Models;
using Concrety.Services;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Concrety.Imports.Pizolato.TorresDoBela
{
    [TestFixture]
    public class Unidades
    {
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void SetUp()
        {
            var connectionString = "Server=tcp:concrety.database.windows.net,1433;Database=Concrety;User ID=concrety.sql;Password=Construcao@123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            _unitOfWork = new UnitOfWork(
                new ConcretyContext(connectionString, NLogLogger.Instance),
                new ApplicationIdentityUser
                {
                    Id = 1
                });
        }

        [Test]
        public async Task Criar()
        {
            //await CriarObraAsync().ConfigureAwait(false);
        }

        private async Task CriarObraAsync()
        {
            var empreendimento = new Empreendimento()
            {
                Nome = Common.NOME_EMPREENDIMENTO,
                DataInicioConstrucao = new DateTime(2018, 04, 01),
                DataFimConstrucao = new DateTime(2018, 12, 31)
            };

            var result = await new EmpreendimentoService(_unitOfWork).CriarAsync(empreendimento).ConfigureAwait(false);
            Common.ValidarResult(result);

            var macroServico = new MacroServico()
            {
                Nome = "Unidades Habitacionais",
                IdEmpreendimento = empreendimento.Id
            };

            result = await new MacroServicoService(_unitOfWork).CriarAsync(macroServico).ConfigureAwait(false);
            Common.ValidarResult(result);

            await CriarNiveisAsync(macroServico);
        }

        private async Task CriarNiveisAsync(MacroServico macroServico)
        {
            var nivelService = new NivelService(_unitOfWork);

            var nivelObra = new Nivel()
            {
                Nome = "Obra",
                IdMacroServico = macroServico.Id
            };

            var result = await nivelService.CriarAsync(nivelObra).ConfigureAwait(false);
            Common.ValidarResult(result);

            var nivelBloco = new Nivel()
            {
                Nome = "Bloco",
                IdMacroServico = macroServico.Id,
                NivelPai = nivelObra
            };

            result = await nivelService.CriarAsync(nivelBloco).ConfigureAwait(false);
            Common.ValidarResult(result);

            var nivelPavimento = new Nivel()
            {
                Nome = "Pavimento",
                IdMacroServico = macroServico.Id,
                NivelPai = nivelBloco
            };

            result = await nivelService.CriarAsync(nivelPavimento).ConfigureAwait(false);
            Common.ValidarResult(result);

            var nivelApartamento = new Nivel()
            {
                Nome = "Apartamento",
                IdMacroServico = macroServico.Id,
                NivelPai = nivelPavimento
            };

            result = await nivelService.CriarAsync(nivelApartamento).ConfigureAwait(false);
            Common.ValidarResult(result);

            await CriarUnidadesAsync(nivelObra, nivelBloco, nivelPavimento, nivelApartamento).ConfigureAwait(false);
        }

        private async Task CriarUnidadesAsync(Nivel nivelObra, Nivel nivelBloco, Nivel nivelPavimento, Nivel nivelApartamento)
        {
            var unidadeService = new UnidadeService(_unitOfWork);

            var unidadeObra = new Unidade()
            {
                Nome = "Torres do Bela",
                Nivel = nivelObra
            };

            var result = await unidadeService.CriarAsync(unidadeObra).ConfigureAwait(false);
            Common.ValidarResult(result);

            for (int indexBloco = 1; indexBloco <= 13; indexBloco++)
            {
                var unidadeBloco = new Unidade()
                {
                    Nome = $"Bloco {indexBloco}",
                    Nivel = nivelBloco,
                    UnidadePai = unidadeObra
                };

                result = await unidadeService.CriarAsync(unidadeBloco).ConfigureAwait(false);
                Common.ValidarResult(result);

                for (int indexPavimento = 0; indexPavimento <= 3; indexPavimento++)
                {
                    var unidadePavimento = new Unidade()
                    {
                        Nome = indexPavimento == 0 ? "Térreo" : $"{indexPavimento}º Andar",
                        Nivel = nivelPavimento,
                        UnidadePai = unidadeBloco
                    };

                    result = await unidadeService.CriarAsync(unidadePavimento).ConfigureAwait(false);
                    Common.ValidarResult(result);

                    for (int indexApartamento = 1; indexApartamento <= 4; indexApartamento++)
                    {
                        var unidadeApartamento = new Unidade()
                        {
                            Nome = $"{indexPavimento + 1}{indexApartamento}",
                            Nivel = nivelApartamento,
                            UnidadePai = unidadePavimento
                        };

                        result = await unidadeService.CriarAsync(unidadeApartamento).ConfigureAwait(false);
                        Common.ValidarResult(result);
                    }
                }
            }
        }
    }
}
