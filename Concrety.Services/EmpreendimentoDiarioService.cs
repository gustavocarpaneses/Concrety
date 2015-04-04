using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Core.Messages;
using Concrety.Core.Queries;
using Concrety.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class EmpreendimentoDiarioService : ServiceBase<EmpreendimentoDiario>, IEmpreendimentoDiarioService
    {

        private IRepositoryBase<EmpreendimentoDiario> _repository;

        public EmpreendimentoDiarioService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<EmpreendimentoDiario>();
            base.ValidarAsync = ValidarAsync;
            base.PreCriar = PreCriar;
            base.PreAtualizar = PreAtualizar;
        }

        public async Task<IEnumerable<EmpreendimentoDiario>> ObterDoEmpreendimentoAsync(int idEmpreendimento)
        {
            return await Task.Factory.StartNew(() => { return _repository.ObterDoEmpreendimento(idEmpreendimento); });
        }
        
        private new async Task<IEnumerable<string>> ValidarAsync(EmpreendimentoDiario empreendimentoDiario)
        {
            empreendimentoDiario.Data = DateTime.SpecifyKind(empreendimentoDiario.Data.Date, DateTimeKind.Unspecified);

            var existeNaData = await Task.Factory.StartNew(() => 
            {
                return _repository.ExisteNaData(empreendimentoDiario.IdEmpreendimento, empreendimentoDiario.Id, empreendimentoDiario.Data);
            });

            if (existeNaData)
            {
                return new List<string>()
                {
                    EmpreendimentoDiarioMessages.JA_EXISTE_DIARIO_NA_DATA
                };
            }

            return null;
        }

        private new void PreCriar(EmpreendimentoDiario diario)
        {
            foreach (var periodo in diario.DiariosPeriodos)
            {
                periodo.EmpreendimentoPeriodo = null;
            }
        }

        private new void PreAtualizar(EmpreendimentoDiario diario)
        {
            new EmpreendimentoDiarioPeriodoService(UnitOfWork).Atualizar(diario);
        }

    }
}
