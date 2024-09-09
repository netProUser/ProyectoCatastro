using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Funcionalidad.Vias;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;


namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class TipoHabilitacionController : Controller
    {
        // GET: TipoHabilitacion
        public ActionResult Index(FiltrarTipoHabilitacionViewModel TipoHabilitacion)
        {
            return View(TipoHabilitacion);
        }

        [HttpGet]
        public PartialViewResult Registrar()
        {

            return PartialView("_Registrar", new RegistroTipoHabilitacionViewModel() {Estado=1 });
        }
        [HttpGet]
        public PartialViewResult Editar(string id)
        {
            RegistroTipoHabilitacionViewModel TipoHabilitacion = new TipoHabilitacionHandler().BuscarTipoHabilitacion(id);
            TipoHabilitacion.Estado = 2;
            return PartialView("_Registrar", TipoHabilitacion);

        }

        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(RegistroTipoHabilitacionViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            Nullable<bool> EstadoProceso = new TipoHabilitacionHandler().ProcesarHabilitacion(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        
        [HttpGet]
        public PartialViewResult Eliminar(string id)
        {
            RegistroTipoHabilitacionViewModel TipoHabilitacion = new TipoHabilitacionHandler().BuscarTipoHabilitacion(id);
            TipoHabilitacion.Estado = 3;
            return PartialView("_Eliminar", TipoHabilitacion);
        }
        [HttpPost]
        public JsonResult Eliminar(RegistroTipoHabilitacionViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new TipoHabilitacionHandler().ProcesarHabilitacion(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }       
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        [HttpPost]
        public JsonResult CargarGrid(DataTableAjaxPostModel model, FiltrarTipoHabilitacionViewModel TipoHabilitacion)
        {
            
                // --Definir variables de búsqueda
                var NombreTipoHabilitacion = Request.Form.GetValues("NombreTipoHabilitacion").FirstOrDefault();
                TipoHabilitacion.NombreTipoHabilitacion = NombreTipoHabilitacion;

                // --Variables por defecto de datatables
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal;
                // --Obtener los resultados enviando información de la pagínacion
                var result = new TipoHabilitacionHandler().RecargarGrid(draw, start, length, pageSize, skip, model, TipoHabilitacion, out recordsTotal);

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result });
            

        }
    }
}