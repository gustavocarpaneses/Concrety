using Concrety.Core.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Core.Entities
{
    /// <summary>
    /// Sub-divisões existentes dentro de um Macro-Serviço
    /// Ex.: Para o Macro-Serviço "Unidades Habitacionais" em um Empreendimento de Apartamentos, 
    /// poderíamos ter as seguintes Estruturas de Serviço:
    /// Obra
    ///     Quadra
    ///         Bloco
    ///             Unidade
    /// </summary>
    public class Nivel : EntityBase
    {

        public string Nome { get; set; }

        public virtual MacroServico MacroServico { get; set; }
        public int IdMacroServico { get; set; }

        public virtual Nivel NivelPai { get; set; }
        //public int? IdNivelPai { get; set; }

        public virtual Nivel NivelFilho { get; set; }
        //public int? IdNivelFilho { get; set; }

        public virtual ICollection<Unidade> Unidades { get; set; }

        public virtual ICollection<Servico> Servicos { get; set; }

        public virtual ICollection<FichaVerificacaoMaterial> FichasVerificacaoMaterial { get; set; }
        
    }
}
