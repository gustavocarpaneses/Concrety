
namespace Concrety.API.ViewModels
{
    public class AnexoViewModel
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
        public bool NovoUpload { get; set; }

        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public string Tipo { get; set; }
        public string ConteudoDataURL { get; set; }
    }
}
