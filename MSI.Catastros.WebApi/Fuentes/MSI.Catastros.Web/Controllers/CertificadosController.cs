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
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Certificados;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using Proc = MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo;
using MSI.Catastros.Web.Funcionalidad.Lotes;
using System.IO;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class CertificadosController : Controller
    {
        // GET: Certificados
        public ActionResult Index(CertificadosViewModel cartas)
        {
            return View(new CertificadosViewModel()
            {
                ListTipoInforme = new List<SelectListItem>() {
                    new SelectListItem(){ Value = "CEJU", Text = "CERTIFICADO DE JURISDICCIÓN"},
                    new SelectListItem(){ Value = "CENO", Text = "CERTIFICADO DE NOMENCLATURA"},
                    new SelectListItem(){ Value = "CNMU", Text = "CERTIFICADO DE NUMERACIÓN"},
                    new SelectListItem(){ Value = "RNUM", Text = "RESOLUCIÓN DE NUMERACIÓN"},
                    new SelectListItem(){ Value = "HINF", Text = "HOJA INFORMATIVA"},
                    new SelectListItem(){ Value = "CEAC", Text = "PLANO DE ACUMULACIÓN"}
                },
                ListTipoSolicitud = new Proc.ProcedimientoNuevoHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new Proc.ProcedimientoNuevoHandler().ListadoTipoDocumento(),
                ListTipoPersona = new CertificadosHandler().ListadoTipoPersona(),
            });
        }
        [HttpPost]
        public ActionResult CrearCertificado(CertificadosViewModel model)
        {
            BE.SIC_RETORNO EstadoProceso = new CertificadosHandler().CrearCertificado(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = EstadoProceso.MENSAJE });

        }
        [HttpPost]
        public ActionResult Grabar(CertificadosViewModel model)
        {
            string codigo = "";
            BE.SIC_RETORNO EstadoProceso = new CertificadosHandler().GrabarCertificado(model, out codigo);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, codigoCorrelativo = codigo, responseText = "Grabo correctamente", ruta = EstadoProceso.MENSAJE, FiltrarCodigoPeriodo = model.FiltrarCodigoPeriodo });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarDetalle(List<CertificadosDetalleViewModel> model)
        {
            Nullable<bool> EstadoProceso = new CertificadosHandler().GrabarCertificadoDetalle(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public JsonResult CargarCertificados(DataTableAjaxPostModel model, CertificadosViewModel FiltrarCertificados)
        {

            // --Definir variables de búsqueda
            FiltrarCertificados.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
            FiltrarCertificados.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
            FiltrarCertificados.FiltrarCodigoTipoCertificado = Request.Form.GetValues("FiltrarCodigoTipoCertificado").FirstOrDefault();
            FiltrarCertificados.FiltrarCodigoPeriodo = Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
            FiltrarCertificados.FiltrarCodigoTipoDocumentoReg = Request.Form.GetValues("FiltrarCodigoTipoDocumentoReg").FirstOrDefault();
            int totalResultado;
            // --Obtener los resultados enviando información de la pagínacion
            var resultado = new CertificadosHandler().RecargarTablaCertificados(model, FiltrarCertificados, out totalResultado);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        [HttpPost]
        public ActionResult CargarLotesAcumulados(DataTableAjaxPostModel model, CertificadosViewModel FiltrarCertificados)
        {
            bool resul = false;
            //List<CertificadosDetalleViewModel> resultado = new CertificadosHandler().CargarDirecUnidad(model);

            // --Definir variables de búsqueda
            FiltrarCertificados.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
            FiltrarCertificados.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
            FiltrarCertificados.FiltrarCodigoPeriodo = Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
            FiltrarCertificados.FiltrarCodigoTipoDocumentoReg = Request.Form.GetValues("FiltrarCodigoTipoDocumentoReg").FirstOrDefault();
            int totalResultado;
            // --Obtener los resultados enviando información de la pagínacion
            var resultado = new CertificadosHandler().CargarDirecLote(model, FiltrarCertificados, out totalResultado);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        [HttpPost]
        public ActionResult CargarCertificadoEntradas(DataTableAjaxPostModel model, CertificadosViewModel FiltrarCertificados)
        {
            bool resul = false;
            //List<CertificadosDetalleViewModel> resultado = new CertificadosHandler().CargarDirecUnidad(model);

            // --Definir variables de búsqueda
            FiltrarCertificados.FiltrarCodigoTipoCertificado = Request.Form.GetValues("FiltrarCodigoTipoCertificado").FirstOrDefault();
            FiltrarCertificados.FiltrarCodigoCertificado = Request.Form.GetValues("FiltrarCodigoCertificado").FirstOrDefault();
            FiltrarCertificados.FiltrarCodigoPeriodo = FiltrarCertificados.FiltrarCodigoPeriodo; //Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
            FiltrarCertificados.CodigoUnico = Request.Form.GetValues("CodigoUnico").FirstOrDefault();
            FiltrarCertificados.CodAnioSolicitud = FiltrarCertificados.CodAnioSolicitud;
            int totalResultado;
            // --Obtener los resultados enviando información de la pagínacion
            var resultado = new CertificadosHandler().CargarDirecUnidad(model, FiltrarCertificados, out totalResultado);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
        [HttpPost]
        public ActionResult CargarCertificadoRecibo(DataTableAjaxPostModel model, CertificadosViewModel FiltrarCertificados)
        {
            bool resul = false;
            int totalResultado;
            // --Obtener los resultados enviando información de la pagínacion
            var resultado = new CertificadosHandler().CargarRecibos(model, FiltrarCertificados, out totalResultado);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
        [HttpPost]
        public ActionResult CargarCertificadoEntradasVias(CertificadosViewModel FiltrarCertificados)
        {
            bool resul = false;
            List<CertificadosDetalleViewModel> resultado = new CertificadosHandler().CargarDirecUnidadVias(FiltrarCertificados);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public JsonResult CargarCertificadoNomenclatura(DataTableAjaxPostModel model, CertificadosViewModel FiltrarCertificados)
        {
            // --Definir variables de búsqueda
            FiltrarCertificados.FiltrarCodigoCertificado = Request.Form.GetValues("FiltrarCodigoCertificado").FirstOrDefault();
            FiltrarCertificados.FiltrarCodigoTipoCertificado = Request.Form.GetValues("FiltrarCodigoTipoCertificado").FirstOrDefault();
            FiltrarCertificados.FiltrarCodigoPeriodo = Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
            int totalResultado;
            // --Obtener los resultados enviando información de la pagínacion
            var resultado = new CertificadosHandler().RecargarTablaCertificadosNomenclatura(model, FiltrarCertificados, out totalResultado);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
        [HttpPost]
        public JsonResult CargarUnidadRRPP(string CodigoUnico, string Tipo)
        {
            // --Obtener los resultados enviando información de la pagínacion
            List<SelectListItem> resultado = new CertificadosHandler().CargarUnidadRRPP(CodigoUnico, Tipo);
            return Json(new { success = true, data = resultado });

        }
        [HttpPost]
        public ActionResult RegistrarRecibo(CertificadosReciboViewModel Recibo)
        {
            Nullable<bool> EstadoProceso = false;
            Recibo.Estado = "1";
            EstadoProceso = new CertificadosHandler().ProcesarRecibo(Recibo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Agregado correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult EliminarRecibo(CertificadosReciboViewModel model)
        {
            model.Estado = "2";
            Nullable<bool> EstadoProceso = new CertificadosHandler().ProcesarRecibo(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult ListarNumeroInspecciones(CertificadosViewModel model)
        {
            List<SelectListItem> resultado = new CertificadosHandler().ListarNumeroInspeccionSelect(model);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult BuscarGrabar(CertificadosViewModel model)
        {
            bool resul = false;
            CertificadosViewModel resultado = new CertificadosHandler().RecuperarGrabarCertificado(model, out resul);
            if (resul == true)
            {
                if (model.FiltrarCodigoTipoCertificado == "CEJU")
                {
                    return PartialView("_CertificadoJurisdiccion", resultado);
                }
                else if (model.FiltrarCodigoTipoCertificado == "CENO")
                {
                    return PartialView("_CertificadoNomenclatura", resultado);
                }
                else if (model.FiltrarCodigoTipoCertificado == "RNUM")
                {
                    return PartialView("_CertificadoNumeracion", resultado);
                }
                else if (model.FiltrarCodigoTipoCertificado == "CNMU")
                {
                    return PartialView("_ResolucionNumeracion", resultado);
                }
                else if (model.FiltrarCodigoTipoCertificado == "HINF")
                {
                    return PartialView("_CertificadoHojaInformativa", resultado);
                }
                else
                {
                    return PartialView("_CertificadoAcumulacion", resultado);
                }
            }
            else
            {
                return Json(new { success = resul, Carta = resultado });
            }

        }
        [HttpPost]
        public ActionResult BuscarUrbanizacion(CertificadosViewModel model)
        {
            bool resul = false;
            string resultado = new CertificadosHandler().RecuperarUrbanizacion(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarUbicacion(CertificadosViewModel model)
        {
            bool resul = false;
            List<SolicitudUnidadViewModel> resultado = new CertificadosHandler().RecuperarUbicacion(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarUbicacionTipo(CertificadosViewModel model)
        {
            bool resul = false;
            List<SolicitudUnidadViewModel> resultado = new CertificadosHandler().RecuperarUbicacionTipo(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarUbicacionSel(CertificadosViewModel model)
        {
            bool resul = false;
            List<SolicitudUnidadViewModel> resultado = new CertificadosHandler().RecuperarUbicacionSel(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarViasEsquinas(CertificadosViewModel model)
        {
            bool resul = false;
            List<SolicitudUnidadViewModel> resultado = new CertificadosHandler().RecuperarViasEsquinas(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarSolicitud(CertificadosViewModel model)
        {
            bool resul = false;
            List<CertificadosViewModel> resultado = new CertificadosHandler().RecuperarSolicitud(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarUnidades(CertificadosViewModel model)
        {
            bool resul = false;
            List<SolicitudUnidadViewModel> resultado = new CertificadosHandler().RecuperarSolUnidad(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarDiasProg(CertificadosViewModel model)
        {
            bool resul = false;
            List<SelectListItem> resultado = new CertificadosHandler().RecuperarDiasProg(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult EliminarCertificados(CertificadosViewModel model)
        {
            Nullable<bool> EstadoProceso = new CertificadosHandler().EliminarCertificado(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult EliminarCertificadoDetalle(CertificadosDetalleViewModel model)
        {
            Nullable<bool> EstadoProceso = new CertificadosHandler().EliminarCertificadoDetalle(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult GrabarCertificadosImagen(ImagenCertificado model)
        {
            string correlativo;
            Nullable<bool> EstadoProceso = new CertificadosHandler().GrabarHabilitacionImagen(model, out correlativo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente", correl = correlativo });
            }
            return Json(new { success = false, responseText = correlativo, correl = correlativo });
        }
        [HttpPost]
        public ActionResult Imagen(string imagen)
        {
            string ImagenResult = new CertificadosHandler().VerImagenHabilitacion(imagen.Replace(",", "\\"));
            if (ImagenResult != "")
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente", Imagen = ImagenResult });
            }
            return Json(new { success = false, responseText = "No se entontró imagen" });
        }
    }
}