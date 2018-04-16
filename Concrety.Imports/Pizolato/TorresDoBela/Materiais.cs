
using Concrety.Core.Entities;
using Concrety.Core.Entities.Enumerators;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Crosscutting.Logging;
using Concrety.Data.Context;
using Concrety.Data.UnitOfWork;
using Concrety.Identity.Models;
using Concrety.Services;
using CsvHelper;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concrety.Imports.Pizolato.TorresDoBela
{
    [TestFixture]
    public class Materiais
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
            await Criar(@"C:\Projetos\Concrety\Concrety.Imports\Pizolato\TorresDoBela\Entrada\FVM.csv").ConfigureAwait(false);
        }

        private async Task Criar(string nomeArquivo)
        {
            var fvmService = new FichaVerificacaoMaterialService(_unitOfWork);
            var itemFvmService = new ItemVerificacaoMaterialService(_unitOfWork);

            var empreendimento = (await new EmpreendimentoService(_unitOfWork).ObterPeloNomeAsync(Common.NOME_EMPREENDIMENTO).ConfigureAwait(false)).FirstOrDefault();
            var idMacroServico = empreendimento.MacrosServicos.FirstOrDefault().Id;
            var niveis = await new NivelService(_unitOfWork).ObterNiveisDoMacroServicoAsync(idMacroServico).ConfigureAwait(false);

            var nivelAnterior = string.Empty;
            var nomeFVMAnterior = string.Empty;

            EntityResultBase result = null;
            FichaVerificacaoMaterial fvm = null;
            Nivel nivel = null;

            var sr = new StreamReader(nomeArquivo, Encoding.Default);

            var linha = new
            {
                NomeFVM = "",
                DescricaoFVM = "",
                Nivel = "",
                NomeItem = "",
            };

            using (var csv = new CsvReader(sr))
            {
                csv.Configuration.Delimiter = ";";
                var records = csv.GetRecords(linha);

                foreach (var record in records)
                {
                    var nomeNivel = record.Nivel;

                    if (!string.IsNullOrWhiteSpace(nomeNivel))
                    {
                        nivel = niveis.FirstOrDefault(n => n.Nome.Equals(nomeNivel, StringComparison.InvariantCultureIgnoreCase));

                        if (nivel == null)
                        {
                            throw new ApplicationException($"Linha contém nível inválido");
                        }
                    }

                    var nomeFVMAtual = record.NomeFVM;

                    if (!string.IsNullOrWhiteSpace(nomeFVMAtual) && !string.IsNullOrWhiteSpace(nomeNivel)
                        && (nomeFVMAnterior != nomeFVMAtual || nivelAnterior != nomeNivel))
                    {
                        nomeFVMAnterior = nomeFVMAtual;
                        nivelAnterior = nomeNivel;

                        fvm = new FichaVerificacaoMaterial
                        {
                            Nome = record.NomeFVM,
                            Material = record.DescricaoFVM,
                            CriterioAceite = "",
                            Nivel = nivel
                        };

                        result = await fvmService.CriarAsync(fvm).ConfigureAwait(false);
                        Common.ValidarResult(result);
                    }

                    var itemFvs = new ItemVerificacaoMaterial
                    {
                        Nome = record.NomeItem,
                        Tipo = TipoVerificacaoMaterial.CheckBox,
                        FichaVerificacao = fvm
                    };

                    result = await itemFvmService.CriarAsync(itemFvs).ConfigureAwait(false);
                    Common.ValidarResult(result);
                }
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
