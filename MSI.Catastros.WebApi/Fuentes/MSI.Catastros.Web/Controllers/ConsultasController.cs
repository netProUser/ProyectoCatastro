using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.DetalleVias;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using MSI.Catastros.Web.Funcionalidad.UnidadCatastral;
using MSI.Catastros.Web.Funcionalidad.HabilitacionUrbana;


namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class ConsultasController : Controller
    {
        // GET: Consultas
        public ActionResult Index(FiltrarConsultasViewModel ConsultaViewModel)
        {
            ConsultaViewModel.ListCodigoVia = new DetalleViasHandler().ListarVias();
            ConsultaViewModel.ListTipoHabilitacion = new TipoHabilitacionHandler().ListarTipoHabilitacionSelect();
            ConsultaViewModel.ListHabilitacion = new HabilitacionUrbanaHandler().ListarHabilitacionUrbanaSelect("");
            ConsultaViewModel.ListTipoDocumento = new List<SelectListItem>();
            ConsultaViewModel.ListNombreTitulares = new List<SelectListItem>();
            ConsultaViewModel.ListUsoPredio = new UnidadCatastralHandler().ListarUsoPredio();
            ConsultaViewModel.ListClasificacion = new UnidadCatastralHandler().ListarClasificacionPredio();
            ConsultaViewModel.ListEstadoConstruccion = new UnidadCatastralHandler().ListadoEstadoConstruccion();
            
            return View(ConsultaViewModel);
        }
        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarConsultasViewModel FiltroConsultas)
        {
            int totalResultado = 0;
            var resultado = new List<FiltrarConsultasViewModel>();
            if (FiltroConsultas.TablaNull == false) {
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            }
            resultado = new ConsultasHandler().ListarGrid(model, out totalResultado, FiltroConsultas);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
        [HttpPost]
        public ActionResult Buscar(FiltrarConsultasViewModel FiltroConsultas)
        {
            List<FiltrarConsultasViewModel> resultado = new ConsultasHandler().BuscarSimple(FiltroConsultas);
            return Json(new { success = true, data = resultado });
        }
        [HttpGet]
        public PartialViewResult AgregarUnidades()
        {
            return PartialView("_RegistrarUnidad", new FiltrarConsultasViewModel());
        }
    }
}