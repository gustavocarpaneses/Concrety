
using Concrety.Core.Entities.Enumerators;
namespace Concrety.API.ViewModels
{
    public class ItemVerificacaoMaterialUnidadeViewModel
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }

        public int IdFichaVerificacaoMaterialUnidade { get; set; }

        public int IdItemVerificacaoMaterial { get; set; }

        public string Resultado { get; set; }

        public virtual ItemVerificacaoMaterialViewModel ItemVerificacao { get; set; }
    }
}