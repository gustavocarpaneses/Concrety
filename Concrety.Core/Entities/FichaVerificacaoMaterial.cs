using Concrety.Core.Entities.Base;
using Concrety.Core.Entities.Enumerators;
using System;

namespace Concrety.Core.Entities
{
    public class FichaVerificacaoMaterial : EntityBase
    {
        public virtual Unidade Unidade { get; set; }
        public int IdUnidade { get; set; }

        public string NotaFiscal { get; set; }
        public DateTime Data { get; set; }

        public virtual Material Material { get; set; }
        public int IdMaterial { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
        public int IdFornecedor { get; set; }

        public AspectosMaterial AspectoGeral { get; set; }
        public string Amostra { get; set; }
        public StatusRecebimentoMaterial Status { get; set; }
        public string Descricao { get; set; }
    }
}
