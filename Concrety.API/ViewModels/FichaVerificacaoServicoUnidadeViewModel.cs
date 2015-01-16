using System.Collections.Generic;

namespace Concrety.API.ViewModels
{
    public class FichaVerificacaoServicoUnidadeViewModel
    {

        public virtual FichaVerificacaoServicoViewModel FichaVerificacaoServico { get; set; }

        public virtual ICollection<ItemVerificacaoServicoUnidadeViewModel> Itens { get; set; }

    }
}