using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class ItemVerificacaoMaterialUnidadeService : ServiceBase<ItemVerificacaoMaterialUnidade>, IItemVerificacaoMaterialUnidadeService
    {

        private IRepositoryBase<ItemVerificacaoMaterialUnidade> _repository;

        public ItemVerificacaoMaterialUnidadeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<ItemVerificacaoMaterialUnidade>();
        }

        internal void Atualizar(FichaVerificacaoMaterialUnidade fvmUnidade)
        {
            foreach (var item in fvmUnidade.Itens)
            {
                _repository.Update(item);
            }
        }

    }
}
