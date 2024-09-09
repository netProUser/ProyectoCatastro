using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Filters
{
    public class LogExceptionAttribute : HandleErrorAttribute
    {
        private static ILog _Log { get; set; }

        public LogExceptionAttribute()
        {
            _Log = LogManager
                .GetLogger(MethodBase.GetCurrentMethod().Name);
        }
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            var usuario = VariablesWeb.Usuario == null ? "Anonymous" : VariablesWeb.Usuario.CODUSUARIO;
            var ip = filterContext.HttpContext.Request.UserHostAddress;

            var mensaje = "Error en la Aplicación, Contactar con el administrador del Sistemas " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            if (!filterContext.HttpContext.IsCustomErrorEnabled)
            {
                var message = "Usuario " + usuario + " ingresó desde la Ip " + ip + " al OnException- controller:" + controllerName + " action:" + actionName;
                _Log.Error(message + " Internal server error occurred while handling web request.", filterContext.Exception);

                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { success = false, responseText = mensaje }
                };
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                return;
            }
            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                var message = "Usuario " + usuario + " ingresó desde la Ip " + ip + " al OnException- controller:" + controllerName + " action:" + actionName;
                _Log.Error(message + " Internal server error occurred while handling web request.", filterContext.Exception);

                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { success = false, responseText = mensaje }
                };
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                return;
            }


            filterContext.Result = new ViewResult
            {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            var messages = "Usuario " + usuario + " ingresó desde la Ip " + ip + " al OnException- controller:" + controllerName + " action:" + actionName;
            _Log.Error(messages + " Internal server error occurred while handling web request.", filterContext.Exception);
        }
    }
}