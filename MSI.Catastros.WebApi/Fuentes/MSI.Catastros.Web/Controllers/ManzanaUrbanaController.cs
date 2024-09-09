using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Funcionalidad.ManzanaUrbana;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using MSI.Catastros.Web.Funcionalidad.HabilitacionUrbana;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class ManzanaUrbanaController : Controller
    {
        // GET: HabilitacionUrbana
        public ActionResult Index(FiltrarManzanaUrbanaViewModel ManzanaUrbana)
        {
            ManzanaUrbana.TipoHabilitacionReg = new TipoHabilitacionHandler().ListarTipoHabilitacion(new FiltrarTipoHabilitacionViewModel());
            ManzanaUrbana.HabilitacionUrbanaReg = new HabilitacionUrbanaHandler().ListarHabilitacionUrbana(new FiltrarHabilitacionUrbanaViewModel());
            ManzanaUrbana.ListTipoManzanaUrbana = new ManzanaUrbanaHandler().ListarTipoManzanaUrbanaSelect();
            return View(ManzanaUrbana);

        }
        [HttpGet]
        public PartialViewResult Registrar()
        {
            List<TipoHabilitacionViewModel> lisTipoHabilitacion = new TipoHabilitacionHandler().ListarTipoHabilitacion(new FiltrarTipoHabilitacionViewModel());
            List<HabilitacionUrbanaViewModel> lisHabilitacionUrbana = new List<HabilitacionUrbanaViewModel>();
            List<SelectListItem> listTipoManzana = new ManzanaUrbanaHandler().ListarTipoManzanaUrbanaSelect();
            
            return PartialView("_Registrar", new RegistroManzanaUrbanaViewModel() { 
                Estado = 1, TipoHabilitacion = lisTipoHabilitacion, HabilitacionUrbana = lisHabilitacionUrbana,
                ListTipoManzanaUrbana = listTipoManzana
            });
        }
        [HttpGet]
        public PartialViewResult Editar(string id)
        {
            RegistroManzanaUrbanaViewModel ManzanaUrbana = new ManzanaUrbanaHandler().BuscarManzanaUrbana(id);
            ManzanaUrbana.Estado = 2;
            return PartialView("_Registrar", ManzanaUrbana);

        }

        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(RegistroManzanaUrbanaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            Nullable<bool> EstadoProceso = new ManzanaUrbanaHandler().ProcesarManzanaUrbana(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        // --Action usado para cargar la lista de Manzanas en Manzana via y Sectores
        [HttpPost]
        public ActionResult HabilitacionUrbana(string id)
        {
            List<HabilitacionUrbanaViewModel> listaHabilitacionUrbana = new HabilitacionUrbanaHandler().ListarHabilitacionUrbanaCombo(id);
            return Json(listaHabilitacionUrbana, "json");
        }
        [HttpPost]
        public ActionResult ListarManzanaUrbana(FiltrarManzanaUrbanaViewModel ManzanaUrbana)
        {
            List<SelectListItem> resultado = new ManzanaUrbanaHandler().ListarManzanaUrbanaSelect(ManzanaUrbana);
            return Json(resultado, "json");
        }
        
        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            RegistroManzanaUrbanaViewModel ManzanaUrbana = new ManzanaUrbanaHandler().BuscarManzanaUrbana(id);
            ManzanaUrbana.Estado = 3;
            return PartialView("_Eliminar", ManzanaUrbana);
        }
        [HttpPost]
        public ActionResult Eliminar(RegistroManzanaUrbanaViewModel modelo)
        {
            modelo.Estado = 3;
            Nullable<bool> EstadoProceso = new ManzanaUrbanaHandler().ProcesarManzanaUrbana(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarManzanaUrbanaViewModel ManzanaUrbana)
        {
            
                // --Definir variables de búsqueda
                var CodigoTipoHabilitacionReg = Request.Form.GetValues("CodigoTipoHabilitacionReg").FirstOrDefault();
                ManzanaUrbana.CodigoTipoHabilitacionReg = CodigoTipoHabilitacionReg;
                var CodigoHabilitacionUrbanaReg = Request.Form.GetValues("CodigoHabilitacionUrbanaReg").FirstOrDefault();
                ManzanaUrbana.CodigoHabilitacionUrbanaReg = CodigoHabilitacionUrbanaReg;
                var NombreManzanaUrbanaReg = Request.Form.GetValues("NombreManzanaUrbanaReg").FirstOrDefault();
                ManzanaUrbana.NombreManzanaUrbanaReg = NombreManzanaUrbanaReg;

                var CodigoTipoManzanaUrbanaReg = Request.Form.GetValues("CodigoTipoManzanaUrbanaReg").FirstOrDefault();
                ManzanaUrbana.CodigoTipoManzanaUrbanaReg = CodigoTipoManzanaUrbanaReg;

                
                // --Variables por defecto de datatables
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal;
                // --Obtener los resultados enviando información de la pagínacion
                var result = new ManzanaUrbanaHandler().RecargarGrid(draw, start, length, pageSize, skip, model, ManzanaUrbana, out recordsTotal);

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result });
            

        }
    }
}