using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;

namespace Concrety.Data.EntityConfig
{
    public class RelatorioConfiguration : EntityBaseConfiguration<Relatorio>
    {
        public RelatorioConfiguration()
        {
            ToTable("Relatorios");

            Property(s => s.Descricao).IsRequired();
            Property(s => s.Query).IsRequired();
            Property(s => s.Query).HasColumnType("varchar(max)");
        }
    }
}
