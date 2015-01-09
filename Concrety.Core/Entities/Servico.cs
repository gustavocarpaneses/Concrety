﻿using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class Servico : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Norma { get; set; }

        public virtual Nivel Nivel { get; set; }
        public int IdNivel { get; set; }

        public virtual FichaVerificacaoServico FichaVerificacaoServico { get; set; }
    }
}
