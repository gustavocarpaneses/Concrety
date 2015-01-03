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
        IUsuarioBase UsuarioCadastro { get; set; }

        int? IdUsuarioUltimaAtualizacao { get; set; }
        IUsuarioBase UsuarioUltimaAtualizacao { get; set; }

        int? IdUsuarioExclusao { get; set; }
        IUsuarioBase UsuarioExclusao { get; set; }
    }
}
