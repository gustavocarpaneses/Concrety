using Concrety.Core.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concrety.Imports.Pizolato.TorresDoBela
{
    public class Common
    {
        public const string NOME_EMPREENDIMENTO = "Torres do Bela";

        public static void ValidarResult(EntityResultBase result)
        {
            if (!result.Sucesso)
            {
                throw new ApplicationException(String.Join(",", result.Erros));
            }
        }
    }
}
