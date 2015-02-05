using Concrety.Core.Entities.Enumerators;
using System;
using System.Collections.Generic;

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

        public ICollection<AnexoViewModel> Anexos { get; set; }
    }
}
