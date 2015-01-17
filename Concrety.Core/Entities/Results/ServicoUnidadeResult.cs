using Concrety.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Concrety.Core.Entities.Results
{
    public class ServicoUnidadeResult : IEntityResult
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

        public bool ServicoConcluido
        {
            get;
            private set;
        }

        public ServicoUnidadeResult(IEnumerable<string> erros, bool sucesso, bool servicoConcluido)
        {
            Sucesso = sucesso;
            Erros = erros;
            ServicoConcluido = servicoConcluido;
        }
    }
}
