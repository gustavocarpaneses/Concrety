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
    public class EmailService : IEmailService
    {

        //private IRepositoryBase<EmpreendimentoDiario> _repository;

        //public EmailService(IUnitOfWork unitOfWork)
        //    : base(unitOfWork)
        //{
        //    _repository = UnitOfWork.Repository<EmpreendimentoDiario>();
        //}

        //public async Task<EntityResultBase> Criar(EmpreendimentoDiario empreendimentoDiario)
        //{

        //    var erros = await Validar(empreendimentoDiario);

        //    if (erros != null)
        //    {
        //        return await Task.Factory.StartNew(() =>
        //        {
        //            return new EntityResultBase(erros, false);
        //        });
        //    }

        //    await base.AddAsync(empreendimentoDiario);

        //    return await Task.Factory.StartNew(() =>
        //    {
        //        return new EntityResultBase(
        //            null,
        //            true);
        //    });
        //}
        
        //private async Task<IEnumerable<string>> Validar(EmpreendimentoDiario empreendimentoDiario)
        //{

        //    empreendimentoDiario.Data = empreendimentoDiario.Data.Date;

        //    var existeNaData = await Task.Factory.StartNew(() => 
        //    {
        //        return _repository.ExisteNaData(empreendimentoDiario.IdEmpreendimento, empreendimentoDiario.Id, empreendimentoDiario.Data);
        //    });

        //    if (existeNaData)
        //    {
        //        return new List<string>()
        //        {
        //            EmpreendimentoDiarioMessages.JA_EXISTE_DIARIO_NA_DATA
        //        };
        //    }

        //    return null;
        //}

        public async Task<EntityResultBase> EnviarEmailFeedback(EmailFeedback emailFeedback)
        {
            throw new NotImplementedException();
        }
    }
}
