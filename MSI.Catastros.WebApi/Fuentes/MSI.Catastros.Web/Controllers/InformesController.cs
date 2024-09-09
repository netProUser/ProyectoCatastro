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
using MSI.Catastros.Web.Funcionalidad.Informes;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using BE = MSI.Catastros.BusinessEntities;
using Proc = MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo;
using MSI.Catastros.Web.Funcionalidad.Lotes;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class InformesController : Controller
    {
        // GET: Informes
        public ActionResult Index(InformesViewModel informes)
        {
            
            informes.ListTipoInforme = new List<SelectListItem>() { 
                new SelectListItem(){ Value = "INFV", Text = "Informe de Verificación Catastral"},
                new SelectListItem(){ Value = "INFT", Text = "Informe de Análisis Catastral"},
                new SelectListItem(){ Value = "INFN", Text = "Informe de Actualización Catastral"}
            };

            return View(new InformesViewModel(){
                ListVersionInforme = new List<SelectListItem>(),
                ListTipoInforme =  new List<SelectListItem>() { 
                    new SelectListItem(){ Value = "INFV", Text = "INFORME DE VERIFICACIÓN CATASTRAL"},
                    new SelectListItem(){ Value = "INFT", Text = "INFORME TÉCNICO"},
                    new SelectListItem(){ Value = "INFN", Text = "INFORME DE CERTIFICADO DE NUMERACIÓN"}
                },
                ListTipoSolicitud = new Proc.ProcedimientoNuevoHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new Proc.ProcedimientoNuevoHandler().ListadoTipoDocumento(),
                ListUnidades = new List<SelectListItem>(),
                ListTipoPersona = new InformesHandler().ListadoTipoPersona(),
                NombreFirma = VariablesWeb.NombrePersona + " - " + VariablesWeb.NombrePerfil
            });
        }
        [HttpPost]
        public ActionResult Grabar(InformesViewModel model)
        {
            Nullable<bool> EstadoProceso = new InformesHandler().GrabarInforme(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult BuscarGrabar(InformesViewModel model)
        {
            bool resul = false;
            InformesViewModel resultado = new InformesHandler().RecuperarGrabarInformes(model, out resul);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarSolicitudPersona(InformesViewModel model)
        {
            bool resul = false;
            InformesViewModel resultado = new InformesHandler().CargarSolicitante(model);
            return Json(new { success = resul, Solicitud = resultado });

        }
       
        [HttpPost]
        public ActionResult BuscarSolicitud(InformesViewModel model)
        {
            bool resul = false;
            List<InformesViewModel> resultado = new InformesHandler().RecuperarSolicitud(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });

        }
        [HttpPost]
        public ActionResult BuscarLineasConstructivas(string codigoUnico, string codigoCatastral)
        {
            String resultado = new InformePdfHandler().ObtenerHtmlConstrucciones(codigoUnico, codigoCatastral);
            return Json(new { HTML = resultado });
        }
        [HttpPost]
        public ActionResult BuscarOtrasInstalaciones(string codigoUnico, string codigoCatastral)
        {
            String resultado = new InformePdfHandler().ObtenerHtmlInstalaciones(codigoUnico, codigoCatastral);
            return Json(new { HTML = resultado });
        }
        [HttpPost]
        public ActionResult BuscarUbicacion(InformesViewModel model)
        {
            bool resul = false;
            List<SolicitudUnidadViewModel> resultado = new InformesHandler().RecuperarUbicacion(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult BuscarSolicitudSel(InformesViewModel model)
        {
            bool resul = false;
            List<SelectListItem> resultado = new InformesHandler().RecuperarSolUnidadSelect(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult CrearInforme(InformesViewModel model)
        {
            BE.SIC_RETORNO EstadoProceso = new InformesHandler().CrearInforme(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = EstadoProceso.MENSAJE });

        }
        [HttpPost]
        public JsonResult CargarInformes(DataTableAjaxPostModel model, InformesViewModel FiltrarInformes)
        {
            
                // --Definir variables de búsqueda
                FiltrarInformes.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
                FiltrarInformes.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
                FiltrarInformes.FiltrarCodigoPeriodo = Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
                FiltrarInformes.FiltrarCodigoTipoDocumentoReg = Request.Form.GetValues("FiltrarCodigoTipoDocumentoReg").FirstOrDefault();
                int totalResultado;
                // --Obtener los resultados enviando información de la pagínacion
                var resultado = new InformesHandler().RecargarTablaInformes(model, FiltrarInformes, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        [HttpPost]
        public ActionResult BuscarUnidades(InformesViewModel model)
        {
            bool resul = false;
            List<SolicitudUnidadViewModel> resultado = new InformesHandler().RecuperarSolUnidad(model);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpGet]
        public PartialViewResult RegistrarDetalle()
        {
            return PartialView("_RegistrarDetalle", new RegistrarInformeDetalle());
        }
        [HttpPost]
        public PartialViewResult EditarDetalle(RegistrarInformeDetalle model)
        {
            RegistrarInformeDetalle InformeDetalle = new InformesHandler().RecuperarInformeDetalle(model);
            InformeDetalle.Estado = "2";
            return PartialView("_RegistrarDetalle", InformeDetalle);
        }
        [HttpPost]
        public ActionResult GrabarSubDetalle(List<RegistrarInformeDetalle> model)
        {
            Nullable<bool> EstadoProceso = new InformesHandler().GrabarInformeSubDetalle(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarSubDetalleUnique(RegistrarInformeDetalle model)
        {
            Nullable<bool> EstadoProceso = new InformesHandler().GrabarInformeSubDetalleUnique(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult RegistrarDetalle(RegistrarInformeDetalle modelo)
        {
            string correlativo = "";
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            Nullable<bool> EstadoProceso = new InformesHandler().ProcesarDetalle(modelo,out correlativo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, Codigo = correlativo, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false,  responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult EliminarInforme(RegistrarInformeDetalle model)
        {
            Nullable<bool> EstadoProceso = new InformesHandler().EliminarInforme(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult EliminarDetalle(RegistrarInformeDetalle model)
        {
            Nullable<bool> EstadoProceso = new InformesHandler().EliminarDetalle(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        public JsonResult CargarInformeDetalle(DataTableAjaxPostModel model, InformesViewModel FiltrarDetalle)
        {
            
                FiltrarDetalle.FiltrarCodigoInforme = Request.Form.GetValues("FiltrarCodigoInforme").FirstOrDefault();
                FiltrarDetalle.FiltrarCodigoPeriodo = Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
                FiltrarDetalle.FiltrarCodigoTipoInforme = Request.Form.GetValues("FiltrarCodigoTipoInforme").FirstOrDefault();
                FiltrarDetalle.FiltrarCodigoCorrelativo = Request.Form.GetValues("FiltrarCodigoCorrelativo").FirstOrDefault();
                List<RegistrarInformeDetalle> resultado = new InformesHandler().CargarDetalle(FiltrarDetalle);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }
        public JsonResult CargarInformeSubDetalle(DataTableAjaxPostModel model, InformesViewModel FiltrarDetalle)
        {
            
                FiltrarDetalle.FiltrarCodigoInforme = Request.Form.GetValues("FiltrarCodigoInforme").FirstOrDefault();
                FiltrarDetalle.FiltrarCodigoPeriodo = Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
                FiltrarDetalle.FiltrarCodigoTipoInforme = Request.Form.GetValues("FiltrarCodigoTipoInforme").FirstOrDefault();
                FiltrarDetalle.FiltrarCodigoCorrelativo = Request.Form.GetValues("FiltrarCodigoCorrelativo").FirstOrDefault();
                List<RegistrarInformeDetalle> resultado = new InformesHandler().CargarSubDetalle(FiltrarDetalle);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public ActionResult GrabarImagen(RegistrarArchivos model)
        {
            string ruta = ""; string ext = "";
            Nullable<bool> EstadoProceso = new InformesHandler().GrabarLoteImagen(model,out ruta, out ext);
            //byte[] bytes = new InformesHandler().RecuperarLoteImagen(ruta);
            //if (bytes == null || !bytes.Any())
            //    return Content("false");
            //return File(bytes, "image/png");
            //return Content('{"url": "xedrs"}');
            ImagenInfo imagenInfo = new ImagenInfo() { url = Url.Content("~") + "Informes/CargarImagenes/" + ruta + "/" + ext   };
            ImagenModel imagen = new ImagenModel() { data = imagenInfo, success = true };
            return new JsonResult()
            {
                Data = imagen,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
            //if (EstadoProceso == true)
            //{
            //    return Json(new { success = true, responseText = "Imagen subida correctamente " });
            //}
            //return Json(new { success = false, responseText = "Error del servidor" });
        }

        [HttpGet]
        public ActionResult CargarImagenes(string id, string extension)
        {
            string url = "C://FileServer/DOCUMENTOS/INFORMES/IMAGENES/" + id + "." + extension;
            byte[] bytes = new InformesHandler().RecuperarLoteImagen(url);
            if (bytes == null || !bytes.Any())
                return Content("false");
            return File(bytes, "image/png");
            //return Json(new { initialPreview = new string[] { "<img src='C:\\\\ARCHIVOS\\REPOSIC\\2018\\JULIO\\MSICAS20180709122321316.PNG' class='file-preview-image' alt='Desert'>" } });
        }

private ActionResult Content(char p)
{
 	throw new NotImplementedException();
}
    }
}