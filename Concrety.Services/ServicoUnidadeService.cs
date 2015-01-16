using Concrety.Core.Entities;
using Concrety.Core.Entities.Enumerators;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                servicoUnidade = await Criar(idUnidade, idServico);
            }

            return servicoUnidade;
        }

        private async Task<ServicoUnidade> Criar(int idUnidade, int idServico)
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
                
                _repository.Add(servicoUnidade);

                servicoUnidade.FichasVerificacaoServico = await new FichaVerificacaoServicoUnidadeService(UnitOfWork).Criar(servicoUnidade);

                UnitOfWork.Commit();

                return servicoUnidade;
            }
            catch
            {
                UnitOfWork.Rollback();
                throw;
            }
        }
    }
}
