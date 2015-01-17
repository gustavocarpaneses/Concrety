
using Concrety.Core.Entities.Enumerators;
namespace Concrety.API.ViewModels
{
    public class ItemVerificacaoServicoUnidadeViewModel
    {
        public int Id { get; set; }

        public int IdFichaVerificacaoServicoUnidade { get; set; }

        public int IdItemVerificacaoServico { get; set; }

        public ResultadoServicoUnidade? Resultado { get; set; }
        public int QuantidadeOcorrencias { get; set; }

        public virtual ItemVerificacaoServicoViewModel ItemVerificacao { get; set; }
    }
}