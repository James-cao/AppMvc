using Hugo.Mvc.Infra.Data.Context;
using System;

namespace Hugo.Mvc.Infra.Data.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MvcContext _context;
		private bool _disposed;

		public UnitOfWork(MvcContext context)
		{
			_context = context;
			_disposed = false;
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
