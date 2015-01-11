
using System.Collections.Generic;
namespace Concrety.API.ViewModels
{
    public class EmpreendimentoViewModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<MacroServicoViewModel> MacrosServicos { get; set; }

    }
}