using System.Collections.Generic;

namespace Concrety.API.ViewModels
{
    public class FichaVerificacaoServicoUnidadeViewModel
    {

        public int Id { get; set; }

        public int IdServicoUnidade { get; set; }

        public int IdFichaVerificacaoServico { get; set; }

        public virtual FichaVerificacaoServicoViewModel FichaVerificacaoServico { get; set; }

        public virtual ICollection<ItemVerificacaoServicoUnidadeViewModel> Itens { get; set; }

    }
}