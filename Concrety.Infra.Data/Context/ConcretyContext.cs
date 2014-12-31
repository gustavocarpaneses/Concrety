using Concrety.Domain.Interfaces.Entities;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));

            modelBuilder.Properties<decimal>()
                .Configure(p => p.HasPrecision(18, 2));

            //modelBuilder.Configurations.Add(new ClienteConfiguration());

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
