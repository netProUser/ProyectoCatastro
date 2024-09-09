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
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.ActualizacionEstado;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class ActualizacionEstadoController : Controller
    {
        // GET: ActualizacionEstado
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CargarUnidadSinPag(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltrarUnidadCatastral)
        {
            int totalResultado = 0;
            List<UnidadCatastralViewModel> resultado;
            if (FiltrarUnidadCatastral.FiltrarCodigoSector == null)
            {
                resultado = new List<UnidadCatastralViewModel>();
            }
            else
            {
                resultado = new ActualizacionEstadoHandler().ListarGridSinPag(model, FiltrarUnidadCatastral, out totalResultado);
            }
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        [HttpPost]
        public JsonResult CargarUnidad(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltrarUnidadCatastral)
        {
            int totalResultado = 0;
            List<UnidadCatastralViewModel> resultado;
            if (FiltrarUnidadCatastral.FiltrarCodigoSector == null) {
                resultado = new List<UnidadCatastralViewModel>();
            }
            else {
                resultado = new ActualizacionEstadoHandler().ListarGrid(model, out totalResultado, FiltrarUnidadCatastral);
            }
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        [HttpPost]
        public ActionResult Habilitacion(FiltrarUnidadCatastralViewModel model)
        {
            BE.SIC_RETORNO EstadoProceso = new ActualizacionEstadoHandler().HabilitacionUnidad(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = EstadoProceso.MENSAJE });
            }
            return Json(new { success = false, responseText = EstadoProceso.MENSAJE });
        }
        [HttpPost]
        public ActionResult DeshabilitarUnidad(FiltrarUnidadCatastralViewModel model)
        {
            BE.SIC_RETORNO EstadoProceso = new ActualizacionEstadoHandler().DeshabilitacionUnidad(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = EstadoProceso.MENSAJE });
            }
            return Json(new { success = false, responseText = EstadoProceso.MENSAJE });
        }
        [HttpPost]
        public ActionResult ActivacionLote(FiltrarUnidadCatastralViewModel model)
        {
            BE.SIC_RETORNO EstadoProceso = new ActualizacionEstadoHandler().ActivacionLote(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = EstadoProceso.MENSAJE });
            }
            return Json(new { success = false, responseText = EstadoProceso.MENSAJE });
        }
        [HttpPost]
        public ActionResult ActivacionUnidad(FiltrarUnidadCatastralViewModel model)
        {
            if (model.AnularLote == true) {
                BE.SIC_RETORNO EstadoProcesoLote = new ActualizacionEstadoHandler().ActivacionLote(model);
            }
            BE.SIC_RETORNO EstadoProceso = new ActualizacionEstadoHandler().ActivacionUnidad(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = EstadoProceso.MENSAJE });
            }
            return Json(new { success = false, responseText = EstadoProceso.MENSAJE });
        }
        [HttpPost]
        public ActionResult Anulacion(FiltrarUnidadCatastralViewModel model)
        {
            model.AnularLote = false;
            BE.SIC_RETORNO EstadoProceso = new ActualizacionEstadoHandler().AnulacionUnidad(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = EstadoProceso.MENSAJE });
            }
            return Json(new { success = false, responseText = EstadoProceso.MENSAJE });
        }
        [HttpPost]
        public ActionResult AnulacionUnidadLote(FiltrarUnidadCatastralViewModel model)
        {
            model.AnularLote = true;
            BE.SIC_RETORNO EstadoProceso = new ActualizacionEstadoHandler().AnulacionUnidad(model);
            BE.SIC_RETORNO EstadoProceso2 = new ActualizacionEstadoHandler().AnulacionLote(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = EstadoProceso.MENSAJE });
            }
            return Json(new { success = false, responseText = EstadoProceso.MENSAJE });
        }
        
        [HttpPost]
        public ActionResult AnulacionLote(FiltrarUnidadCatastralViewModel model)
        {
            model.AnularLote = true;
            BE.SIC_RETORNO EstadoProceso = new ActualizacionEstadoHandler().AnulacionLote(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = EstadoProceso.MENSAJE });
            }
            return Json(new { success = false, responseText = EstadoProceso.MENSAJE });
        }
        //nuevo
        [HttpPost]
        public ActionResult Copiar(FiltrarUnidadCatastralViewModel model)
        {
            model.AnularLote = false;
            //BE.SIC_RETORNO EstadoProceso = new ActualizacionEstadoHandler().AnulacionUnidad(model);

            BE.SIC_RETORNO EstadoProceso = new ActualizacionEstadoHandler().ProcesarMigracionEstaticoTemporal(model);
            //BE.SIC_RETORNO entSIC_RETORNO_ACT = new UnidadCatastralHandler().ActualizarFlgTemporal(CodUniCat, aniosol, numsol, tiposol, docsol, "T");


            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = EstadoProceso.MENSAJE });
            }
            return Json(new { success = false, responseText = EstadoProceso.MENSAJE });
        }

    }
}