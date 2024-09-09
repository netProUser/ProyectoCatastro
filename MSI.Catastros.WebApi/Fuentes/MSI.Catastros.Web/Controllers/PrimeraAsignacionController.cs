using MSI.Catastros.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Funcionalidad.PrimeraAsignacion;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class PrimeraAsignacionController : Controller
    {
        // GET: PrimeraAsignacion
        public ActionResult Index()
        {
            return View(new FiltrarPrimeraAsignacionViewModel
            {
                ListTipoSolicitud = new PrimeraAsignacionHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new PrimeraAsignacionHandler().ListadoTipoDocumento()
            });
        }
        [HttpGet]
        public ActionResult BuscarAsignacion(PrimeraAsignacionViewModel modelo)
        {
            // 000022
            PrimeraAsignacionViewModel PrimeraAsignacion = new PrimeraAsignacionHandler().BuscarPrimeraAsignacion(modelo);
            ViewBag.ListaTipoProcedimiento = new PrimeraAsignacionHandler().ListadoTipoProcedimientoAsig();
            return PartialView("_Registrar", PrimeraAsignacion);

        }

        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(PrimeraAsignacionViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            Nullable<bool> EstadoProceso = new PrimeraAsignacionHandler().ProcesarAsignacion(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }





        




        //#region Asignar Solicitud (Otros Coordinadores)
        //public ActionResult IndexSolicitudOtros()
        //{
        //    return View(new FilterAsignarSolicitudOtrosViewModel
        //    {
        //        ListTipoSolicitud = new AsignarSolicitudHandler().ListadoTipoSolicitante(),             
        //        ListAreaSolicitante = new AsignarSolicitudHandler().ListadoAreaSolicitante(),
        //        ListAccion = new AsignarSolicitudHandler().ListadoAcciones(),
        //        ListAsignarResponsable = new AsignarSolicitudHandler().ListadoResponsable(),
        //        FechaRemision = DateTime.Now.Date
        //    });
        //}



        //#endregion


    }
}