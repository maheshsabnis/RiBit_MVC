using System.Web;
using System.Web.Mvc;
using MVC_WebApp.CustomFilters;
namespace MVC_WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            /* Add the LogFilter*/
            filters.Add(new LogFilterAttribute());
            /* Add the ExceptionFilter*/
            filters.Add(new CustomExceptionFilterAttribute());
        }
    }
}
