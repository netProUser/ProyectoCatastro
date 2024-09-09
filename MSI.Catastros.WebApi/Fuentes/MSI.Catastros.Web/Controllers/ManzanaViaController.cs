using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.ManzanaVia;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Funcionalidad.Manzana;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class ManzanaViaController : Controller
    {
        // GET: Manzana Vía
        public ActionResult Index(FiltrarManzanaViaViewModel ManzanaVia)
        {
            ManzanaVia.DistritoManzanaVia = "SAN ISIDRO";
            ManzanaVia.ListadoSectores = new ManzanaHandler().ListadoSector();
            ManzanaVia.ParametroVia = new ManzanaViaHandler().ParametroVia();
            ManzanaVia.listManzanaVia = new ManzanaViaHandler().ListarManzanaVia("");
            return View(ManzanaVia);
        }
        [HttpGet]
        public PartialViewResult Registrar()
        {
            RegistroManzanaViaViewModel RegistroManzanaVia = new RegistroManzanaViaViewModel();
            RegistroManzanaVia.Estado = 1;
            RegistroManzanaVia.PeriodoReg = DateTime.Now.Year.ToString();
            RegistroManzanaVia.ParametroVia = new ManzanaViaHandler().ListarVias();
            RegistroManzanaVia.ParametroManzana = new ManzanaViaHandler().ParametroManzana("0");
            RegistroManzanaVia.ParametroSector = new ManzanaViaHandler().ParametroSector();
            RegistroManzanaVia.ParametroCuadra = new ManzanaViaHandler().ParametroCuadra("0");
            RegistroManzanaVia.ParametroLado = new ManzanaViaHandler().ParametroLado();
            RegistroManzanaVia.ListAlturaVia = new ManzanaViaHandler().ListarParamAlturaVia();
            RegistroManzanaVia.ListadoZonificacionSuelo = new ManzanaHandler().ListadoZonificacionSuelo();
            RegistroManzanaVia.ListadoDescripcionZonificacionUso = new ManzanaHandler().ListadoZonificacionSueloDescripcion();
            RegistroManzanaVia.Distrito = "SAN ISIDRO";
            return PartialView("_Registrar", RegistroManzanaVia); ;
        }
        [HttpPost]
        public ActionResult Cuadras(string id)
        {
            var listCuadras = new ManzanaViaHandler().ParametroCuadra(id);
            return Json(listCuadras, "json");
        }
        [HttpGet]
        public PartialViewResult Editar(string id, string sector, string manzana, string vias)
        {
            ViewBag.isReadOnly = true;
            RegistroManzanaViaViewModel ManzanaVia = new ManzanaViaHandler().BuscarManzanaVia(id, sector, manzana, vias);
            ManzanaVia.Estado = 2;
            ManzanaVia.PeriodoReg = System.DateTime.Now.Year.ToString();
            ManzanaVia.ListAlturaVia = new ManzanaViaHandler().ListarParamAlturaVia();
            ManzanaVia.ListadoZonificacionSuelo = new ManzanaHandler().ListadoZonificacionSuelo();
            ManzanaVia.ListadoDescripcionZonificacionUso = new ManzanaHandler().ListadoZonificacionSueloDescripcion();
            return PartialView("_Registrar", ManzanaVia);
        }

        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(RegistroManzanaViaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            BE.SIC_RETORNO retorno = new ManzanaViaHandler().ProcesarManzanaVia(modelo);
            if (retorno.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            else if (retorno.Ok == false && retorno.NoMENSAJE == 8556)
            {
                return Json(new { success = false, responseText = retorno.MENSAJE });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpGet]
        public ActionResult Eliminar(string id, string sector, string manzana, string vias)
        {
            RegistroManzanaViaViewModel ManzanaVia = new ManzanaViaHandler().BuscarManzanaVia(id, sector, manzana, vias);
            ManzanaVia.Estado = 3;
            return PartialView("_Eliminar", ManzanaVia);
        }

        [HttpPost]
        public ActionResult Eliminar(RegistroManzanaViaViewModel modelo)
        {

            modelo.Estado = 3;
            BE.SIC_RETORNO retorno = new ManzanaViaHandler().ProcesarManzanaVia(modelo);
            if (retorno.Ok == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public JsonResult CargarGridDetalle(DataTableAjaxPostModel model, RegistroManzanaViaViewModel RegistroManzanaVia)
        {
            
                RegistroManzanaVia.CodigoSectorReg = Request.Form.GetValues("CodigoSectorReg").FirstOrDefault();
                RegistroManzanaVia.CodigoManzanaReg = Request.Form.GetValues("CodigoManzanaReg").FirstOrDefault();
                int totalResultado;
                var resultado = new ManzanaViaHandler().RecargarGridDetalle(model, RegistroManzanaVia, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }
        [HttpPost]
        public ActionResult CargarZonificacion(RegistroManzanaViaViewModel modelo)
        {
            List<Funcionalidad.ManzanaVia.Zonificacion> Manzana = new ManzanaViaHandler().BuscarZonificacion(modelo.CodigoManzanaReg, modelo.CodigoSectorReg, modelo.CodigoViaReg, modelo.CodigoManzanaViaReg);

            return Json(new { success = true, data = Manzana });
        }

        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarManzanaViaViewModel MazanaVia)
        {
            //try
            //{
                var CodigoViaReg = Request.Form.GetValues("CodigoViaReg").FirstOrDefault();
                MazanaVia.CodigoVia = CodigoViaReg;
                var NombreSector = Request.Form.GetValues("NombreSector").FirstOrDefault();
                MazanaVia.NombreSector = NombreSector;
                var NombreManzanaReg = Request.Form.GetValues("NombreManzanaReg").FirstOrDefault();
                MazanaVia.NombreManzana = NombreManzanaReg;

                // --Variables por defecto de datatables
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal;
                // --Obtener los resultados enviando información de la pagínacion
                var result = new ManzanaViaHandler().RecargarGrid(draw, start, length, pageSize, skip, model, MazanaVia, out recordsTotal);

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result });
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

        }

    }
}