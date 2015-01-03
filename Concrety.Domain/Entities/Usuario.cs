using Concrety.Domain.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Domain.Entities
{
    public class Usuario : UsuarioBase
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Papel> Papeis { get; set; }

        public virtual ICollection<Permissao> Permissoes { get; set; }
        
        public virtual ICollection<Empreendimento> Empreendimentos { get; set; }

        public virtual ICollection<UsuarioTelefone> Telefones { get; set; }
    }
}
