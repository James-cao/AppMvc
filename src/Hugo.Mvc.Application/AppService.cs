using Hugo.Mvc.Infra.Data.UnitOfWork;

namespace Hugo.Mvc.Application
{
	public class AppService
	{
		private readonly IUnitOfWork _uow;

		public AppService(IUnitOfWork uow)
		{
			_uow = uow;
		}

		public void Commit()
		{
			_uow.Commit();
		}
	}
}
