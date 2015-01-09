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

            HasRequired(f => f.Servico)
                .WithMany(s => s.FichasVerificacaoServico)
                .HasForeignKey(f => f.IdServicoUnidade);
        }
    }
}
