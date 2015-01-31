using Concrety.Core.Entities.Enumerators;
using System;

namespace Concrety.API.ViewModels
{
    public class OcorrenciaViewModel
    {

        public int Id { get; set; }
        public bool Ativo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataAbertura { get; set; }
        public DateTime? DataConclusao { get; set; }

        public string DescricaoStatus { get; set; }
        public StatusOcorrencia Status { get; set; }

        public string NomeFichaVerificacaoServico { get; set; }
        public string NomeItemVerificacaoServico { get; set; }
        public string NomePatologia { get; set; }
        public string NomeUnidade { get; set; }

        public virtual ItemVerificacaoServicoUnidadeViewModel ItemVerificacao { get; set; }
        public int IdItemVerificacaoUnidade { get; set; }

        public virtual PatologiaViewModel Patologia { get; set; }
        public int IdPatologia { get; set; }

        //TODO: Decidir entre armazenar as Imagens em Blob ou algum serviço de Streaming
        //public virtual ICollection<string> Evidencias { get; set; }
        //public virtual ICollection<object[]> Evidencias { get; set; }
    }
}
