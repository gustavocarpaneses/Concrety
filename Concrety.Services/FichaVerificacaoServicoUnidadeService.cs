using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        internal async Task<ICollection<FichaVerificacaoServicoUnidade>> Criar(ServicoUnidade servicoUnidade)
        {
            var fichasVerificacaoServico = await new FichaVerificacaoServicoService(UnitOfWork).ObterDoServico(servicoUnidade.IdServico);
            var fichasVerificacaoServicoUnidade = new List<FichaVerificacaoServicoUnidade>();

            foreach (var fvs in fichasVerificacaoServico.ToList())
            {
                var fvsUnidade = new FichaVerificacaoServicoUnidade
                {
                    IdServicoUnidade = servicoUnidade.Id,
                    IdFichaVerificacaoServico = fvs.Id
                };

                _repository.Add(fvsUnidade);

                fvsUnidade.FichaVerificacaoServico = fvs;
                fvsUnidade.Itens = await new ItemVerificacaoServicoUnidadeService(UnitOfWork).Criar(fvs, fvsUnidade);

                fichasVerificacaoServicoUnidade.Add(fvsUnidade);
            }

            return fichasVerificacaoServicoUnidade;
        }

    }
}
