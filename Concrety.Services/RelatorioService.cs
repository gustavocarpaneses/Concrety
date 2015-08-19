
using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Concrety.Services
{
    public class RelatorioService : ServiceBase<Relatorio>, IRelatorioService
    {
        private IRepositoryBase<Relatorio> _repository;

        public RelatorioService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<Relatorio>();
        }

        public Task<IEnumerable<object[]>> ObterAsync(int id, params object[] parametros)
        {
            var relatorio = _repository.ObterPeloId(id);

            var query = relatorio.Query;

            return UnitOfWork.ExecuteSqlQueryAsync(query, parametros);
        }
    }
}
