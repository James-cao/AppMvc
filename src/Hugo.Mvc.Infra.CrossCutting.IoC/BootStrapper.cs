using Hugo.Mvc.Application;
using Hugo.Mvc.Application.Interfaces;
using Hugo.Mvc.Domain.Interfaces.Repository;
using Hugo.Mvc.Domain.Interfaces.Services;
using Hugo.Mvc.Domain.Services;
using Hugo.Mvc.Infra.Data.Context;
using Hugo.Mvc.Infra.Data.Repository;
using Hugo.Mvc.Infra.Data.UnitOfWork;
using SimpleInjector;

namespace Hugo.Mvc.Infra.CrossCutting.IoC
{
	public class BootStrapper
	{
		public static void RegisterServices(Container container)
		{
			// Lifestyle.Transient => Uma instancia para cada solicitacao.
			// Lifestyle.Singleton => Uma instancia unica para a classe.
			// Lifestyle.Scoped => Uma isntancia unica para o request.

			//App
			container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

			//Domain
			container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

			//Data
			container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
			container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
			container.Register<MvcContext>(Lifestyle.Scoped);
		}
	}
}
