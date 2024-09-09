using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Dociso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    [LogExceptionAttribute]
    public class DocisoController : Controller
    {
        //
        // GET: /Dociso/
        public ActionResult Index()
        {
            return View();
        }
        /*Listado*/
        [HttpPost]
        public ActionResult ListarDocIso(DocisoViewModel modelo)
        {
            //try
            //{
                var datas = new DocisoHandler().ListadoDocIso(modelo);
                return Json(new { success = true, data = datas });
            //}
            //catch (Exception)
            //{
            //}
            return Json(new { success = false });
        }
        /*
         * Registrar Documento ISO
         */
        [HttpGet]
        public PartialViewResult Registrar()
        {
            return PartialView("_DocIso", new DocisoViewModel()
            {
                TpDocumento = new DocisoHandler().ListadoTipoLlenado(),
                Estado = 1
            });
        }
        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(DocisoViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            Nullable<bool> EstadoProceso = new DocisoHandler().ProcesarDocISO(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

    }
}