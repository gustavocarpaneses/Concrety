﻿using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Concrety.Core.Entities.Enumerators;

namespace Concrety.Services
{
    public class ServicoService : ServiceBase<Servico>, IServicoService
    {
        private IRepositoryBase<Servico> _servicoRepository;
        private IRepositoryBase<ServicoUnidade> _servicoUnidadeRepository;

        public ServicoService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _servicoRepository = UnitOfWork.Repository<Servico>();
            _servicoUnidadeRepository = UnitOfWork.Repository<ServicoUnidade>();
        }

        public async Task<IEnumerable<Servico>> ObterDaUnidade(int idUnidade, int idNivel)
        {
            var servicos = await Task.Factory.StartNew(() => { return _servicoRepository.ObterDoNivel(idNivel); });

            Servico servicoAtual = null;
            var servicoUnidadeAtual = await Task.Factory.StartNew(() => { return _servicoUnidadeRepository.ObterAtualDaUnidade(idUnidade); });

            if (servicoUnidadeAtual == null)
            {
                servicoAtual = servicos.First();
            }
            else
            {
                if (servicoUnidadeAtual.Status == StatusServicoUnidade.Concluida
                    &&
                    servicoUnidadeAtual.Servico.ProximoServico != null)
                {
                    servicoAtual = servicoUnidadeAtual.Servico.ProximoServico;
                }
                else
                {
                    servicoAtual = servicoUnidadeAtual.Servico;
                }
            }

            servicos.Single(s => s.Id == servicoAtual.Id).Atual = true;

            var proximoServico = servicoAtual.ProximoServico;

            while (proximoServico != null)
            {
                servicos.Single(s => s.Id == proximoServico.Id).Desabilitado = true;
                proximoServico = proximoServico.ProximoServico;
            }

            return servicos;            
        }
    }
}
