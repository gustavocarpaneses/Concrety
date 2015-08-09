
namespace Concrety.Core.Entities.Dashboard
{
    public class Serie<T>
    {

        public string Nome { get; set; }
        public T[] Dados { get; set; }

    }
}
