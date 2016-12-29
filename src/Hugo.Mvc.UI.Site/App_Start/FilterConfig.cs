using Hugo.Mvc.Infra.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace Hugo.Mvc.UI.Site
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new GlobalErrorHandler());
		}
	}
}
