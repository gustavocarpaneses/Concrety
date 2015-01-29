
using System.ComponentModel;
namespace Concrety.Core.Entities.Enumerators
{
    public enum StatusServicoUnidade
    {
        [Description("Não Iniciado")]
        NaoIniciada = 10,
        [Description("Em Andamento")]
        EmAndamento = 20,
        [Description("Concluído")]
        Concluida = 30
    }

    public enum ResultadoServicoUnidade
    {
        [Description("Reprovado")]
        Reprovado = 10,
        [Description("Aprovado")]    
        Aprovado = 20,
        [Description("Reinspecionado e Aprovado")]
        ReinspecionadoAprovado = 30
    }

    public enum StatusOcorrencia
    {
        [Description("Pendente")]
        Pendente = 10,
        [Description("Concluída")]
        Concluida = 20
    }

}
