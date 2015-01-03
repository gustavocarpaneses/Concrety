using Concrety.Domain.Entities;
using Concrety.Domain.Interfaces.Entities;
using Concrety.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Concrety.Infra.Data.Context
{
    public class ConcretyContext : DbContext
    {

        public ConcretyContext()
            : base("Concrety")
        {

        }

        public DbSet<CondicaoClimatica> CondicoesClimaticas { get; set; }
        public DbSet<Empreendimento> Empreendimentos { get; set; }
        public DbSet<EmpreendimentoDiario> EmpreendimentoDiarios { get; set; }
        public DbSet<EstruturaServico> EstruturasServico { get; set; }
        public DbSet<FichaVerificacaoMaterial> FichasVerificacaoMaterial { get; set; }
        public DbSet<FichaVerificacaoServico> FichasVerificacaoServico { get; set; }
        public DbSet<FichaVerificacaoServicoUnidade> FichasVerificacaoServicoUnidades { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<MacroServico> MacroServicos { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<Papel> Papeis { get; set; }
        public DbSet<Patologia> Patologias { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<ServicoUnidade> ServicosUnidades { get; set; }
        public DbSet<Solucao> Solucoes { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioTelefone> UsuarioTelefones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));

            modelBuilder.Configurations.Add(new CondicaoClimaticaConfiguration());
            modelBuilder.Configurations.Add(new EmpreendimentoConfiguration());
            modelBuilder.Configurations.Add(new EmpreendimentoDiarioConfiguration());
            modelBuilder.Configurations.Add(new EstruturaServicoConfiguration());
            modelBuilder.Configurations.Add(new FichaVerificacaoMaterialConfiguration());
            modelBuilder.Configurations.Add(new FichaVerificacaoServicoConfiguration());
            modelBuilder.Configurations.Add(new FichaVerificacaoServicoUnidadeConfiguration());
            modelBuilder.Configurations.Add(new FornecedorConfiguration());
            modelBuilder.Configurations.Add(new MacroServicoConfiguration());
            modelBuilder.Configurations.Add(new MaterialConfiguration());
            modelBuilder.Configurations.Add(new OcorrenciaConfiguration());
            modelBuilder.Configurations.Add(new PapelConfiguration());
            modelBuilder.Configurations.Add(new PatologiaConfiguration());
            modelBuilder.Configurations.Add(new PermissaoConfiguration());
            modelBuilder.Configurations.Add(new ServicoConfiguration());
            modelBuilder.Configurations.Add(new ServicoUnidadeConfiguration());
            modelBuilder.Configurations.Add(new SolucaoConfiguration());
            modelBuilder.Configurations.Add(new UnidadeConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuarioTelefoneConfiguration());

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetInterface("IEntityBase") != null))
            {
                var objeto = entry.Entity as IEntityBase;

                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                    entry.Property("DataUltimaAtualizacao").CurrentValue = DBNull.Value;
                    entry.Property("IdUsuarioUltimaAtualizacao").CurrentValue = DBNull.Value;

                    entry.Property("DataExclusao").CurrentValue = DBNull.Value;
                    entry.Property("IdUsuarioExclusao").CurrentValue = DBNull.Value;
                    
                    entry.Property("Ativo").CurrentValue = true;
                    entry.Property("Excluido").CurrentValue = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("IdUsuarioCadastro").IsModified = false;

                    entry.Property("DataUltimaAtualizacao").CurrentValue = DateTime.Now;

                    entry.Property("DataExclusao").IsModified = false;
                    entry.Property("IdUsuarioExclusao").IsModified = false;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;

                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("IdUsuarioCadastro").IsModified = false;

                    entry.Property("DataUltimaAtualizacao").IsModified = false;
                    entry.Property("IdUsuarioUltimaAtualizacao").IsModified = false;

                    entry.Property("DataExclusao").CurrentValue = DateTime.Now;
                    entry.Property("Excluido").CurrentValue = true;
                }
            }
            return base.SaveChanges();
        }

    }
}
