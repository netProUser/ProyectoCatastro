using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.MantInformes;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using Proc = MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo;
using MSI.Catastros.Web.Funcionalidad.Lotes;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class MantInformesController : Controller
    {
        // GET: MantInformes
        public ActionResult Index(InformesConfigViewModel cartas)
        {
            return View(new InformesConfigViewModel()
            {
                ListTipoInforme =  new List<SelectListItem>() { 
                    new SelectListItem(){ Value = "010004", Text = "CITACIÓN"},
                    new SelectListItem(){ Value = "010005", Text = "CONSTANCIA DE VISITA"},
                    new SelectListItem(){ Value = "010006", Text = "CARTA"}
                },
                ListCodigoCarta = new MantInformesHandler().ListarCodigoCartas(new InformesConfigViewModel()),
            });
        }
        
        [HttpPost]
        public ActionResult ListarCodigo(InformesConfigViewModel model)
        {
            List<SelectListItem> resultado = new MantInformesHandler().ListarCodigoCartas(model);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult AgregarInforme(InformesConfigViewModel model)
        {
            Nullable<bool> EstadoProceso = new MantInformesHandler().GrabarNuevoMantCarta(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult Grabar(InformesConfigViewModel model)
        {
            Nullable<bool> EstadoProceso = new MantInformesHandler().GrabarMantCarta(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult BuscarInforme(InformesConfigViewModel model)
        {
            bool resul = false;
            InformesConfigViewModel resultado = new MantInformesHandler().RecuperarMantCarta(model, out resul);
            if (resul) { 
                if(model.FiltrarCodigoTipoInforme == "010004") {
                    return PartialView("_Registrar", resultado);
                } else if(model.FiltrarCodigoTipoInforme == "010005") {
                    return PartialView("_Registrar2", resultado);
                } else {
                    return PartialView("_Registrar3", resultado);
                }
                
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}