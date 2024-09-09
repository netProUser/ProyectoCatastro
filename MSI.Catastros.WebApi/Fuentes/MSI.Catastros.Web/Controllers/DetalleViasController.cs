using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.DetalleVias;
using MSI.Catastros.Web.Funcionalidad.ManzanaVia;
using MSI.Catastros.Web.Funcionalidad.Vias;
using MSI.Catastros.Web.Funcionalidad.Parametros;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class DetalleViasController : Controller
    {
        // GET: Vias
        public ActionResult Index(FiltrarDetalleViasViewModel DetalleVias)
        {
            
            DetalleVias.listVia = new DetalleViasHandler().ListarVias();
            DetalleVias.ParamDistritoVia = "SAN ISIDRO";
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListarDetalleVias", DetalleVias);
            }
            return View(DetalleVias);
        }

        [HttpGet]
        public PartialViewResult Registrar()
        {
            ViewBag.listVias = new DetalleViasHandler().ListarVias();
            ViewBag.listAnchoVia = new ParametrosHandler().ListarParametosAnchoVia();
            ViewBag.ListNumeroCuadras = new ParametrosHandler().ListadoCuadrasVias();
            RegistroDetalleViaViewModel RegistroVia = new RegistroDetalleViaViewModel();
            RegistroVia.Estado = 1;
            RegistroVia.Distrito = "SAN ISIDRO";
            return PartialView("_Registrar", RegistroVia);
        }

        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(RegistroDetalleViaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            Nullable<bool> EstadoProceso = new DetalleViasHandler().ProcesarDetalleVias(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            else
            {
                return Json(new { success = false, responseText = "Ya se encuentra registrado el número de Cuadra para la Vía seleccionada" });
            }
        }

        [HttpGet]
        public PartialViewResult Editar(string idDetalle, string idVia)
        {
            ViewBag.listVias = new DetalleViasHandler().ListarVias();
            ViewBag.listAnchoVia = new ParametrosHandler().ListarParametosAnchoVia();
            RegistroDetalleViaViewModel RegistroVia = new DetalleViasHandler().BuscarDetalleVia(idDetalle, idVia);
            RegistroVia.Estado = 2;
            RegistroVia.Distrito = "SAN ISIDRO";
            return PartialView("_Registrar", RegistroVia);

        }

        [HttpPost]
        public ActionResult Cuadras(string id)
        {
            var listCuadras = new ManzanaViaHandler().ParametroCuadra(id).OrderBy(e => e.Text);
            return Json(listCuadras, "json");
        }

        [HttpGet]
        public ActionResult Eliminar(string idDetalle, string idVia)
        {
            RegistroDetalleViaViewModel RegistroVia = new DetalleViasHandler().BuscarDetalleVia(idDetalle, idVia);
            RegistroVia.Estado = 3;
            return PartialView("_Eliminar", RegistroVia);
        }

        [HttpPost]
        public ActionResult Eliminar(RegistroDetalleViaViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new DetalleViasHandler().ProcesarDetalleVias(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpGet]
        public ActionResult ListarGridVias(string id)
        {
            RegistroViaViewModel RegistroVia = new ViasHandler().BuscarVia(id);
            RegistroVia.Estado = 3;
            return PartialView("_Eliminar", RegistroVia);
        }

        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarDetalleViasViewModel Filtroviasdetalle)
        {
            int totalResultado;
            var resultado = new DetalleViasHandler().ListarGrid(model, out totalResultado, Filtroviasdetalle);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }

        [HttpPost]
        public ActionResult CargarGrid2(DataTableAjaxPostModel model, FiltrarDetalleViasViewModel Filtroviasdetalle)
        {
            int resultadoFiltrados;
            int totalResultadoFiltrados;
            var res = new DetalleViasHandler().ListarGrid1(model, out resultadoFiltrados, out totalResultadoFiltrados, Filtroviasdetalle);

            var resultado = new List<DetalleViaViewModel>(res.Count);
            foreach (var s in res)
            {
                resultado.Add(new DetalleViaViewModel
                {
                    CodigoVia = s.CODVIA,
                    DescVia = s.TXTVIA,
                    NumCuadra = s.NUMCUADRA,
                    CodigoDetalleVia = s.CODCORRVIADETA,
                    txtMedidaViaNormativa = s.NUMANCHVIA.ToString(),
                    AnchoVia = s.TXTANCHOVIA
                });
            }
            return Json(new { draw = model.draw, recordsTotal = totalResultadoFiltrados, recordsFiltered = resultadoFiltrados, data = resultado });


        }

    }
}
