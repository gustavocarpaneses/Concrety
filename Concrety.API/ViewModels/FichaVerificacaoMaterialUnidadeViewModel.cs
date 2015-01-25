﻿using System;
using System.Collections.Generic;

namespace Concrety.API.ViewModels
{
    public class FichaVerificacaoMaterialUnidadeViewModel
    {

        public int Id { get; set; }

        public string NumeroPedido { get; set; }
        public string NotaFiscal { get; set; }
        public DateTime Data { get; set; }
        public string QuantidadeTotal { get; set; }

        public string AmostraValidacao { get; set; }
        public bool Aprovado { get; set; }
        public string Observacoes { get; set; }

        //public virtual FornecedorViewModel Fornecedor { get; set; }
        public int IdFornecedor { get; set; }

        //public virtual FichaVerificacaoMaterialViewModel FichaVerificacaoMaterial { get; set; }
        public int IdFichaVerificacaoMaterial { get; set; }

        public int IdUnidade { get; set; }

        public ICollection<ItemVerificacaoMaterialUnidadeViewModel> Itens { get; set; }

    }
}