using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace MSI.Catastros.Web.Decoradores
{
    public class ValidateAjaxAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
                return;

            var modelState = filterContext.Controller.ViewData.ModelState;
            if (!modelState.IsValid)
            {
                var errorModel =
                        from x in modelState.Keys
                        where modelState[x].Errors.Count > 0
                        select new
                        {
                            key = x,
                            errors = modelState[x].Errors.
                                                   Select(y => y.ErrorMessage).
                                                   ToArray()
                        };
                filterContext.Result = new JsonResult()
                {
                    Data = errorModel,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    ContentType = "application/json; charset=utf-8",
                };
                //filterContext.Result = new JsonResult
                //{
                //    Data = new { Success = false, Data = "Unauthorized" },
                //    ContentEncoding = System.Text.Encoding.UTF8,
                //    ContentType = "application/json",
                //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                //};
                //filterContext.Result = new JsonResult(new Json());
                //filterContext.HttpContext.Response.cote
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            }
        }
    }
}