
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int HorasTrabalhadas
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.HorasTrabalhadas);
            }
        }
        public int HorasParadas
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.HorasParadas);
            }
        }

        public int TotalMontadores
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalMontadores);
            }
        }
        public int TotalArmadores
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalArmadores);
            }
        }
        public int TotalCarpinteiros
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalCarpinteiros);
            }
        }
        public int TotalEletricistas
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalEletricistas);
            }
        }
        public int TotalEncarregados
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalEncarregados);
            }
        }
        public int TotalEncanadores
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalEncanadores);
            }
        }
        public int TotalMestres
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalMestres);
            }
        }
        public int TotalAjudantes
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalAjudantes);
            }
        }
        public int TotalPedreiros
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalPedreiros);
            }
        }

        public int TotalGeral
        {
            get
            {
                return TotalMontadores + TotalArmadores + TotalCarpinteiros + TotalEletricistas + TotalEncarregados +
                    TotalEncanadores + TotalMestres + TotalAjudantes + TotalPedreiros;
            }
        }

        public int TotalFaltas
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalFaltas);
            }
        }
        public int TotalAcidentados
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalAcidentados);
            }
        }
        public int TotalNovosFuncionarios
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalNovosFuncionarios);
            }
        }
        public int TotalDoentes
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalDoentes);
            }
        }
        public int TotalDemitidos
        {
            get
            {
                return DiariosPeriodos.Where(p => p.Ativo && !p.Excluido).Sum(p => p.TotalDemitidos);
            }
        }
    }
}