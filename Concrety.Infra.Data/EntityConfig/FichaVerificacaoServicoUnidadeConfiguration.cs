using Concrety.Domain.Entities;
using Concrety.Infra.Data.EntityConfig.Base;

namespace Concrety.Infra.Data.EntityConfig
{
    public class FichaVerificacaoServicoUnidadeConfiguration : EntityBaseConfiguration<FichaVerificacaoServicoUnidade>
    {
        public FichaVerificacaoServicoUnidadeConfiguration()
        {
            ToTable("FichasVerificacaoServicoUnidades");

            Property(f => f.DataAbertura).IsRequired();
            Property(f => f.Status).IsRequired();

            HasRequired(f => f.FichaVerificacaoServico)
                .WithMany()
                .HasForeignKey(f => f.IdFichaVerificacaoServico);

            HasRequired(f => f.MacroServico)
                .WithMany(m => m.FichasVerificacaoServico)
                .HasForeignKey(f => f.IdMacroServico);

            HasOptional(f => f.Unidade)
                .WithMany(u => u.FichasVerificacaoServico)
                .HasForeignKey(f => f.IdUnidade);
        }
    }
}
