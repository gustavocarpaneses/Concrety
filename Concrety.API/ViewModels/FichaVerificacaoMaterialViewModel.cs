
using System.Collections.Generic;
namespace Concrety.API.ViewModels
{
    public class FichaVerificacaoMaterialViewModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Material { get; set; }
        public string CriterioAceite { get; set; }

        public string NomeCompleto
        {
            get
            {
                return Nome + " - " + Material;
            }
        }

        public ICollection<ItemVerificacaoMaterialViewModel> Itens { get; set; }
    }
}
