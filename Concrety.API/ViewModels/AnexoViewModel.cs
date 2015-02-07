
namespace Concrety.API.ViewModels
{
    public class AnexoViewModel
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }

        public string UrlPrimaria { get; set; }
        public string UrlSecundaria { get; set; }

        public int IdObra { get; set; }
        public string NomeBlob { get; set; }
    }
}
