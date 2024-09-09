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
using MSI.Catastros.Web.Funcionalidad.Cartas;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using BE = MSI.Catastros.BusinessEntities;
using Proc = MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo;
using MSI.Catastros.Web.Funcionalidad.Lotes;
using System.IO;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class CartasController : Controller
    {
        // GET: Cartas
        public ActionResult Index(CartasViewModel cartas)
        {
            return View(new CartasViewModel()
            {
                ListTipoInforme =  new List<SelectListItem>() { 
                    new SelectListItem(){ Value = "CITA", Text = "CITACIÓN"},
                    new SelectListItem(){ Value = "CONV", Text = "CONSTANCIA DE VISITA"},
                    new SelectListItem(){ Value = "CAPI", Text = "PROGRAMACIÓN DE INSPECCIÓN"}
                },
                ListTipoSolicitud = new Proc.ProcedimientoNuevoHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new Proc.ProcedimientoNuevoHandler().ListadoTipoDocumento(),
                ListTipoPersona = new CartasHandler().ListadoTipoPersona(),
            });
        }
        [HttpPost]
        public ActionResult Grabar(CartasViewModel model)
        {
            BE.SIC_RETORNO EstadoProceso = new CartasHandler().GrabarCarta(model);
            //Nullable<bool> EstadoProceso = false;
            //Byte[] test = new CartasHandler().PdfSharpConvert("<img src=qC:\\Users\\pedro.pena\\Downloads\\informes.png'>");

            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente", ruta = EstadoProceso.MENSAJE });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public JsonResult CargarCartas(DataTableAjaxPostModel model, CartasViewModel FiltrarCartas)
        {
            
                // --Definir variables de búsqueda
                FiltrarCartas.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
                FiltrarCartas.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
                FiltrarCartas.FiltrarCodigoPeriodo = Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
                FiltrarCartas.FiltrarCodigoTipoDocumentoReg = Request.Form.GetValues("FiltrarCodigoTipoDocumentoReg").FirstOrDefault();
                FiltrarCartas.FiltrarNumeroInspeccion = Request.Form.GetValues("FiltrarNumeroInspeccion").FirstOrDefault();
                int totalResultado;
                // --Obtener los resultados enviando información de la pagínacion
                var resultado = new CartasHandler().RecargarTablaCartas(model, FiltrarCartas, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }
        [HttpPost]
        public ActionResult CrearCarta(CartasViewModel model)
        {
            BE.SIC_RETORNO EstadoProceso = new CartasHandler().CrearCarta(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = EstadoProceso.MENSAJE });

        }
        [HttpPost]
        public ActionResult ListarNumeroInspecciones(CartasViewModel model)
        {
            List<SelectListItem> resultado = new CartasHandler().ListarNumeroInspeccionSelect(model);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult BuscarGrabar(CartasViewModel model)
        {
            bool resul = false;
            CartasViewModel resultado = new CartasHandler().RecuperarGrabarCarta(model, out resul);
            if (resul == true)
            {
                if (model.FiltrarCodigoTipoInforme == "CITA")
                {
                    return PartialView("_RegistrarCitacion", resultado);
                }
                else if (model.FiltrarCodigoTipoInforme == "CONV")
                {
                    return PartialView("_RegistrarConstancia", resultado);
                }
                else
                {
                    return PartialView("_RegistrarProgInspec", resultado);
                }
            }
            else {
                return Json(new { success = resul, Carta = resultado });
            }
            
        }
        [HttpPost]
        public ActionResult BuscarUbicacion(CartasViewModel model)
        {
            bool resul = false;
            List<SolicitudUnidadViewModel> resultado = new CartasHandler().RecuperarUbicacion(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarInspectores(CartasViewModel model)
        {
            bool resul = false;
            List<CartasViewModel> resultado = new CartasHandler().RecuperarInspectores(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarTelefono(string id)
        {
            bool resul = false;
            string resultado = new CartasHandler().RecuperarTelefono(id);
            return Json(new { success = resul, Datos = resultado });
        }
        [HttpPost]
        public ActionResult BuscarSolicitud(CartasViewModel model)
        {
            bool resul = false;
            List<CartasViewModel> resultado = new CartasHandler().RecuperarSolicitud(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarUnidades(CartasViewModel model)
        {
            bool resul = false;
            List<SolicitudUnidadViewModel> resultado = new CartasHandler().RecuperarSolUnidad(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarSolicitudPersona(CartasViewModel model)
        {
            bool resul = false;
            CartasViewModel resultado = new CartasHandler().CargarSolicitante(model);
            return Json(new { success = resul, Solicitud = resultado });

        }
        [HttpPost]
        public ActionResult BuscarDiasProg(CartasViewModel model)
        {
            bool resul = false;
            List<SelectListItem> resultado = new CartasHandler().RecuperarDiasProg(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarInspecciones(CartasViewModel model)
        {
            bool resul = false;
            List<CartasViewModel> resultado = new CartasHandler().RecuperarInspecciones(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult EliminarCarta(CartasViewModel model)
        {
            Nullable<bool> EstadoProceso = new CartasHandler().EliminarInforme(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }


        
    }
}