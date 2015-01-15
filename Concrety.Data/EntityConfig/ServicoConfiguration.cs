using Concrety.Core.Entities;
using Concrety.Data.EntityConfig.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Concrety.Data.EntityConfig
{
    public class ServicoConfiguration : EntityBaseConfiguration<Servico>
    {
        public ServicoConfiguration()
        {
            ToTable("Servicos");

            Property(s => s.Nome).IsRequired();
            Property(s => s.Descricao).IsRequired();
            Property(s => s.Norma).IsRequired().HasColumnType("text");
            Ignore(s => s.Atual);
            Ignore(s => s.Desabilitado);

            HasRequired(s => s.Nivel)
                .WithMany(n => n.Servicos)
                .HasForeignKey(s => s.IdNivel);

            HasOptional(s => s.ProximoServico)
                .WithMany()
                .HasForeignKey(s => s.IdProximoServico);
        }
    }
}
