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
    public class HistoricoUnidadController : Controller
    {
        // GET: HistoricoUnidad
        public ActionResult Index()
        {
            ViewBag.ListVBTipoSiNo = new UnidadCatastralHandler().ListadoTipoSiNo();
        
            
        

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


        public JsonResult BuscarSolicitudHistoricoEstatico(DataTableAjaxPostModel model, FiltrarHistoricoUnidadCatastralViewModel modelo)
        {

            int totalResultado;
            var resultado = new HistoricaUnidadCatastralHandler().BuscarHistoricoUnidades(model, modelo, out totalResultado);

            return Json(new { success = true, draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        public ActionResult RecuperarHistoricoUnidadCatastralEST(int CodUniCat, string NumVersion)
        {
            bool resul = false;
            FiltrarConsultaHistoricaUnidadesViewModel resultado = new HistoricaUnidadCatastralHandler().RecuperarHistoricoUnidadCatastralEST(CodUniCat, NumVersion, out resul);
            //List<OtrasInstalacionesUnidadesHistoricasViewModel> ListOtrasInstalaciones = new HistoricaUnidadCatastralHandler().RecuperaInstalacionesHistoricasUnidades(CodUniCat, NumVersion);
            //List<ActividadEconomicaViewModel> ListActividadEconomica = new UnidadCatastralHandler().RecuperarUnidadListaActividad(CodUniCat);
            //List<ObservacionViewModel> ListObservacionGeneral = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010001");
            //List<ObservacionViewModel> ListObservacionSunarp = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010002");
            //List<ObservacionViewModel> ListObservacionCarga = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010003");

            return Json(new
            {
                success = resul,
                resultado = resultado,
            });
        }
        public ActionResult CargarImagen(FiltrarHistoricoUnidadCatastralViewModel model)
        {
            return Json(new { success = true, responseText = "Imagen subida correctamente ", imagen = new HistoricaUnidadCatastralHandler().RecuperarImagenHistoricaLote(model) });
        }
        public JsonResult CargarDireccionHistoricaUnidad(DataTableAjaxPostModel model, string CodigoUniCat, int flgindirec, string Numversion)
        {
            // --Obtener los resultados enviando información de la pagínacion
            List<NumeracionHistoricaPredioViewModel> resultado = new HistoricaUnidadCatastralHandler().CargarDireccionHistoricaUnidad(CodigoUniCat, flgindirec, Numversion);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
        public JsonResult RecuperarUnidadConstruccionHistoricas(DataTableAjaxPostModel model, string CodigoUniCat,  string Numversion)
        {
            // --Obtener los resultados enviando información de la pagínacion

            List<LineasContructivasHistoricasViewModel> ListLineasConstructivas = new HistoricaUnidadCatastralHandler().RecuperarUnidadConstruccionHistoricas(CodigoUniCat, Numversion);

            int totalResultado = ListLineasConstructivas.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = ListLineasConstructivas });
        }
        public JsonResult RecuperaInstalacionesHistoricasUnidades(DataTableAjaxPostModel model, string CodigoUniCat, string Numversion)
        {
            // --Obtener los resultados enviando información de la pagínacion

            List<OtrasInstalacionesUnidadesHistoricasViewModel> ListOtrasConstructivas = new HistoricaUnidadCatastralHandler().RecuperaInstalacionesHistoricasUnidades(CodigoUniCat, Numversion);

            int totalResultado = ListOtrasConstructivas.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = ListOtrasConstructivas });
        }
        public JsonResult BuscarHistoricoLoteLinderos(DataTableAjaxPostModel model, string CodigoUniCat, string Numversion)
        {
            // --Obtener los resultados enviando información de la pagínacion

            List<OtrasLinderosUnidadesHistoricasViewModel> ListLinderos= new HistoricaUnidadCatastralHandler().BuscarHistoricoLoteLinderos(CodigoUniCat, Numversion);

            int totalResultado = ListLinderos.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = ListLinderos });
        }
        public JsonResult BuscarHistoricoObservacion(DataTableAjaxPostModel model, string CodigoUniCat, string Numversion, string tipObs)
        {
            List<HistoricoObservacionViewModel> ListObservaciones = new HistoricaUnidadCatastralHandler().BuscarHistoricoObservacion(CodigoUniCat, Numversion, tipObs);

            int totalResultado = ListObservaciones.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = ListObservaciones });
        }
        public JsonResult CargarUnidadRRPPHistorica(DataTableAjaxPostModel model, string CodigoUniCat, string Numversion)
        {

            //--Obtener los resultados enviando información de la pagínacion
            List<LoteHistoricoDocumentosRRPPViewModel> resultado = new HistoricaUnidadCatastralHandler().CargarUnidadRRPPHistorica(CodigoUniCat, Numversion);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
        public JsonResult CargarUnidadExpedienteDocHistorica(DataTableAjaxPostModel model, string CodigoUniCat, string Numversion)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadHistoricaExpedienteDocViewModel> resultado = new HistoricaUnidadCatastralHandler().CargarUnidadExpedienteDocHistorica(CodigoUniCat, Numversion);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        public JsonResult CargarUnidadLicenciasFuncHistorica(DataTableAjaxPostModel model, string CodigoUniCat, string Numversion)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadHistoricaLicenciaFuncViewModel> resultado = new HistoricaUnidadCatastralHandler().CargarUnidadLicenciasFuncHistorica(CodigoUniCat, Numversion);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        public JsonResult CargarUnidadObrasPrivadasHistoricas(DataTableAjaxPostModel model, string CodigoUniCat, string Numversion)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadHistoricaObrasPrivadasViewModel> resultado = new HistoricaUnidadCatastralHandler().CargarUnidadObrasPrivadasHistoricas(CodigoUniCat, Numversion);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        
         public JsonResult CargarUnidadTitularHistoricas(DataTableAjaxPostModel model, string CodigoUniCat, string Numversion)
        {
            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadHistoricaTitularViewModel> resultado = new HistoricaUnidadCatastralHandler().CargarUnidadTitularHistoricas(CodigoUniCat, Numversion);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        public JsonResult CargarUnidadActividadEconomicaHistoricas(DataTableAjaxPostModel model, string CodigoUniCat, string Numversion)
        {
            // --Obtener los resultados enviando información de la pagínacion
            List<ActividadHistoricaEconomicaViewModel> resultadoActividadEconomica = new HistoricaUnidadCatastralHandler().CargarUnidadActividadEconomicaHistoricas(CodigoUniCat, Numversion);
            int totalResultado = resultadoActividadEconomica.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultadoActividadEconomica });

        }

       

    }
}
