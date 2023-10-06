using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_WebApp.CustomFilters
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomExceptionFilterAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
             // 1.Handle Exeption
             filterContext.ExceptionHandled = true;
             // 2. REad Exceptin Message
             Exception ex = filterContext.Exception;

            // 3. Create a ViewData
            ViewDataDictionary vData = new ViewDataDictionary();
            vData["controller"] = filterContext.RouteData.Values["controller"];
            vData["action"] = filterContext.RouteData.Values["action"];
            vData["errorMessage"] = ex.Message;

            // 4. Set the Result
            filterContext.Result = new ViewResult()
            {
                ViewName = "CustomError",
                ViewData = vData
            };
        }
    }
}