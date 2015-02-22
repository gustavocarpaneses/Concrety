using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Core.Queries;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class FichaVerificacaoMaterialUnidadeService : ServiceBase<FichaVerificacaoMaterialUnidade>, IFichaVerificacaoMaterialUnidadeService
    {
        private IRepositoryBase<FichaVerificacaoMaterialUnidade> _repository;
        private IRepositoryBase<ItemVerificacaoMaterial> _itemVerificacaoMaterialRepository;
        private IRepositoryBase<ItemVerificacaoMaterialUnidade> _itemVerificacaoMaterialUnidadeRepository;

        public FichaVerificacaoMaterialUnidadeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<FichaVerificacaoMaterialUnidade>();
            _itemVerificacaoMaterialRepository = UnitOfWork.Repository<ItemVerificacaoMaterial>();
            _itemVerificacaoMaterialUnidadeRepository = UnitOfWork.Repository<ItemVerificacaoMaterialUnidade>();

            base.PreAtualizar = PreAtualizar;
        }

        public async Task<IEnumerable<FichaVerificacaoMaterialUnidade>> ObterDaUnidade(int idUnidade)
        {
            return await Task.Factory.StartNew(() => { return _repository.ObterDaUnidade(idUnidade); });
        }
        
        public new async Task<EntityResultBase> CriarAsync(FichaVerificacaoMaterialUnidade fvm)
        {
            foreach (var item in fvm.Itens)
            {
                item.ItemVerificacao = null;
            }

            return await base.CriarAsync(fvm);
        }

        public async Task<IEnumerable<ItemVerificacaoMaterialUnidade>> ObterItens(int idFichaVerificacaoMaterialUnidade)
        {
            return await Task.Factory.StartNew(() => 
            { 
                return _itemVerificacaoMaterialUnidadeRepository.ObterDaFichaVerificacaoMaterialUnidade(idFichaVerificacaoMaterialUnidade); 
            });
        }
        
        public async Task<IEnumerable<ItemVerificacaoMaterialUnidade>> CriarItens(int idFichaVerificacaoMaterial)
        {
            var itens = await Task.Factory.StartNew(() => { return _itemVerificacaoMaterialRepository.ObterDaFichaVerificacaoMaterial(idFichaVerificacaoMaterial); });

            var itensUnidade = new List<ItemVerificacaoMaterialUnidade>();

            foreach (var item in itens)
            {
                itensUnidade.Add(new ItemVerificacaoMaterialUnidade
                {
                    IdItemVerificacaoMaterial = item.Id,
                    ItemVerificacao = item
                });
            }

            return itensUnidade;

        }

        private void PreAtualizar(FichaVerificacaoMaterialUnidade fvm)
        {
            new ItemVerificacaoMaterialUnidadeService(UnitOfWork).Atualizar(fvm);
        }

    }
}
