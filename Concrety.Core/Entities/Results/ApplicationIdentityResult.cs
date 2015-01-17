using Concrety.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Concrety.Core.Entities.Results
{
    public class ApplicationIdentityResult : IEntityResult
    {
        public IEnumerable<string> Erros
        {
            get;
            private set;
        }

        public bool Sucesso
        {
            get;
            private set;
        }

        public ApplicationIdentityResult(IEnumerable<string> errors, bool succeeded)
        {
            Sucesso = succeeded;
            Erros = errors;
        }
    }
}
