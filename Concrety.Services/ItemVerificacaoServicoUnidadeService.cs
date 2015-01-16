using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Concrety.Core.Interfaces.Repositories;

namespace Concrety.Services
{
    public class ItemVerificacaoServicoUnidadeService : ServiceBase<ItemVerificacaoServicoUnidade>, IItemVerificacaoServicoUnidadeService
    {

        private IRepositoryBase<ItemVerificacaoServicoUnidade> _repository;

        public ItemVerificacaoServicoUnidadeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<ItemVerificacaoServicoUnidade>();
        }

        internal async Task<ICollection<ItemVerificacaoServicoUnidade>> Criar(FichaVerificacaoServico fvs, FichaVerificacaoServicoUnidade fvsUnidade)
        {
            var itensVerificacaoServicoUnidade = new List<ItemVerificacaoServicoUnidade>();

            foreach (var item in fvs.Itens.Where(i => i.Ativo && !i.Excluido))
            {
                var itemFvsUnidade = new ItemVerificacaoServicoUnidade
                {
                    IdFichaVerificacaoServicoUnidade = fvsUnidade.Id,
                    IdItemVerificacaoServico = item.Id
                };

                _repository.Add(itemFvsUnidade);

                itemFvsUnidade.ItemVerificacao = item;
                itensVerificacaoServicoUnidade.Add(itemFvsUnidade);
            }

            return itensVerificacaoServicoUnidade;
        }

    }
}
