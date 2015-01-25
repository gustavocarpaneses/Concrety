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
    public class FichaVerificacaoMaterialUnidadeService : ServiceBase<FichaVerificacaoMaterialUnidade>, IFichaVerificacaoMaterialUnidadeService
    {
        private IRepositoryBase<FichaVerificacaoMaterialUnidade> _repository;

        public FichaVerificacaoMaterialUnidadeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<FichaVerificacaoMaterialUnidade>();
        }

        public async Task<IEnumerable<FichaVerificacaoMaterialUnidade>> ObterDaUnidade(int idUnidade)
        {
            return await Task.Factory.StartNew(() => { return _repository.ObterDaUnidade(idUnidade); });
        }


        public async Task<EntityResultBase> Criar(FichaVerificacaoMaterialUnidade fvm)
        {
            var erros = await Validar(fvm);

            if (erros != null)
            {
                return await Task.Factory.StartNew(() =>
                {
                    return new EntityResultBase(erros, false);
                });
            }

            await base.AddAsync(fvm);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }

        public async Task<EntityResultBase> Atualizar(FichaVerificacaoMaterialUnidade fvm)
        {
            var erros = await Validar(fvm);

            if (erros != null)
            {
                return await Task.Factory.StartNew(() =>
                {
                    return new EntityResultBase(erros, false);
                });
            }

            await base.UpdateAsync(fvm);

            return await Task.Factory.StartNew(() =>
            {
                return new EntityResultBase(
                    null,
                    true);
            });
        }

        private async Task<IEnumerable<string>> Validar(FichaVerificacaoMaterialUnidade fvm)
        {
            return null;
        }
    }
}
