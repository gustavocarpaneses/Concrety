using Concrety.Core.Entities.Identity;
using Concrety.Core.Interfaces.Entities;
using System;

namespace Concrety.Core.Entities.Base
{
    public abstract class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }

        public int? IdUsuarioCadastro { get; set; }
        //public UsuarioBase UsuarioCadastro { get; set; }

        public int? IdUsuarioUltimaAtualizacao { get; set; }
        //public UsuarioBase UsuarioUltimaAtualizacao { get; set; }

        public int? IdUsuarioExclusao { get; set; }
        //public UsuarioBase UsuarioExclusao { get; set; }
    }
}
