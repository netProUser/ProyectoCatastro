using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.Manzana;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using BE = MSI.Catastros.BusinessEntities;
namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class ManzanaController : Controller
    {
        // GET: Manzana
        public ActionResult Index(FiltrarManzanaViewModel Manzana)
        {
            //Manzana.CodigoManzana = "001";
            Manzana.DistritoManzana = "SAN ISIDRO";

            Manzana.listManzana = new ManzanaHandler().ListarManzana(Manzana);
            Manzana.ListadoSectores = new ManzanaHandler().ListadoSector();
            Manzana.ListadoTematica = new ManzanaHandler().ListadoTematica();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListarManzana", Manzana);
            }
            return View(Manzana);
        }
        //public ActionResult ManzanaList(FiltrarManzanaViewModel Manzana)
        //{
        //    Manzana.listManzana = new ManzanaHandler().ListarManzana(Manzana);
        //    return View("Index", Manzana);
        //}

        // --Action usado para cargar la lista de Manzanas en Manzana via y Sectores
        [HttpPost]
        public ActionResult Sector(string id)
        {
            List<ManzanaViewModel> listaManzana = new ManzanaHandler().ListarManzanaCombo(id);
            return Json(listaManzana, "json");
        }

        [HttpGet]
        public PartialViewResult Registrar()
        {
            RegistroManzanaViewModel RegistroManzana = new RegistroManzanaViewModel();
            RegistroManzana.Distrito = "SAN ISIDRO";
            RegistroManzana.ListadoSectores = new ManzanaHandler().ListadoSector();
            RegistroManzana.ListadoTematica = new ManzanaHandler().ListadoTematica();
            RegistroManzana.ListadoZonificacionSuelo = new ManzanaHandler().ListadoZonificacionSuelo();
            RegistroManzana.ListadoDescripcionZonificacionUso = new ManzanaHandler().ListadoZonificacionSueloDescripcion();
            RegistroManzana.Estado = 1;

            return PartialView("_Registrar", RegistroManzana);
        }

        [HttpPost]
        public ActionResult CodigoSubSectorizacion(int codigo)
        {
            var data = new ManzanaHandler().ListadoCodigoSubSectorizacion(codigo);
            return Json(new { success = true, data = data });
        }

        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(RegistroManzanaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            BE.SIC_RETORNO EstadoProceso = new ManzanaHandler().ProcesarManzana(modelo);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = "Se generó la MANZANA " + EstadoProceso.CODIGO + " para el Sector " + (new ManzanaHandler().ListadoSector().Where(e => e.Value == modelo.CodigoSector)).FirstOrDefault().Text });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpGet]
        public PartialViewResult Editar(string sector, string manzana)
        {
            RegistroManzanaViewModel Manzana = new ManzanaHandler().BuscarManzana(manzana, sector);
            var data = new ManzanaHandler().ListadoSector();
            //List<SelectListItem> ResultSector = new List<SelectListItem>();
            foreach (var item in data)
            {
                bool estado = false;
                if (Manzana.CodigoSector == item.Value)
                {
                    estado = true;
                }
                item.Selected = estado;
            }
            var ResultTematica = Manzana.ListadoTematica;
            foreach (var item in ResultTematica)
            {
                bool estado = false;
                if (Manzana.CodigoTematica == item.Value)
                {
                    estado = true;
                }
                item.Selected = estado;
            }

            Manzana.ListadoSectores = data;
            Manzana.ListadoZonificacionSuelo = new ManzanaHandler().ListadoZonificacionSuelo();
            Manzana.ListadoTematica = new ManzanaHandler().ListadoTematica();
            Manzana.ListadoDescripcionZonificacionUso = new ManzanaHandler().ListadoZonificacionSueloDescripcion();
            Manzana.Estado = 2;
            return PartialView("_Registrar", Manzana);
        }
        [HttpPost]
        public ActionResult CargarDetalle(RegistroManzanaViewModel modelo)
        {
            RegistroManzanaViewModel Manzana = new ManzanaHandler().BuscarManzana(modelo.CodigoManzana, modelo.CodigoSector);

            return Json(new { success = true, data = Manzana });
        }

        //[HttpPost]
        //[ValidateAjaxAttribute]
        //public ActionResult Editar(RegistroManzanaViewModel modelo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        return Json(new { success = false, responseText = "No es un modelo válido" });
        //    }
        //    Nullable<bool> EstadoProceso = new ManzanaHandler().ProcesarManzana(modelo);
        //    if (EstadoProceso == true)
        //    {
        //        return Json(new { success = true, responseText = "Grabo correctamente" });
        //    }
        //    return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        //    //return RedirectToAction("ManzanaList");
        //}

        [HttpGet]
        public ActionResult Eliminar(string sector, string manzana)
        {
            RegistroManzanaViewModel Manzana = new ManzanaHandler().BuscarManzana(manzana, sector);
            Manzana.Estado = 3;
            return PartialView("_Eliminar", Manzana);
        }
        [HttpPost]
        public ActionResult Eliminar(RegistroManzanaViewModel modelo)
        {
            BE.SIC_RETORNO EstadoProceso = new ManzanaHandler().ProcesarManzana(modelo);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        //[HttpGet]
        //public PartialViewResult Imagen(string sector, string manzana) {

        //    RegistroManzanaViewModel query = new ManzanaHandler().BuscarManzana(manzana, sector);
        //    var data = new ImagenManzana() {
        //        NombreManzana = query.NombreManzana
        //    };
        //    return PartialView("_Imagen", data);
        //}
        [HttpPost]
        public ActionResult GrabarManzanaImagen(ImagenManzana model)
        {
            string correlativo;
            Nullable<bool> EstadoProceso = new ManzanaHandler().GrabarManzanaImagen(model, out correlativo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente", correl = correlativo });
            }
            return Json(new { success = false, responseText = correlativo, correl = correlativo });
        }

        [HttpPost]
        public ActionResult Imagen(string imagen)
        {
            string ImagenResult = new ManzanaHandler().VerImagenManzana(imagen.Replace(",", "\\"));
            if (ImagenResult != "")
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente", Imagen = ImagenResult });
            }
            return Json(new { success = false, responseText = "No se entontró imagen" });
        }
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarManzanaViewModel Manzana)
        {
            //try
            //{
                // --Definir variables de búsqueda
                var CodigoSector = Request.Form.GetValues("CodigoSector").FirstOrDefault();
                Manzana.CodigoSector = CodigoSector;

                // --Variables por defecto de datatables
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal;
                // --Obtener los resultados enviando información de la pagínacion
                var result = new ManzanaHandler().RecargarGrid(draw, start, length, pageSize, skip, model, Manzana, out recordsTotal);

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result });
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}

        }
    }
    
}