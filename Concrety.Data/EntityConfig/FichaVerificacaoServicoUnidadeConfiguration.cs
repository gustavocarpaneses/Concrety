using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class FichaVerificacaoServicoUnidadeConfiguration : EntityBaseConfiguration<FichaVerificacaoServicoUnidade>
    {
        public FichaVerificacaoServicoUnidadeConfiguration()
        {
            ToTable("FichasVerificacaoServicoUnidades");

            HasRequired(f => f.FichaVerificacaoServico)
                .WithMany()
                .HasForeignKey(f => f.IdFichaVerificacaoServico);

            //TODO: Não está criando a FK
            HasRequired(f => f.Servico)
                .WithRequiredPrincipal(s => s.FichaVerificacaoServico)
                .Map(_ => _.MapKey("IdServicoUnidade"));            
        }
    }
}
