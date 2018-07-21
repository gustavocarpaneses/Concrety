
using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Crosscutting.Logging;
using Concrety.Data.AWS;
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
    public class NormasServicos
    {
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void SetUp()
        {
            var connectionString = "Server=concrety.cybxdszlpy8b.us-east-1.rds.amazonaws.com,1433;Database=concrety_prod;User ID=concrety.sql;Password=Construcao@123;Trusted_Connection=False;Encrypt=False;Connection Timeout=30;";
            _unitOfWork = new UnitOfWork(
                new ConcretyContext(connectionString, NLogLogger.Instance),
                new ApplicationIdentityUser
                {
                    Id = 1
                });
        }

        [Test]
        public async Task Atualizar()
        {
            var pesService = new ServicoService(_unitOfWork);

            var empreendimento = (await new EmpreendimentoService(_unitOfWork).ObterPeloNomeAsync(Common.NOME_EMPREENDIMENTO).ConfigureAwait(false)).FirstOrDefault();
            var idMacroServico = empreendimento.MacrosServicos.FirstOrDefault().Id;
            var niveis = (await new NivelService(_unitOfWork).ObterNiveisDoMacroServicoAsync(idMacroServico).ConfigureAwait(false)).ToList();

            var nivelAnterior = string.Empty;
            var nomeServicoAnterior = string.Empty;

            var diretorioPDFs = @"C:\Projetos\Concrety - Grupo Pizolato\Formato Concrety\PDFs";
            var arquivosPDFs = Directory.GetFiles(diretorioPDFs);

            EntityResultBase result;

            foreach(var nivel in niveis.ToList())
            {
                var servicos = (await pesService.ObterDoNivelAsync(nivel.Id).ConfigureAwait(false)).ToList();

                foreach(var servico in servicos)
                {
                    if(servico.Nome.StartsWith(" "))
                    {
                        servico.Nome = servico.Nome.Trim();
                        result = await pesService.AtualizarAsync(servico).ConfigureAwait(false);
                        ValidarResult(result);
                    }

                    if (!String.IsNullOrWhiteSpace(servico.Norma))
                        continue;

                    try
                    {
                        var caminhoPdf = arquivosPDFs.FirstOrDefault(x => x.Contains(servico.Nome.Replace("/", "")));

                        if(String.IsNullOrWhiteSpace(caminhoPdf))
                        {
                            caminhoPdf = arquivosPDFs.FirstOrDefault(x => x.Contains(servico.Nome.Replace("/", " ")));

                            if (String.IsNullOrWhiteSpace(caminhoPdf))
                            {
                                caminhoPdf = arquivosPDFs.FirstOrDefault(x => x.Contains(servico.Nome.Replace("/", "-")));

                                if (String.IsNullOrWhiteSpace(caminhoPdf))
                                {

                                }
                            }
                        }

                        var anexo = new Anexo
                        {
                            IdObra = empreendimento.Id,
                            NomeArquivoUpload = caminhoPdf,
                            NomeBlob = Path.GetFileName(caminhoPdf),
                            Tipo = "application/pdf"
                        };
                        await new BlobManager().UploadAsync(anexo).ConfigureAwait(false);

                        servico.Norma = anexo.UrlPrimaria;

                        result = await pesService.AtualizarAsync(servico).ConfigureAwait(false);
                        ValidarResult(result);
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
        }

        private void ValidarResult(EntityResultBase result)
        {
            if (!result.Sucesso)
            {
                throw new ApplicationException(String.Join(", ", result.Erros));
            }
        }
    }
}
