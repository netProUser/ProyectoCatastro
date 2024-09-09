using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.DetalleVias;
using MSI.Catastros.Web.Funcionalidad.Lotes;
using MSI.Catastros.Web.Funcionalidad.MobiliarioUrbano;
using MSI.Catastros.Web.Funcionalidad.MobiliarioUrbanoFormulario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class MobiliarioUrbanoController : Controller
    {
        //
        // GET: /MobiliarioUrbano/
        public ActionResult Index()
        {
            ViewBag.listVias = new DetalleViasHandler().ListarVias();
            return View(new MobiliarioUrbanoViewModel()
            {
                Distrito = "SAN ISIDRO",
                codDistrito = "31",
                listSector = new MSI.Catastros.Web.Funcionalidad.Manzana.ManzanaHandler().ListadoSector(),
            });
        }
        [HttpPost]
        public ActionResult ListarLote(string codSector, string codManzana)
        {
            List<SelectListItem> resultado = new LotesHandler().ListarColindanteLoteMobiliarioUrbanoSelect(new SolicitudUnidadViewModel()
            {
                CodigoSector = codSector,
                CodigoManzana = codManzana,
                Estatico = true
            });
            return Json(new { success = true, data = resultado });
        }
        /*Listado*/
        [HttpPost]
        public ActionResult ListarClase()
        {
            //try
            //{
                var datas = new MobiliarioUrbanoFormularioHandler().ListadoClase();
                return Json(new { success = true, data = datas });
            //}
            //catch (Exception)
            //{
            //}
            //return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult ListarSubClase(SubClaseViewModel _modelo)
        {
            //try
            //{
                var datas = new MobiliarioUrbanoFormularioHandler().ListadoSubClase(_modelo);
                return Json(new { success = true, data = datas });
            //}
            //catch (Exception)
            //{
            //}
            //return Json(new { success = false, data = "" });
        }

        [HttpPost]
        public ActionResult ListarObjeto(ObjetoViewModel _modelo)
        {
            //try
            //{
                var datas = new MobiliarioUrbanoFormularioHandler().ListadoObjeto(_modelo);
                return Json(new { success = true, data = datas });
            //}
            //catch (Exception)
            //{
            //}
            //return Json(new { success = false });
        }


        [HttpPost]
        public ActionResult ListarUnidad(formularioDinamico modelo)
        {
            //try
            //{
                var datas = new MobiliarioUrbanoHandler().ListadoUnidad(modelo);
                return Json(new { success = true, data = datas });
            //}
            //catch (Exception)
            //{
            //}
            //return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult RegistrarFormulario(formularioDinamico modelo)
        {
            if (ModelState.IsValid)
            {
                Nullable<bool> EstadoProceso = new MobiliarioUrbanoHandler().ProcesoSubClase(modelo);
                if (EstadoProceso == true)
                {
                    return Json(new { success = true, responseText = "Grabo correctamente" });
                }
            }
            return Json(new { success = true, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult BuscarUnidad(formularioDinamico modelo)
        {
            //try
            //{
                var datas = new MobiliarioUrbanoHandler().BuscarUnidad(modelo);
                return Json(new { success = true, responseText = "Se Recupero la Información", data = datas });
            //}
            //catch (Exception)
            //{
            //}
            //return Json(new { success = false });
        }

    }
}