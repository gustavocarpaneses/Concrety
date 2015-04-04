using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Core.Queries;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class EmpreendimentoDiarioPeriodoService : ServiceBase<EmpreendimentoDiarioPeriodo>, IEmpreendimentoDiarioPeriodoService
    {

        private IRepositoryBase<EmpreendimentoDiarioPeriodo> _repository;
        private IRepositoryBase<EmpreendimentoPeriodo> _empreendimentoPeriodoRepository;

        public EmpreendimentoDiarioPeriodoService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<EmpreendimentoDiarioPeriodo>();
            _empreendimentoPeriodoRepository = UnitOfWork.Repository<EmpreendimentoPeriodo>();
        }

        public async Task<IEnumerable<EmpreendimentoDiarioPeriodo>> ObterPeriodosDoEmpreendimentoAsync(int idEmpreendimento)
        {
            var periodos = await Task.Factory.StartNew(() => { return _empreendimentoPeriodoRepository.ObterDoEmpreendimento(idEmpreendimento); });

            var diariosPeriodos = new List<EmpreendimentoDiarioPeriodo>();

            foreach (var periodo in periodos)
            {
                diariosPeriodos.Add(new EmpreendimentoDiarioPeriodo
                {
                    IdEmpreendimentoPeriodo = periodo.Id,
                    EmpreendimentoPeriodo = periodo
                });
            }

            return diariosPeriodos;
        }
        
        internal void Atualizar(EmpreendimentoDiario diario)
        {
            foreach (var periodo in diario.DiariosPeriodos)
            {
                _repository.Atualizar(periodo);
            }
        }
    }
}
