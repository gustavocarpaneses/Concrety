using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class OcorrenciaService : ServiceBase<Ocorrencia>, IOcorrenciaService
    {
        private IRepositoryBase<Ocorrencia> _repository;
        private IRepositoryBase<ItemVerificacaoServicoUnidade> _itemVerificacaoServicoUnidadeRepository;
        private IRepositoryBase<FichaVerificacaoServicoUnidade> _fichaVerificacaoServicoUnidadeRepository;
        private IRepositoryBase<ServicoUnidade> _servicoUnidadeRepository;
        private IRepositoryBase<Servico> _servicoRepository;
        private IRepositoryBase<Nivel> _nivelRepository;

        public OcorrenciaService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<Ocorrencia>();
            _itemVerificacaoServicoUnidadeRepository = UnitOfWork.Repository<ItemVerificacaoServicoUnidade>();
            _fichaVerificacaoServicoUnidadeRepository = UnitOfWork.Repository<FichaVerificacaoServicoUnidade>();
            _servicoUnidadeRepository = UnitOfWork.Repository<ServicoUnidade>();
            _servicoRepository = UnitOfWork.Repository<Servico>();
            _nivelRepository = UnitOfWork.Repository<Nivel>();
        }


        public async Task<EntityResultBase> Criar(Ocorrencia ocorrencia)
        {

            var erros = await Validar(ocorrencia);

            if (erros != null)
            {
                return await Task.Factory.StartNew(() =>
                {
                    return new EntityResultBase(erros, false);
                });
            }

            await base.AddAsync(ocorrencia);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }

        public async Task<EntityResultBase> Atualizar(Ocorrencia ocorrencia)
        {

            var erros = await Validar(ocorrencia);

            if (erros != null)
            {
                return await Task.Factory.StartNew(() =>
                {
                    return new EntityResultBase(erros, false);
                });
            }

            await base.UpdateAsync(ocorrencia);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }


        private async Task<IEnumerable<string>> Validar(Ocorrencia ocorrencia)
        {
            ocorrencia.ItemVerificacao = null;
            ocorrencia.Patologia = null;

            return null;
        }


        public async Task<IEnumerable<Ocorrencia>> ObterDoServicoUnidade(int idServicoUnidade)
        {
            return await Task.Factory.StartNew(() =>
            {
                return _repository.ObterDoServicoUnidade(
                    _itemVerificacaoServicoUnidadeRepository.GetQuery(),
                    _fichaVerificacaoServicoUnidadeRepository.GetQuery(),
                    idServicoUnidade);
            });
        }


        public async Task<IEnumerable<Ocorrencia>> ObterPendentes(int idMacroServico)
        {
            return await Task.Factory.StartNew(() =>
            {
                return _repository.ObterPendentes(
                    _itemVerificacaoServicoUnidadeRepository.GetQuery(),
                    _fichaVerificacaoServicoUnidadeRepository.GetQuery(),
                    _servicoUnidadeRepository.GetQuery(),
                    _servicoRepository.GetQuery(),
                    _nivelRepository.GetQuery(),
                    idMacroServico);
            });
        }
    }
}
