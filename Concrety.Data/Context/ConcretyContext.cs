using Concrety.Core.Entities.Base;
using Concrety.Data.EntityConfig;
using Concrety.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Concrety.Data.Context
{
    public class ConcretyContext : IdentityDbContext<ApplicationIdentityUser, ApplicationIdentityRole, int, ApplicationIdentityUserLogin, ApplicationIdentityUserRole, ApplicationIdentityUserClaim>, IEntitiesContext
    {

        private ObjectContext _objectContext;
        private DbTransaction _transaction;

        public ConcretyContext()
            : base("Concrety")
        {

        }

        public ConcretyContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EFConfig.ConfigureEf(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetInterface("IEntityBase") != null))
            {
                var objeto = entry.Entity as EntityBase;

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


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }
        
        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            UpdateEntityState(entity, EntityState.Added);
        }

        public void SetAsModified<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            UpdateEntityState(entity, EntityState.Modified);
        }

        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            UpdateEntityState(entity, EntityState.Deleted);
        }

        public void BeginTransaction()
        {
            _objectContext = ((IObjectContextAdapter)this).ObjectContext;
            if (_objectContext.Connection.State == ConnectionState.Open)
            {
                return;
            }
            _objectContext.Connection.Open();
            _transaction = _objectContext.Connection.BeginTransaction();
        }

        public int Commit()
        {
            var saveChanges = SaveChanges();
            _transaction.Commit();
            return saveChanges;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public Task<int> CommitAsync()
        {
            var saveChangesAsync = SaveChangesAsync();
            _transaction.Commit();
            return saveChangesAsync;
        }

        private void UpdateEntityState<TEntity>(TEntity entity, EntityState entityState) where TEntity : EntityBase
        {
            var dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = entityState;
        }

        private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            var dbEntityEntry = Entry<TEntity>(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Set<TEntity>().Attach(entity);
            }
            return dbEntityEntry;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                {
                    _objectContext.Connection.Close();
                }
                if (_objectContext != null)
                {
                    _objectContext.Dispose();
                }
                if (_transaction != null)
                {
                    _transaction.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
