﻿
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concrety.Imports.Pizolato.TorresDoBela
{
    [TestFixture]
    public class Servicos
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
        public async Task CriarEdificacoes()
        {
            //await Criar(@"C:\Projetos\Concrety - Grupo Pizolato\Formato Concrety\PES_Edificacoes.csv").ConfigureAwait(false);
        }

        [Test]
        public async Task CriarLineares()
        {
            //await Criar(@"C:\Projetos\Concrety - Grupo Pizolato\Formato Concrety\PES_Lineares.csv").ConfigureAwait(false);
        }

        [Test]
        public async Task CriarViarias()
        {
            //await Criar(@"C:\Projetos\Concrety - Grupo Pizolato\Formato Concrety\PES_Viarias.csv").ConfigureAwait(false);
        }

        private async Task Criar(string nomeArquivo)
        {
            var pesService = new ServicoService(_unitOfWork);
            var fvsService = new FichaVerificacaoServicoService(_unitOfWork);
            var itemFvsService = new ItemVerificacaoServicoService(_unitOfWork);

            var lines = File.ReadAllLines(nomeArquivo, Encoding.Default);

            var empreendimento = (await new EmpreendimentoService(_unitOfWork).ObterPeloNomeAsync(Common.NOME_EMPREENDIMENTO).ConfigureAwait(false)).FirstOrDefault();
            var idMacroServico = empreendimento.MacrosServicos.FirstOrDefault().Id;
            var niveis = await new NivelService(_unitOfWork).ObterNiveisDoMacroServicoAsync(idMacroServico).ConfigureAwait(false);

            var nomeServicoAnterior = string.Empty;

            EntityResultBase result = null;
            Servico pes = null;
            FichaVerificacaoServico fvs = null;
            Nivel nivel = null;

            for (int i = 1; i < lines.Length; i++)
            {
                var fields = lines[i].Split(';');

                if (fields.Length != 8)
                {
                    throw new ApplicationException($"Linha {i} contém {fields.Length} campos, sendo que o esperado são 8 campos");
                }

                var nomeNivel = fields[4];

                if (!string.IsNullOrWhiteSpace(nomeNivel))
                {
                    nivel = niveis.FirstOrDefault(n => n.Nome.Equals(nomeNivel, StringComparison.InvariantCultureIgnoreCase));

                    if (nivel == null)
                    {
                        throw new ApplicationException($"Linha {i} contém nível inválido");
                    }
                }

                var nomeServicoAtual = fields[0];

                if (!string.IsNullOrWhiteSpace(nomeServicoAtual) && nomeServicoAnterior != nomeServicoAtual)
                {
                    nomeServicoAnterior = nomeServicoAtual;

                    pes = new Servico
                    {
                        Nome = fields[0],
                        Descricao = fields[1],
                        Norma = "",
                        Nivel = nivel,
                        ProximoServico = null
                    };

                    result = await pesService.CriarAsync(pes).ConfigureAwait(false);
                    Common.ValidarResult(result);

                    fvs = new FichaVerificacaoServico
                    {
                        Nome = fields[2],
                        Descricao = fields[3],
                        Servico = pes
                    };

                    result = await fvsService.CriarAsync(fvs).ConfigureAwait(false);
                    Common.ValidarResult(result);
                }

                var itemFvs = new ItemVerificacaoServico
                {
                    Nome = fields[5],
                    Validacao = fields[6],
                    Descricao = fields[7],
                    FichaVerificacao = fvs
                };

                result = await itemFvsService.CriarAsync(itemFvs).ConfigureAwait(false);
                Common.ValidarResult(result);
            }
        }

        private void ValidarResult(EntityResultBase result)
        {
            if (!result.Sucesso)
            {
                throw new ApplicationException(String.Join(",", result.Erros));
            }
        }
    }
}
