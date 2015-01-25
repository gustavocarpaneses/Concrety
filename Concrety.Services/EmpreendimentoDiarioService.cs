using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Core.Messages;
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
        }

        public async Task<IEnumerable<EmpreendimentoDiario>> ObterDoEmpreendimento(int idEmpreendimento)
        {
            return await Task.Factory.StartNew(() => { return _repository.ObterDoEmpreendimento(idEmpreendimento); });
        }


        public async Task<EntityResultBase> Criar(EmpreendimentoDiario empreendimentoDiario)
        {

            var erros = await Validar(empreendimentoDiario);

            if (erros != null)
            {
                return await Task.Factory.StartNew(() =>
                {
                    return new EntityResultBase(erros, false);
                });
            }

            await base.AddAsync(empreendimentoDiario);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }
        
        public async Task<EntityResultBase> Atualizar(EmpreendimentoDiario empreendimentoDiario)
        {

            var erros = await Validar(empreendimentoDiario);

            if (erros != null)
            {
                return await Task.Factory.StartNew(() =>
                {
                    return new EntityResultBase(erros, false);
                });
            }

            await base.UpdateAsync(empreendimentoDiario);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }

        private async Task<IEnumerable<string>> Validar(EmpreendimentoDiario empreendimentoDiario)
        {

            //para eliminar qualquer informação de hora/minuto/segundo
            empreendimentoDiario.Data = new DateTime(
                empreendimentoDiario.Data.Year,
                empreendimentoDiario.Data.Month,
                empreendimentoDiario.Data.Day);

            var existeNaData = await Task.Factory.StartNew(() => 
            {
                return _repository.ExisteNaData(empreendimentoDiario.IdEmpreendimento, empreendimentoDiario.Data);
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
    }
}
