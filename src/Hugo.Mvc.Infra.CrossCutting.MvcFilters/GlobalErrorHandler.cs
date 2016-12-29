using System.Web.Mvc;

namespace Hugo.Mvc.Infra.CrossCutting.MvcFilters
{
	public class GlobalErrorHandler : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			//Se tiver alguma exception
			if (filterContext.Exception != null)
			{
				// Manipular a Ex
				// Injetar alguma LIB de tratamento de erro
				//	-> Gravar log de erro
				//	-> Email ao Admin
				//	-> Retornar cod de erro amigavel

				//filterContext.Controller.TempData["ErrorMessage"] = filterContext.Exception.Message;
			}

			base.OnActionExecuted(filterContext);
		}
	}
}
