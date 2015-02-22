using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Core.Queries;
using Concrety.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class OcorrenciaService : ServiceBase<Ocorrencia>, IOcorrenciaService
    {
        private IRepositoryBase<Ocorrencia> _repository;
        private IRepositoryBase<OcorrenciaAnexo> _ocorrenciaAnexoRepository;
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
            _ocorrenciaAnexoRepository = UnitOfWork.Repository<OcorrenciaAnexo>();

            base.ValidarAsync = ValidarAsync;
            base.PreAtualizar = PreAtualizar;
            base.PreCriar = PreCriar;
        }
        
        private new void PreCriar(Ocorrencia ocorrencia)
        {
            //remove anexos que foram excluídos antes da ocorrência ser salva
            ocorrencia.Anexos = ocorrencia.Anexos.Where(oa => !oa.Excluido).ToList();
        }

        private new void PreAtualizar(Ocorrencia ocorrencia)
        {
            foreach (var ocorrenciaAnexo in ocorrencia.Anexos)
            {
                if (ocorrenciaAnexo.Id == 0)
                {
                    _ocorrenciaAnexoRepository.Criar(ocorrenciaAnexo);
                }
            }
        }

        private new async Task<IEnumerable<string>> ValidarAsync(Ocorrencia ocorrencia)
        {
            ocorrencia.ItemVerificacao = null;
            ocorrencia.Patologia = null;

            ocorrencia.DataAbertura = ocorrencia.DataAbertura.Date;
            if (ocorrencia.DataConclusao.HasValue)
            {
                ocorrencia.DataConclusao = ocorrencia.DataConclusao.Value.Date;
            }

            foreach (var ocorrenciaAnexo in ocorrencia.Anexos)
            {
                ocorrenciaAnexo.Anexo = null;
            }
            
            return null;
        }
        
        public async Task<IEnumerable<Ocorrencia>> ObterDoServicoUnidadeAsync(int idServicoUnidade)
        {
            return await Task.Factory.StartNew(() =>
            {
                return _repository.ObterDoServicoUnidade(
                    _itemVerificacaoServicoUnidadeRepository.ObterQuery(),
                    _fichaVerificacaoServicoUnidadeRepository.ObterQuery(),
                    idServicoUnidade);
            });
        }


        public async Task<IEnumerable<Ocorrencia>> ObterPendentesAsync(int idMacroServico)
        {
            return await Task.Factory.StartNew(() =>
            {
                return _repository.ObterPendentes(
                    _itemVerificacaoServicoUnidadeRepository.ObterQuery(),
                    _fichaVerificacaoServicoUnidadeRepository.ObterQuery(),
                    _servicoUnidadeRepository.ObterQuery(),
                    _servicoRepository.ObterQuery(),
                    _nivelRepository.ObterQuery(),
                    idMacroServico);
            });
        }
    }
}
