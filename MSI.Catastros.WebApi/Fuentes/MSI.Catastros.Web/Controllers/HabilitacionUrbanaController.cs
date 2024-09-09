using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Funcionalidad.HabilitacionUrbana;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class HabilitacionUrbanaController : Controller
    {
        // GET: HabilitacionUrbana
        public ActionResult Index(FiltrarHabilitacionUrbanaViewModel HabilitacionUrbana)
        {
            HabilitacionUrbana.TipoHabilitacion = new TipoHabilitacionHandler().ListarTipoHabilitacion(new FiltrarTipoHabilitacionViewModel());
            return View(HabilitacionUrbana);

        }
        [HttpGet]
        public PartialViewResult Registrar()
        {
            List<TipoHabilitacionViewModel> lisTipoHabilitacion = new TipoHabilitacionHandler().ListarTipoHabilitacion(new FiltrarTipoHabilitacionViewModel());
            List<SelectListItem> lisDiferenciador = new HabilitacionUrbanaHandler().ListarDiferenciadorSelect();
            return PartialView("_Registrar", new RegistroHabilitacionUrbanaViewModel() { Estado = 1, TipoHabilitacion = lisTipoHabilitacion, ListDiferenciador = lisDiferenciador});
        }
        [HttpPost]
        public ActionResult ListarTipoHabilitacion()
        {
            List<SelectListItem> resultado = new TipoHabilitacionHandler().ListarTipoHabilitacionSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult HabilitacionUrbana(string id)
        {
            List<SelectListItem> resultado = new HabilitacionUrbanaHandler().ListarHabilitacionUrbanaSelect(id);
            return Json(resultado, "json");
        }
        [HttpGet]
        public PartialViewResult Editar(string id)
        {
            RegistroHabilitacionUrbanaViewModel HabilitacionUrbana = new HabilitacionUrbanaHandler().BuscarHabilitacionUrbana(id);
            HabilitacionUrbana.Estado = 2;
            return PartialView("_Registrar", HabilitacionUrbana);

        }
        [HttpPost]
        public ActionResult BuscarObservacion(HabilitacionUrbanaViewModel model)
        {
            bool resul = false;
            List<ObservacionViewModel> resultado = new HabilitacionUrbanaHandler().BuscarObservacion(model);
            return Json(new { success = resul, Observacion = resultado });
        }
        [HttpPost]
        public ActionResult GrabarObservacion(List<ObservacionViewModel> model, string codigo)
        {
            Nullable<bool> EstadoProceso = new HabilitacionUrbanaHandler().GrabarObservacion(model, codigo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(RegistroHabilitacionUrbanaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            string codigo = "";
            Nullable<bool> EstadoProceso = new HabilitacionUrbanaHandler().ProcesarHabilitacion(modelo, out codigo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente", codigo = codigo });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpGet]
        public FileResult Descargar(string id)
        {
            byte[] pdfFile;
            string repo = "DOCUMENTOS"; string tiporepo = "HABILITACION";
            string carpeta = "\\" + repo + "\\" + tiporepo;
            pdfFile = System.IO.File.ReadAllBytes(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta + "\\" + id + ".pdf");
            //pdfFile = GetByteArray();
            var fileName = System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta + "\\" + id + ".pdf";
            var fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            fileStream.Write(pdfFile, 0, pdfFile.Length);
            fileStream.Close();
            //}
            return File( pdfFile, "application/pdf" );
        }

        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            RegistroHabilitacionUrbanaViewModel HabilitacionUrbana = new HabilitacionUrbanaHandler().BuscarHabilitacionUrbana(id);
            HabilitacionUrbana.Estado = 3;
            return PartialView("_Eliminar", HabilitacionUrbana);
        }
        [HttpPost]
        public ActionResult Eliminar(RegistroHabilitacionUrbanaViewModel modelo)
        {
            string codigo = "";
            Nullable<bool> EstadoProceso = new HabilitacionUrbanaHandler().ProcesarHabilitacion(modelo, out codigo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarHabilitacionUrbanaViewModel HabilitacionUrbana)
        {
            
                // --Definir variables de búsqueda
                var NombreHabilitacionUrbana = Request.Form.GetValues("NombreHabilitacionUrbana").FirstOrDefault();
                HabilitacionUrbana.NombreHabilitacionUrbana = NombreHabilitacionUrbana;
                var CodigoTipoHabilitacion = Request.Form.GetValues("CodigoTipoHabilitacion").FirstOrDefault();
                HabilitacionUrbana.CodigoTipoHabilitacion = CodigoTipoHabilitacion;

                // --Variables por defecto de datatables
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal;
                // --Obtener los resultados enviando información de la pagínacion
                var result = new HabilitacionUrbanaHandler().RecargarGrid(draw, start, length, pageSize, skip, model, HabilitacionUrbana, out recordsTotal);

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result });
            

        }

        [HttpPost]
        public ActionResult GrabarHabilitacionImagen(ImagenHabilitacion model)
        {
            string correlativo;
            Nullable<bool> EstadoProceso = new HabilitacionUrbanaHandler().GrabarHabilitacionImagen(model, out correlativo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente", correl = correlativo });
            }
            return Json(new { success = false, responseText = correlativo, correl = correlativo });
        }
        [HttpPost]
        public ActionResult Imagen(string imagen)
        {
            string ImagenResult = new HabilitacionUrbanaHandler().VerImagenHabilitacion(imagen.Replace(",", "\\"));
            if (ImagenResult != "")
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente", Imagen = ImagenResult });
            }
            return Json(new { success = false, responseText = "No se entontró imagen" });
        }
    }
}