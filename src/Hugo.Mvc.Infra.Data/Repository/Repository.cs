using Hugo.Mvc.Domain.Interfaces.Repository;
using Hugo.Mvc.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Hugo.Mvc.Infra.Data.Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected MvcContext Db;
		protected DbSet<TEntity> DbSet;

		public Repository(MvcContext context)
		{
			Db = context;
			DbSet = Db.Set<TEntity>();
		}

		public virtual TEntity Adicionar(TEntity obj)
		{
			var objReturn = DbSet.Add(obj);
			return objReturn;
		}

		public virtual TEntity Atualizar(TEntity obj)
		{
			var entry = Db.Entry(obj);
			DbSet.Attach(obj);
			entry.State = EntityState.Modified;

			return obj;
		}

		public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
		{
			return DbSet.Where(predicate);
		}

		public virtual TEntity ObterPorId(Guid id)
		{
			return DbSet.Find(id);
		}

		public virtual IEnumerable<TEntity> ObterTodos() //(int t, int s)
		{
			return DbSet.ToList(); //.Take(t).Skip(s).ToList();
		}

		public virtual void Remover(Guid id)
		{
			DbSet.Remove(DbSet.Find(id));
		}

		public int SaveChanges()
		{
			//tratamento
			return Db.SaveChanges();
		}

		public void Dispose()
		{
			Db.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
