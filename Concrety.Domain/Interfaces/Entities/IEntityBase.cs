using Concrety.Core.Entities.Identity;
using System;

namespace Concrety.Core.Interfaces.Entities
{
    public interface IEntityBase
    {
        int Id { get; set; }
        bool Ativo { get; set; }
        bool Excluido { get; set; }
        DateTime DataCadastro { get; set; }
        DateTime? DataUltimaAtualizacao { get; set; }
        DateTime? DataExclusao { get; set; }
        
        int? IdUsuarioCadastro { get; set; }
        ApplicationUser UsuarioCadastro { get; set; }

        int? IdUsuarioUltimaAtualizacao { get; set; }
        ApplicationUser UsuarioUltimaAtualizacao { get; set; }

        int? IdUsuarioExclusao { get; set; }
        ApplicationUser UsuarioExclusao { get; set; }
    }
}
