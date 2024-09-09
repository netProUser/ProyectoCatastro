using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Sectores;
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
    public class SectoresController : Controller
    {
        // GET: Sectores
        public ActionResult Index(FiltrarSectoresViewModel Sectores)
        {
            Sectores.listDistritos = new DistritosHandler().ListarDistritos("");
            return View(Sectores);

        }
        [HttpGet]
        public PartialViewResult Registrar()
        {
            List<DistritoViewModel> lisDistritos = new DistritosHandler().ListarDistritos("");
            return PartialView("_Registrar", new RegistroSectorViewModel() { Estado = 1, Distritos = lisDistritos });
        }
        [HttpGet]
        public PartialViewResult Editar(string id)
        {
            RegistroSectorViewModel Sectores = new SectoresHandler().BuscarSectores(id);
            Sectores.Estado = 2;
            return PartialView("_Registrar", Sectores);

        }
        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(RegistroSectorViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            Nullable<bool> EstadoProceso = new SectoresHandler().ProcesarSectores(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            RegistroSectorViewModel Sector = new SectoresHandler().BuscarSectores(id);
            Sector.Estado = 3;
            return PartialView("_Eliminar", Sector);
        }
        [HttpPost]
        public ActionResult Eliminar(RegistroSectorViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new SectoresHandler().ProcesarSectores(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarSectoresViewModel FiltroSectores)
        {
            int totalResultado;
            var resultado = new SectoresHandler().ListarGrid(model, out totalResultado, FiltroSectores);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }


        [HttpPost]
        public ActionResult CargarGrid2(DataTableAjaxPostModel model, FiltrarSectoresViewModel Sectores)
        {
            
                // --Definir variables de búsqueda
                var NombreSector = Request.Form.GetValues("NombreSector").FirstOrDefault();
                Sectores.NombreSector = NombreSector;
                var CodigoDistrito = Request.Form.GetValues("CodigoDistrito").FirstOrDefault();
                Sectores.CodigoDistrito = CodigoDistrito;

                // --Variables por defecto de datatables
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal;
                // --Obtener los resultados enviando información de la pagínacion
                var result = new SectoresHandler().RecargarGrid(draw, start, length, pageSize, skip, model, Sectores, out recordsTotal);

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result });
            

        }
    }
}