
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.ConsultaHistoricaUnidades;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.UnidadCatastral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    public class ConsultaHistoricaUnidadesController : Controller
    {
        [Authorize]
        [LogActionAttribute]
        [LogExceptionAttribute]

        // GET: ConsultaHistoricaUnidades
        public ActionResult Index()
        {
            ViewBag.ListVBEstadoConservacion = new UnidadCatastralHandler().ListarEstadoConservacion();
            ViewBag.ListVBMaterialEstructural = new UnidadCatastralHandler().ListadoMaterialEstructural();
            ViewBag.ListVBMes = new UnidadCatastralHandler().ListadoMes();
            ViewBag.ListVBOtrasInstalaciones = new UnidadCatastralHandler().ListadoOtrasInstalaciones();
            ViewBag.ListVBUnidadMedida = new UnidadCatastralHandler().ListadoUnidadMedida();
            //ViewBag.ListVBOtrasInstalaciones = new UnidadCatastralHandler().ListarOtrasInstalaciones();
            ViewBag.ListVBCodigoOtrasInstalaciones = new UnidadCatastralHandler().ListarCodigoOtrasInstalaciones();
            ViewBag.ListVBUsoPredio = new UnidadCatastralHandler().ListarUsoPredio();
            ViewBag.ListVBCodigoUsoPredio = new UnidadCatastralHandler().ListarCodigoUsoPredio();
            ViewBag.ListVBTipoSiNo = new UnidadCatastralHandler().ListadoTipoSiNo();
            ViewBag.ListVBTipoAnuncio = new UnidadCatastralHandler().ListadoTipoAnuncio();


            return View(new FiltrarHistoricoUnidadCatastralViewModel
            {
                FiltrarListTipoSolicitud = new UnidadCatastralHandler().ListadoTipoSolicitud(),
                FiltrarListTipoDocumento = new UnidadCatastralHandler().ListadoTipoDocumento(),
                ListEstadoContruccion = new UnidadCatastralHandler().ListadoEstadoConstruccion(),
                ListCodigoInscripcionCatastral = new UnidadCatastralHandler().ListarCodigoInscripcion(),
                ListInscripcionCatastral = new UnidadCatastralHandler().ListarInscripcionCatastral(),
                ListFuenteInscripcionCatastral = new UnidadCatastralHandler().ListadoFuenteInscripcionCatastral(),
                ListClasificacionPredio = new UnidadCatastralHandler().ListarClasificacionPredio(),
                ListDepartamentoPredio = new UnidadCatastralHandler().ListarTipoDepartamentoPredio(),
                ListUsoPredio = new UnidadCatastralHandler().ListarUsoPredio(),
                ListDenominacion = new List<SelectListItem>(),

            });

        }

        // GET: ConsultaHistoricaUnidades/Details/5
        public JsonResult BuscarSolicitudHistoricoEstatico(DataTableAjaxPostModel model, FiltrarHistoricoUnidadCatastralViewModel modelo)
        {

            int totalResultado;
            var resultado = new HistoricaUnidadCatastralHandler().BuscarHistoricoUnidades(model, modelo, out totalResultado);

            return Json(new { success = true, draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        public ActionResult RecuperarHistoricoUnidadCatastralEST(int CodUniCat, string NumVersion)
        {
            bool resul = false;
            FiltrarConsultaHistoricaUnidadesViewModel resultado = new HistoricaUnidadCatastralHandler().RecuperarHistoricoUnidadCatastralEST(CodUniCat,NumVersion, out resul);
           // List<LineasContructivasHistoricasViewModel> ListLineasConstructivas = new HistoricaUnidadCatastralHandler().RecuperarUnidadConstruccionHistoricas(CodUniCat, NumVersion);
            //List<OtrasInstalacionesUnidadesHistoricasViewModel> ListOtrasInstalaciones = new HistoricaUnidadCatastralHandler().RecuperaInstalacionesHistoricasUnidades(CodUniCat, NumVersion);
            //List<ActividadEconomicaViewModel> ListActividadEconomica = new UnidadCatastralHandler().RecuperarUnidadListaActividad(CodUniCat);
            //List<ObservacionViewModel> ListObservacionGeneral = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010001");
            //List<ObservacionViewModel> ListObservacionSunarp = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010002");
            //List<ObservacionViewModel> ListObservacionCarga = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010003");

            return Json(new
            {
                success = resul,
                resultado = resultado,
               // ListLineasConstructivas = ListLineasConstructivas,
             //   ListOtrasInstalaciones = ListOtrasInstalaciones,
            //    ListActividadEconomica = ListActividadEconomica,
            //    ListObservacionGeneral = ListObservacionGeneral,
            //    ListObservacionSunarp = ListObservacionSunarp,
            //    ListObservacionCarga = ListObservacionCarga
            });
        }
        public ActionResult CargarImagen(FiltrarHistoricoUnidadCatastralViewModel model)
        {
            return Json(new { success = true, responseText = "Imagen subida correctamente ", imagen = new HistoricaUnidadCatastralHandler().RecuperarImagenHistoricaLote(model) });
        }

        [HttpPost]
        public JsonResult CargarDireccionHistoricaUnidad(DataTableAjaxPostModel model, string CodigoUniCat, int flgindirec, string Numversion)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<NumeracionHistoricaPredioViewModel> resultado = new HistoricaUnidadCatastralHandler().CargarDireccionHistoricaUnidad(CodigoUniCat, flgindirec, Numversion);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

    }
}
