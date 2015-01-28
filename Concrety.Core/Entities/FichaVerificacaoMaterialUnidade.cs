using Concrety.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    public class FichaVerificacaoMaterialUnidade : EntityBase
    {

        public string NumeroPedido { get; set; }
        public string NotaFiscal { get; set; }
        public DateTime Data { get; set; }
        public string QuantidadeTotal { get; set; }
        
        public string AmostraValidacao { get; set; }
        public bool Aprovado { get; set; }
        public string Observacoes { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
        public int IdFornecedor { get; set; }

        public virtual FichaVerificacaoMaterial FichaVerificacaoMaterial { get; set; }
        public int IdFichaVerificacaoMaterial { get; set; }

        public virtual Unidade Unidade { get; set; }
        public int IdUnidade { get; set; }

        public virtual ICollection<ItemVerificacaoMaterialUnidade> Itens { get; set; }

    }
}
