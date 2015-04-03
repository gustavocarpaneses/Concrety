
using System;
using System.Collections.Generic;
namespace Concrety.API.ViewModels
{
    public class EmpreendimentoPeriodoViewModel
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }

        public string Nome { get; set; }
        public int Ordem { get; set; }
    }
}