using Concrety.Domain.Entities.Base;
using System.Collections.Generic;

namespace Concrety.Domain.Entities
{
    public class Usuario : UsuarioBase
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual IEnumerable<Papel> Papeis { get; set; }

        public virtual IEnumerable<Permissao> Permissoes { get; set; }
        
        public virtual IEnumerable<Empreendimento> Empreendimentos { get; set; }

        public virtual IEnumerable<UsuarioTelefone> Telefones { get; set; }
    }

    public class UsuarioTelefone : EntityBase
    {
        public string DDD { get; set; }
        public string Telefone { get; set; }

        public virtual Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
    }
}
