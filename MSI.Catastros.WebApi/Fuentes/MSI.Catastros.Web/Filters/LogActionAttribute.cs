using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Filters
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        private static ILog _Log { get; set; }

        public LogActionAttribute()
        {
            _Log = LogManager
                .GetLogger(MethodBase.GetCurrentMethod().Name);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {         
            LogMensaje(filterContext, "OnActionExecuting");
        }
        
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            LogMensaje(filterContext, "OnResultExecuting");
        }

        private void LogMensaje(ResultExecutingContext filterContext, string methodName)
        {
            //var usuario = VariablesWeb.Usuario == null ? "Anonymous" : VariablesWeb.Usuario.CODUSUARIO;
            //var ip = filterContext.HttpContext.Request.UserHostAddress;
            //var controllerName = filterContext.RouteData.Values["controller"];
            //var actionName = filterContext.RouteData.Values["action"];
            //var data = filterContext.HttpContext.Response;
            //var message = "Usuario " + usuario + " ingresó desde la Ip " + ip + " al {methodName}- controller:" + controllerName + " action:" + actionName;
            //_Log.Info(message);
        }
        private void LogMensaje(ActionExecutingContext filterContext, string methodName)
        {
            //var usuario = VariablesWeb.Usuario == null ? "Anonymous" : VariablesWeb.Usuario.CODUSUARIO;
            //var ip = filterContext.HttpContext.Request.UserHostAddress;
            //var controllerName = filterContext.RouteData.Values["controller"];
            //var actionName = filterContext.RouteData.Values["action"];
            //var data = filterContext.ActionParameters.FirstOrDefault();
            //var message = "Usuario " + usuario + " ingresó desde la Ip " + ip + " al {methodName}- controller:" + controllerName + " action:" + actionName;
            //_Log.Info(message);
        }
    }
}