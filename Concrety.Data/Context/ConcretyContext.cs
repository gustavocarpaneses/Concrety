using Concrety.Core.Entities.Base;
using Concrety.Core.Interfaces.Logging;
using Concrety.Data.EntityConfig;
using Concrety.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Concrety.Data.Context
{
    public class ConcretyContext : IdentityDbContext<ApplicationIdentityUser, ApplicationIdentityRole, int, ApplicationIdentityUserLogin, ApplicationIdentityUserRole, ApplicationIdentityUserClaim>, IEntitiesContext
    {

        private bool _disposed;
        private ObjectContext _objectContext;
        private DbTransaction _transaction;

        public ConcretyContext()
            : base("Concrety")
        {

        }

        public ConcretyContext(string nameOrConnectionString, ILogger logger)
            : base(nameOrConnectionString)
        {
            Database.Log = logger.Log;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EFConfig.ConfigureEf(modelBuilder);
        }

        public override int SaveChanges()
        {
            AtualizarEntradas();   
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            //não precisa chamar o AtualizarEntradas, pois o base chama o método que recebe o CancellationToken, e ele já chama o AtualizarEntradas
            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            AtualizarEntradas();
            return base.SaveChangesAsync(cancellationToken);
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
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

        public async Task<IEnumerable<object[]>> ExecuteSqlQueryAsync(string query, params object[] parameters)
        {

            using (var cmd = base.Database.Connection.CreateCommand())
            {
                await base.Database.Connection.OpenAsync();

                cmd.CommandText = query;

                for (int i = 0; i < parameters.Length; i++)
                {
                    var dbParameter = cmd.CreateParameter();
                    dbParameter.ParameterName = "@p" + i;
                    dbParameter.Value = parameters[i];
                    cmd.Parameters.Add(dbParameter);
                }

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    return await ReadAsync(reader);
                }
            }
        }

        private async static Task<IEnumerable<object[]>> ReadAsync(DbDataReader reader)
        {
            var fieldCount = reader.FieldCount;

            var returnList = new List<object[]>();

            while (await reader.ReadAsync())
            {
                var values = new List<object>();
                for (int i = 0; i < fieldCount; i++)
                {
                    values.Add(reader.GetValue(i));
                }
                returnList.Add(values.ToArray());
            }

            return returnList;
        }

        private void UpdateEntityState<TEntity>(TEntity entity, EntityState entityState) where TEntity : EntityBase
        {
            var dbEntityEntry = GetDbEntityEntrySafely(entity, entityState != EntityState.Added);
            dbEntityEntry.State = entityState;
        }

        private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity, bool attach) where TEntity : EntityBase
        {
            var dbEntityEntry = Entry<TEntity>(entity);
            if (dbEntityEntry.State == EntityState.Detached && attach)
            {
                Set<TEntity>().Attach(entity);
            }
            return dbEntityEntry;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
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
            _disposed = true;
            base.Dispose(disposing);
        }

        private void AtualizarEntradas()
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
        }
    }
}
