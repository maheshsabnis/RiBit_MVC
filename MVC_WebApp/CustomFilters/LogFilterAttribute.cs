﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_WebApp.CustomFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {

        private void Log(string executionStatus, RouteData routeData)
        { 
            string controllerName = routeData.Values["controller"].ToString();
            string actionName = routeData.Values["action"].ToString();

            string logMessage = $"Current State of execution is {executionStatus} in {actionName} method of {controllerName} Controller";

            // Log this on Output Window
            /*YOU CAN HAVE DATABASE LOG CODE, ITS Your headache*/
            Debug.WriteLine(logMessage);

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }
    }
}