using Concrety.Core.Entities;
using Concrety.Core.Entities.Enumerators;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Core.Messages;
using Concrety.Core.Queries;
using Concrety.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class ServicoUnidadeService : ServiceBase<ServicoUnidade>, IServicoUnidadeService
    {
        private IRepositoryBase<ServicoUnidade> _repository;

        public ServicoUnidadeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<ServicoUnidade>();
        }

        public async Task<ServicoUnidade> Obter(int idUnidade, int idServico)
        {
            var servicoUnidade = await Task.Factory.StartNew(() => { return _repository.Obter(idUnidade, idServico); });

            if (servicoUnidade == null)
            {
                await Criar(idUnidade, idServico);
                servicoUnidade = await Task.Factory.StartNew(() => { return _repository.Obter(idUnidade, idServico); });
            }

            return servicoUnidade;
        }

        public async Task<ServicoUnidadeResult> Salvar(ServicoUnidade servicoUnidade)
        {

            var erros = Validar(servicoUnidade);

            if (erros != null)
            {
                return await Task.Factory.StartNew(() =>
                {
                    return new ServicoUnidadeResult(erros, false, false);
                });
            }
            
            var servicoUnidadeDB = await base.ObterPeloIdAsync(servicoUnidade.Id);

            servicoUnidadeDB.DataInicio = servicoUnidade.DataInicio == DateTime.MinValue ? null : servicoUnidade.DataInicio;
            servicoUnidadeDB.DataFim = servicoUnidade.DataFim == DateTime.MinValue ? null : servicoUnidade.DataFim;
            servicoUnidadeDB.Status = servicoUnidade.Status;

            for (int iFVS = 0; iFVS < servicoUnidadeDB.FichasVerificacaoServico.Count; iFVS++)
            {
                var fvsDB = servicoUnidadeDB.FichasVerificacaoServico.ElementAt(iFVS);
                var fvs = servicoUnidade.FichasVerificacaoServico.ElementAt(iFVS);

                for (int iItem = 0; iItem < fvsDB.Itens.Count; iItem++)
                {
                    var itemDB = fvsDB.Itens.ElementAt(iItem);
                    var item = fvs.Itens.ElementAt(iItem);

                    itemDB.Resultado = item.Resultado;
                }
            }

            await base.AtualizarAsync(servicoUnidadeDB);

            return await Task.Factory.StartNew(() =>
            {
                return new ServicoUnidadeResult(
                    null,
                    true, 
                    servicoUnidade.Status == StatusServicoUnidade.Concluida);
            }); 
        }

        private IEnumerable<string> Validar(ServicoUnidade servicoUnidade)
        {
            if (servicoUnidade.Status == StatusServicoUnidade.Concluida)
            {
                if (servicoUnidade.FichasVerificacaoServico.Any(
                    f => f.Itens.Any(
                        i => i.Resultado != ResultadoServicoUnidade.Aprovado
                        &&
                        i.Resultado != ResultadoServicoUnidade.ReinspecionadoAprovado)))
                {
                    return new List<string>()
                    {
                        ServicoMessages.ATIVIDADES_PENDENTES
                    };
                }
                else if (servicoUnidade.DataFim == null || servicoUnidade.DataFim == DateTime.MinValue)
                {
                    servicoUnidade.DataFim = DateTime.Today;
                }
            }
            else
            {
                if (servicoUnidade.FichasVerificacaoServico.All(
                    f => f.Itens.All(
                        i => i.Resultado == ResultadoServicoUnidade.Aprovado
                        ||
                        i.Resultado == ResultadoServicoUnidade.ReinspecionadoAprovado)))
                {
                    servicoUnidade.Status = StatusServicoUnidade.Concluida;
                    if (servicoUnidade.DataFim == null || servicoUnidade.DataFim == DateTime.MinValue)
                    {
                        servicoUnidade.DataFim = DateTime.Today;
                    }
                }
            }

            return null;
        }

        private async Task<int> Criar(int idUnidade, int idServico)
        {
            try
            {
                UnitOfWork.BeginTransaction();

                var servicoUnidade = new ServicoUnidade
                {
                    IdServico = idServico,
                    IdUnidade = idUnidade,
                    Status = StatusServicoUnidade.NaoIniciada
                };

                _repository.Criar(servicoUnidade);

                await new FichaVerificacaoServicoUnidadeService(UnitOfWork).Criar(servicoUnidade);

                return await UnitOfWork.CommitAsync(); ;
            }
            catch
            {
                UnitOfWork.Rollback();
                throw;
            }
        }
    }
}
