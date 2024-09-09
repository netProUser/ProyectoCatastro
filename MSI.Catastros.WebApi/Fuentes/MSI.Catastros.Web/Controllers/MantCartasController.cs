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
using MSI.Catastros.Web.Funcionalidad.MantCartas;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using Proc = MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo;
using MSI.Catastros.Web.Funcionalidad.Lotes;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class MantCartasController : Controller
    {
        // GET: MantCartas
        public ActionResult Index(CartasConfigViewModel cartas)
        {
            return View(new CartasConfigViewModel()
            {
                ListTipoInforme =  new List<SelectListItem>() { 
                    new SelectListItem(){ Value = "010004", Text = "CITACIÓN"},
                    new SelectListItem(){ Value = "010005", Text = "CONSTANCIA DE VISITA"},
                    new SelectListItem(){ Value = "010006", Text = "CARTA"}
                },
                ListCodigoCarta = new MantCartasHandler().ListarCodigoCartas(new CartasConfigViewModel()),
            });
        }
        
        [HttpPost]
        public ActionResult ListarCodigo(CartasConfigViewModel model)
        {
            List<SelectListItem> resultado = new MantCartasHandler().ListarCodigoCartas(model);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult AgregarInforme(CartasConfigViewModel model)
        {
            Nullable<bool> EstadoProceso = new MantCartasHandler().GrabarNuevoMantCarta(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult Grabar(CartasConfigViewModel model)
        {
            Nullable<bool> EstadoProceso = new MantCartasHandler().GrabarMantCarta(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult BuscarInforme(CartasConfigViewModel model)
        {
            bool resul = false;
            CartasConfigViewModel resultado = new MantCartasHandler().RecuperarMantCarta(model, out resul);
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