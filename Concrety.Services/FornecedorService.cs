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
    public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
    {

        private IRepositoryBase<Fornecedor> _repository;

        public FornecedorService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<Fornecedor>();
        }

        public async Task<IEnumerable<Fornecedor>> Obter()
        {
            return await Task.Factory.StartNew(() => { return _repository.Obter(); });
        }
    }
}
