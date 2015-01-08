using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class FichaVerificacaoServicoConfiguration : EntityBaseConfiguration<FichaVerificacaoServico>
    {
        public FichaVerificacaoServicoConfiguration()
        {
            ToTable("FichasVerificacaoServico");

            Property(f => f.Nome).IsRequired();

            //TODO: Não está criando a FK
            HasRequired(f => f.Servico)
                .WithRequiredPrincipal(s => s.FichaVerificacaoServico)
                .Map(_ => _.MapKey("IdServico"));
        }
    }
}
