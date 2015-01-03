using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Enumerators;
using System;

namespace Concrety.Core.Entities
{
    public class EmpreendimentoDiario : EntityBase
    {
        public DateTime Data { get; set; }
        public CondicaoClimatica CondicaoClimatica { get; set; }
        public bool HouveTrabalho { get; set; }
        public int TemperaturaMinima { get; set; }
        public int TemperaturaMaxima { get; set; }
        public int HorasTrabalhadas { get; set; }
        public int HorasParadas { get; set; }
        public string ServicosExecutados { get; set; }

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

        public virtual Empreendimento Empreendimento { get; set; }
        public int IdEmpreendimento { get; set; }
    }
}
