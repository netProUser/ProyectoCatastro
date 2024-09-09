using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Distritos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]    
    [LogExceptionAttribute]
    public class DistritosController : Controller
    {
        // GET: Distritos
        public ActionResult Index(FiltrarDistritosViewModel listDistrito)
        {
            return View(listDistrito);
        }
        [HttpGet]
        public PartialViewResult Registrar()
        {
            return PartialView("_Editar", new RegistroDistritoViewModel()
            {
                Departamento = new DistritosHandler().ListarDepartamento(),
                Estado = 1
            });
        }
        [HttpGet]
        public PartialViewResult Editar(string id)
        {
            RegistroDistritoViewModel Distritos = new DistritosHandler().BuscarDistritos(id);
            Distritos.Estado = 2;
            return PartialView("_Registrar", Distritos);
        }

        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(RegistroDistritoViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            Nullable<bool> EstadoProceso = new DistritosHandler().ProcesarHabilitacion(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            var result = new DistritosHandler().ListarDistritos("").Where(e => e.CodigoDistrito == id).First();
            var model = new RegistroDistritoViewModel
            {
                CodigoDistrito = result.CodigoDistrito,
                NombreDistrio = result.NombreDistrio,
                Abreviatura = result.Abreviatura,
                Estado = 3
            };
            return PartialView("_Eliminar", model);
        }
        [HttpPost]
        public ActionResult Eliminar(RegistroDistritoViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new DistritosHandler().ProcesarHabilitacion(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarDistritosViewModel FiltroSectores)
        {
            int totalResultado;
            var resultado = new DistritosHandler().ListarGrid(model, out totalResultado, FiltroSectores);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }

    }
}