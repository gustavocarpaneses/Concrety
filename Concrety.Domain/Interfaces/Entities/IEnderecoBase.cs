
namespace Concrety.Core.Interfaces.Entities
{
    public interface IEnderecoBase : IEntityBase
    {

        string Logradouro { get; set; }
        string Numero { get; set; }
        string Complemento { get; set; }
        string CEP { get; set; }
        string Cidade { get; set; }
        string Estado { get; set; }

    }
}
