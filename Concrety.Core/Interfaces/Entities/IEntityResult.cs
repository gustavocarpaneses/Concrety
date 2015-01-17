using System.Collections.Generic;

namespace Concrety.Core.Interfaces.Entities
{
    public interface IEntityResult
    {
        IEnumerable<string> Erros { get; }
        bool Sucesso { get; }
    }
}
