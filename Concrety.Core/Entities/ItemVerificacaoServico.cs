﻿using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class ItemVerificacaoServico : EntityBase
    {
        public string Nome { get; set; }
        public string Validacao { get; set; }
        public string Descricao { get; set; }

        public virtual FichaVerificacaoServico FichaVerificacao { get; set; }
        public int IdFichaVerificacaoServico { get; set; }

        public ICollection<Patologia> Patologias { get; set; }
    }
}
