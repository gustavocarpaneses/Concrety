using Concrety.Core.Entities.Base;
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
        
        int IdUsuarioCadastro { get; set; }
        //UsuarioBase UsuarioCadastro { get; set; }

        int? IdUsuarioUltimaAtualizacao { get; set; }
        //UsuarioBase UsuarioUltimaAtualizacao { get; set; }

        int? IdUsuarioExclusao { get; set; }
        //UsuarioBase UsuarioExclusao { get; set; }
    }
}
