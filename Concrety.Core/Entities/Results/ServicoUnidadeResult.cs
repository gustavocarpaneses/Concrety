using Concrety.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Concrety.Core.Entities.Results
{
    public class ServicoUnidadeResult : EntityResultBase
    {
        public bool ServicoConcluido
        {
            get;
            private set;
        }

        public ServicoUnidadeResult(IEnumerable<string> erros, bool sucesso, bool servicoConcluido)
            : base(erros, sucesso)
        {
            ServicoConcluido = servicoConcluido;
        }
    }
}
