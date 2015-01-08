using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Enumerators;
using System;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class Ocorrencia : EntityBase
    {
        public string Descricao { get; set; }

        public DateTime DataAbertura { get; set; }
        public DateTime DataConclusao { get; set; }

        public StatusOcorrencia Status { get; set; }

        public virtual ItemVerificacaoUnidade ItemVerificacao { get; set; }
        public int IdItemVerificacaoUnidade { get; set; }

        public virtual Patologia Patologia { get; set; }
        public int IdPatologia { get; set; }

        //TODO: Decidir entre armazenar as Imagens em Blob ou algum serviço de Streaming
        //public virtual ICollection<string> Evidencias { get; set; }
        //public virtual ICollection<object[]> Evidencias { get; set; }
    }
}
