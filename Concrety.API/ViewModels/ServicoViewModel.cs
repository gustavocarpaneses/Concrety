
namespace Concrety.API.ViewModels
{
    public class ServicoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Norma { get; set; }
        public bool Atual { get; set; }
        public bool Desabilitado { get; set; }
    }
}