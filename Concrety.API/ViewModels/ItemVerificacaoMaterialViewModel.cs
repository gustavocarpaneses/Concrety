
using Concrety.Core.Entities.Enumerators;
namespace Concrety.API.ViewModels
{
    public class ItemVerificacaoMaterialViewModel
    {
        public int Id { get; set; }

        public int IdFichaVerificacaoMaterial { get; set; }

        public string Nome { get; set; }
        public TipoVerificacaoMaterial Tipo { get; set; }
    }
}