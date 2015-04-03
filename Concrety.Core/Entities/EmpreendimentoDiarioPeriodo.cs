using Concrety.Core.Entities.Base;
using System;

namespace Concrety.Core.Entities
{
    public class EmpreendimentoDiarioPeriodo : EntityBase
    {

        public virtual EmpreendimentoDiario EmpreendimentoDiario { get; set; }
        public int IdEmpreendimentoDiario { get; set; }

        public virtual EmpreendimentoPeriodo EmpreendimentoPeriodo { get; set; }
        public int IdEmpreendimentoPeriodo { get; set; }

        public bool HouveTrabalho { get; set; }
        public int TemperaturaMinima { get; set; }
        public int TemperaturaMaxima { get; set; }
        public int HorasTrabalhadas { get; set; }
        public int HorasParadas { get; set; }
        
        public int TotalMontadores { get; set; }
        public int TotalArmadores { get; set; }
        public int TotalCarpinteiros { get; set; }
        public int TotalEletricistas { get; set; }
        public int TotalEncarregados { get; set; }
        public int TotalEncanadores { get; set; }
        public int TotalMestres { get; set; }
        public int TotalAjudantes { get; set; }
        public int TotalPedreiros { get; set; }

        public int TotalFaltas { get; set; }
        public int TotalAcidentados { get; set; }
        public int TotalNovosFuncionarios { get; set; }
        public int TotalDoentes { get; set; }
        public int TotalDemitidos { get; set; }
        
        public virtual CondicaoClimatica CondicaoClimatica { get; set; }
        public int IdCondicaoClimatica { get; set; }
    }
}
