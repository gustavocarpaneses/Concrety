
using Concrety.Core.Entities.Dashboard;
using System;
using System.Threading.Tasks;
namespace Concrety.Core.Interfaces.Services
{
    public interface IDashboardService : IServiceBase
    {
        Task<GraficoLinha<int, DateTime>> ObterTotalDeFuncionariosPorDia(int idEmpreendimento);
    }
}
