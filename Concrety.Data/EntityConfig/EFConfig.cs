using Concrety.Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concrety.Data.EntityConfig
{
    public class EFConfig
    {

        public static void ConfigureEf(DbModelBuilder modelBuilder)
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
            modelBuilder.Configurations.Add(new PatologiaConfiguration());
            modelBuilder.Configurations.Add(new ServicoConfiguration());
            modelBuilder.Configurations.Add(new ServicoUnidadeConfiguration());
            modelBuilder.Configurations.Add(new SolucaoConfiguration());
            modelBuilder.Configurations.Add(new UnidadeConfiguration());

            ConfigureIdentityEntities(modelBuilder);      
        }

        private static void ConfigureIdentityEntities(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationIdentityUserClaim>()
                .ToTable("UsuariosClaims")
                .Property(a => a.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ApplicationIdentityUser>()
                .ToTable("Usuarios")
                .HasMany(u => u.Empreendimentos)
                    .WithMany()
                        .Map(m => m
                            .ToTable("UsuariosEmpreendimentos")
                            .MapLeftKey("IdUsuario")
                            .MapRightKey("IdEmpreendimento"));
            
            modelBuilder.Entity<ApplicationIdentityUser>()
                .Property(a => a.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ApplicationIdentityRole>()
                .ToTable("Papeis")
                .HasMany(p => p.FichasVerificacaoServico)
                    .WithMany()
                        .Map(m => m
                            .ToTable("FichasVerificacaoServicoPapeis")
                            .MapLeftKey("IdPapel")
                            .MapRightKey("IdFichaVerificacaoServico"));

            modelBuilder.Entity<ApplicationIdentityRole>()
                .Property(a => a.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ApplicationIdentityUserLogin>()
                .ToTable("UsuariosLogins");

            modelBuilder.Entity<ApplicationIdentityUserRole>()
                .ToTable("UsuariosPapeis");  
        }

    }
}
