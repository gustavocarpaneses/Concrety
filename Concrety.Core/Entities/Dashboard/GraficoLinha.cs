
using System.Collections.Generic;
namespace Concrety.Core.Entities.Dashboard
{
    public class GraficoLinha<T, U>
    {
        public List<Serie<T>> Series { get; set; }
        public EixoValor EixoValor { get; set; }
        public EixoCategoria<U> EixoCategoria { get; set; }
    }
}
