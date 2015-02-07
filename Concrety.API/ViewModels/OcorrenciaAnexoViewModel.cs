using Concrety.Core.Entities.Enumerators;
using System;
using System.Collections.Generic;

namespace Concrety.API.ViewModels
{
    public class OcorrenciaAnexoViewModel
    {

        public int Id { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public virtual AnexoViewModel Anexo { get; set; }
        public int IdAnexo { get; set; }

        public int IdOcorrencia { get; set; }
    }
}
