using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class FichaVerificacaoServicoUnidadeService : ServiceBase<FichaVerificacaoServicoUnidade>, IFichaVerificacaoServicoUnidadeService
    {

        private IRepositoryBase<FichaVerificacaoServicoUnidade> _repository;

        public FichaVerificacaoServicoUnidadeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<FichaVerificacaoServicoUnidade>();
        }

        internal async Task Criar(ServicoUnidade servicoUnidade)
        {
            var fichasVerificacaoServico = await new FichaVerificacaoServicoService(UnitOfWork).ObterDoServico(servicoUnidade.IdServico);

            foreach (var fvs in fichasVerificacaoServico.ToList())
            {
                var fvsUnidade = new FichaVerificacaoServicoUnidade
                {
                    IdServicoUnidade = servicoUnidade.Id,
                    IdFichaVerificacaoServico = fvs.Id
                };

                await base.CriarAsync(fvsUnidade);

                await new ItemVerificacaoServicoUnidadeService(UnitOfWork).Criar(fvs, fvsUnidade);
            }
        }

    }
}
