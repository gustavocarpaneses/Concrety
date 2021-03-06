﻿using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class FichaVerificacaoServicoUnidade : EntityBase
    {
        public virtual FichaVerificacaoServico FichaVerificacaoServico { get; set; }
        public int IdFichaVerificacaoServico { get; set; }

        public virtual ServicoUnidade Servico { get; set; }
        public int IdServicoUnidade { get; set; }

        public virtual ICollection<ItemVerificacaoServicoUnidade> Itens { get; set; }
    }   
}
