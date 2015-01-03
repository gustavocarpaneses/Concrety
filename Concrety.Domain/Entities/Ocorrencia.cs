using Concrety.Domain.Entities.Base;
using Concrety.Domain.Entities.Enumerators;
using System;
using System.Collections.Generic;

namespace Concrety.Domain.Entities
{
    public class Ocorrencia : EntityBase
    {
        public string Descricao { get; set; }

        public DateTime DataAbertura { get; set; }
        public DateTime DataConclusao { get; set; }

        public StatusOcorrencia Status { get; set; }

        public virtual ServicoUnidade Servico { get; set; }
        public int IdServico { get; set; }

        public virtual Patologia Patologia { get; set; }
        public int IdPatologia { get; set; }

        //TODO: Decidir entre armazenar as Imagens em Blob ou algum serviço de Streaming
        //public virtual ICollection<string> Evidencias { get; set; }
        //public virtual ICollection<object[]> Evidencias { get; set; }
    }
}
