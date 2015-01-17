using Concrety.Core.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concrety.API.ViewModels
{
    public class ServicoUnidadeViewModel
    {

        public int Id { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public StatusServicoUnidade Status { get; set; }

        public virtual ICollection<FichaVerificacaoServicoUnidadeViewModel> FichasVerificacaoServico { get; set; }

    }
}