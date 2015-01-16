
using Concrety.Core.Entities.Enumerators;
namespace Concrety.API.ViewModels
{
    public class ItemVerificacaoServicoUnidadeViewModel
    {
        public ResultadoServicoUnidade Resultado { get; set; }
        public int QuantidadeOcorrencias { get; set; }

        public virtual ItemVerificacaoServicoViewModel ItemVerificacao { get; set; }
    }
}