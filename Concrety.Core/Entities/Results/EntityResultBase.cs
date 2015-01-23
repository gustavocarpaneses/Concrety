using Concrety.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concrety.Core.Entities.Results
{
    public class EntityResultBase : IEntityResult
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

        public EntityResultBase(IEnumerable<string> erros, bool sucesso)
        {
            Sucesso = sucesso;
            Erros = erros;
        }

    }
}
