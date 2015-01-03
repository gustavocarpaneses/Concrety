using Concrety.Domain.Entities.Base;
using Concrety.Domain.Interfaces.Repositories;
using Concrety.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Concrety.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {

        protected ConcretyContext Db = new ConcretyContext();
        protected int? IdUsuario;

        public RepositoryBase()
        {
            //utilizando esse construtor, é possível fazer apenas operações de pesquisa
        }

        public RepositoryBase(int idUsuario)
        {
            this.IdUsuario = idUsuario;
        }

        public void Add(TEntity obj)
        {
            if (!IdUsuario.HasValue)
            {
                throw new ArgumentNullException("IdUsuario");
            }

            obj.IdUsuarioCadastro = IdUsuario.Value;
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            if (IdUsuario == null)
            {
                throw new ArgumentNullException("IdUsuario");
            }

            obj.IdUsuarioUltimaAtualizacao = IdUsuario;
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            if (IdUsuario == null)
            {
                throw new ArgumentNullException("IdUsuario");
            }

            obj.IdUsuarioExclusao = IdUsuario;
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
