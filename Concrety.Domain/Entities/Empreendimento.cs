﻿using Concrety.Domain.Entities.Base;
using Concrety.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace Concrety.Domain.Entities
{
    public class Empreendimento : EntityBase, IEnderecoBase
    {
        public string Nome { get; set; }

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public DateTime DataInicioConstrucao { get; set; }
        public DateTime DataFimConstrucao { get; set; }
        
        public virtual IEnumerable<MacroServico> MacrosServicos { get; set; }

        public virtual IEnumerable<DiarioEmpreendimento> Diarios { get; set; }

        public virtual IEnumerable<FichaVerificacaoMaterial> FichasVerificacaoMaterial { get; set; }
    }
}
