
using Concrety.Core.Entities.Dashboard;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using System;
using System.Threading.Tasks;
namespace Concrety.Services
{
    public class DashboardService : IDashboardService
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        private bool _disposed;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<GraficoLinha<int, DateTime>> ObterTotalDeFuncionariosPorDia(int idEmpreendimento)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                UnitOfWork.Dispose();
            }
            _disposed = true;
        }
    }
}
