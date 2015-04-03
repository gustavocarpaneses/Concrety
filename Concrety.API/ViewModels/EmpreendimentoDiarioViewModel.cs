
using System;
using System.Collections.Generic;
namespace Concrety.API.ViewModels
{
    public class EmpreendimentoDiarioViewModel
    {

        public int Id { get; set; }
        public bool Ativo { get; set; }

        //O campo não pode se chamar Data, pois dá erro no Kendo Grid
        public DateTime DataDiario { get; set; }
        public string ServicosExecutados { get; set; }
        public int IdEmpreendimento { get; set; }

        public virtual ICollection<EmpreendimentoDiarioPeriodoViewModel> DiariosPeriodos { get; set; }
    }
}