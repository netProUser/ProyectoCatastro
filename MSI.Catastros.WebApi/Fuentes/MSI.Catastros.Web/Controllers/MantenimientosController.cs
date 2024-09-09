using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Funcionalidad.Distritos;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class MantenimientosController : Controller
    {
        // GET: Sectores
        public ActionResult Index(MantenimientosViewModel Sectores)
        {
            return View(Sectores);
        }
        [HttpGet]
        public PartialViewResult RegistrarUso()
        {
            return PartialView("_Registrar", new TablaViewModel() { Estado = 1, ListaCampo = new MantenimientosHandler().CargarUsoClase(), TipoMantenimiento = "UsoPredio" });
        }
        

        
        [HttpPost]
        public ActionResult CargarGridUso(DataTableAjaxPostModel model, MantenimientosViewModel FiltroMantenimiento)
        {
            int totalResultado;
            var resultado = new MantenimientosHandler().ListarGridUso(model, out totalResultado, FiltroMantenimiento);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }

        [HttpPost]
        public ActionResult CargarGridZonificacion(DataTableAjaxPostModel model, MantenimientosViewModel FiltroMantenimiento)
        {
            int totalResultado;
            var resultado = new MantenimientosHandler().CargarGridZonificacion(model, out totalResultado, FiltroMantenimiento);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }

        [HttpPost]
        public ActionResult CargarGridInscripcion(DataTableAjaxPostModel model, MantenimientosViewModel FiltroMantenimiento)
        {
            int totalResultado;
            var resultado = new MantenimientosHandler().ListarGridInscripcion(model, out totalResultado, FiltroMantenimiento);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
        [HttpPost]
        public ActionResult CargarGridPuerta(DataTableAjaxPostModel model, MantenimientosViewModel FiltroMantenimiento)
        {
            int totalResultado;
            var resultado = new MantenimientosHandler().ListarGridPuerta(model, out totalResultado, FiltroMantenimiento);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
        [HttpPost]
        public ActionResult CargarGridTipoInterior(DataTableAjaxPostModel model, MantenimientosViewModel FiltroMantenimiento)
        {
            int totalResultado;
            var resultado = new MantenimientosHandler().ListarGridTipoInterior(model, out totalResultado, FiltroMantenimiento);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
        [HttpPost]
        public ActionResult CargarGridEdificacion(DataTableAjaxPostModel model, MantenimientosViewModel FiltroMantenimiento)
        {
            int totalResultado;
            var resultado = new MantenimientosHandler().ListarGridEdificacion(model, out totalResultado, FiltroMantenimiento);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }

        [HttpPost]
        public ActionResult CargarOtrosDocumentos(DataTableAjaxPostModel model, MantenimientosViewModel FiltroMantenimiento)
        {
            int totalResultado;
            var resultado = new MantenimientosHandler().CargarOtrosDocumentos(model, out totalResultado, FiltroMantenimiento);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }



        [HttpGet]
        public PartialViewResult Registrar(string tipo)
        {
            return PartialView("_Registrar", new TablaViewModel() { Estado = 1, TipoMantenimiento = tipo });
        }
        [HttpGet]
        public PartialViewResult Editar(string tipo, string id)
        {
            TablaViewModel Mantenimiento = new MantenimientosHandler().Recuperar(tipo, id);
            Mantenimiento.Estado = 2;Mantenimiento.TipoMantenimiento = tipo;
            return PartialView("_Registrar", Mantenimiento);

        }
        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(TablaViewModel modelo)
        {
            if (!ModelState.IsValid) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            Nullable<bool> EstadoProceso = new MantenimientosHandler().ProcesarMantenimientos(modelo);
            if (EstadoProceso == true) return Json(new { success = true, responseText = "Grabo correctamente" });
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpGet]
        public ActionResult Eliminar(string tipo, string id)
        {
            TablaViewModel Mantenimiento = new MantenimientosHandler().Recuperar(tipo, id);
            Mantenimiento.Estado = 3; Mantenimiento.TipoMantenimiento = tipo;
            return PartialView("_Eliminar", Mantenimiento);
        }
        [HttpPost]
        public ActionResult Eliminar(TablaViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new MantenimientosHandler().ProcesarMantenimientos(modelo);
            if (EstadoProceso == true) return Json(new { success = true, responseText = "Elimino correctamente" });
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }


    }
}