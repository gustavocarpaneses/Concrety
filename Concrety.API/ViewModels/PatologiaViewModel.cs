using System.Collections.Generic;

namespace Concrety.API.ViewModels
{
    public class PatologiaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<SolucaoViewModel> Solucoes { get; set; }
    }
}
