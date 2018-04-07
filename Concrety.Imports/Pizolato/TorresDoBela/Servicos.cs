
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
        public async Task Criar()
        {
            var lines = File.ReadAllLines(@"C:\Projetos\Concrety - Grupo Pizolato\Formato Concrety\PES.csv", Encoding.Default);

            var empreendimento = (await new EmpreendimentoService(_unitOfWork).ObterPeloNomeAsync(Common.NOME_EMPREENDIMENTO).ConfigureAwait(false)).FirstOrDefault();
            var idMacroServico = empreendimento.MacrosServicos.FirstOrDefault().Id;
            var niveis = await new NivelService(_unitOfWork).ObterNiveisDoMacroServicoAsync(idMacroServico).ConfigureAwait(false);

            for (int i=1; i<= lines.Length; i++)
            {
                var fields = lines[i].Split('\t');

                if(fields.Length != 8)
                {
                    throw new ApplicationException($"Linha {i} contém {fields.Length} campos, sendo que o esperado são 8 campos");
                }

                var nomeNivel = fields[4];

                var nivel = niveis.FirstOrDefault(n => n.Nome.Equals(nomeNivel, StringComparison.InvariantCultureIgnoreCase));

                var servico = new Servico
                {
                    
                };
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
