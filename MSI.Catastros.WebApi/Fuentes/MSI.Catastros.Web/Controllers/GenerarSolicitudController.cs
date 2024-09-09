using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.GenerarSolicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BE = MSI.Catastros.BusinessEntities;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class GenerarSolicitudController : Controller
    {
        //
        // GET: /GenerarSolicitud/
        public ActionResult Index()
        {
            return View(new GenerarSolicitudViewModel() {
                TipoSolicitud = "CATASTRAL",
                TipoDocumento = "REQUERIMIENTO INICIAL",
                AreaSolicitud = "SUB GERENCIA DE CATASTRO",
                Estado = 1
            });
        }

        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(GenerarSolicitudViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });

            }
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new GenerarSolicitudHandler().ProcesarVias(modelo);
            //Nullable<bool> EstadoProceso = true;
            if (entSIC_RETORNO.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente", Solicitud = entSIC_RETORNO.CODIGO });
            }
            else
            {
                return Json(new { success = false, responseText = "Código de Vía ya Registrado" });
            }

        }
	}
}