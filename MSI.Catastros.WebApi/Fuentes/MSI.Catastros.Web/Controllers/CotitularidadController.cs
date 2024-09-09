using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.Cotitularidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE = MSI.Catastros.BusinessEntities;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class CotitularidadController : Controller
    {
        // GET: Cotitularidad
        //
        public ActionResult Index()
        {
            ViewBag.ListVBEstadoConservacion = new CotitularidadHandler().ListarEstadoConservacion();
            ViewBag.ListVBMaterialEstructural = new CotitularidadHandler().ListadoMaterialEstructural();
            ViewBag.ListVBMes = new CotitularidadHandler().ListadoMes();
            ViewBag.ListVBOtrasInstalaciones = new CotitularidadHandler().ListadoOtrasInstalaciones();
            ViewBag.ListVBUnidadMedida = new CotitularidadHandler().ListadoUnidadMedida();
            //ViewBag.ListVBOtrasInstalaciones = new CotitularidadHandler().ListarOtrasInstalaciones();
            ViewBag.ListVBCodigoOtrasInstalaciones = new CotitularidadHandler().ListarCodigoOtrasInstalaciones();
            ViewBag.ListVBUsoPredio = new CotitularidadHandler().ListarUsoPredio();
            ViewBag.ListVBCodigoUsoPredio = new CotitularidadHandler().ListarCodigoUsoPredio();
            ViewBag.ListVBTipoSiNo = new CotitularidadHandler().ListadoTipoSiNo();
            ViewBag.ListVBTipoAnuncio = new CotitularidadHandler().ListadoTipoAnuncio();
            ViewBag.ListTipoLlenado = new CotitularidadHandler().ListadoTipoLlenado();
            VariablesWeb.Estatico = "";
            return View(new FiltrarUnidadCatastralViewModel
            {
                FiltrarListTipoSolicitud = new CotitularidadHandler().ListadoTipoSolicitud(),
                FiltrarListTipoDocumento = new CotitularidadHandler().ListadoTipoDocumento(),
                ListEstadoContruccion = new CotitularidadHandler().ListadoEstadoConstruccion(),
                ListCodigoInscripcionCatastral = new CotitularidadHandler().ListarCodigoInscripcion(),
                ListInscripcionCatastral = new CotitularidadHandler().ListarInscripcionCatastral(),
                ListFuenteInscripcionCatastral = new CotitularidadHandler().ListadoFuenteInscripcionCatastral(),
                ListClasificacionPredio = new CotitularidadHandler().ListarClasificacionPredio(),
                ListDepartamentoPredio = new CotitularidadHandler().ListarTipoDepartamentoPredio(),
                ListUsoPredio = new CotitularidadHandler().ListarUsoPredio(),
                ListDenominacion = new List<SelectListItem>(),

            });
        }
        public ActionResult Estatico()
        {
            ViewBag.ListVBEstadoConservacion = new CotitularidadHandler().ListarEstadoConservacion();
            ViewBag.ListVBMaterialEstructural = new CotitularidadHandler().ListadoMaterialEstructural();
            ViewBag.ListVBMes = new CotitularidadHandler().ListadoMes();
            ViewBag.ListVBOtrasInstalaciones = new CotitularidadHandler().ListadoOtrasInstalaciones();
            ViewBag.ListVBUnidadMedida = new CotitularidadHandler().ListadoUnidadMedida();
            //ViewBag.ListVBOtrasInstalaciones = new CotitularidadHandler().ListarOtrasInstalaciones();
            ViewBag.ListVBCodigoOtrasInstalaciones = new CotitularidadHandler().ListarCodigoOtrasInstalaciones();
            ViewBag.ListVBUsoPredio = new CotitularidadHandler().ListarUsoPredio();
            ViewBag.ListVBCodigoUsoPredio = new CotitularidadHandler().ListarCodigoUsoPredio();
            ViewBag.ListVBTipoSiNo = new CotitularidadHandler().ListadoTipoSiNo();
            ViewBag.ListTipoLlenado = new CotitularidadHandler().ListadoTipoLlenado();
            ViewBag.ListVBTipoAnuncio = new CotitularidadHandler().ListadoTipoAnuncio();
            VariablesWeb.Estatico = "true";
            return View("Index", new FiltrarUnidadCatastralViewModel
            {
                FiltrarListTipoSolicitud = new CotitularidadHandler().ListadoTipoSolicitud(),
                FiltrarListTipoDocumento = new CotitularidadHandler().ListadoTipoDocumento(),
                ListEstadoContruccion = new CotitularidadHandler().ListadoEstadoConstruccion(),
                ListCodigoInscripcionCatastral = new CotitularidadHandler().ListarCodigoInscripcion(),
                ListInscripcionCatastral = new CotitularidadHandler().ListarInscripcionCatastral(),
                ListFuenteInscripcionCatastral = new CotitularidadHandler().ListadoFuenteInscripcionCatastral(),
                ListClasificacionPredio = new CotitularidadHandler().ListarClasificacionPredio(),
                ListDepartamentoPredio = new CotitularidadHandler().ListarTipoDepartamentoPredio(),
                ListUsoPredio = new CotitularidadHandler().ListarUsoPredio(),
                ListDenominacion = new List<SelectListItem>(),
                Estatico = true,
            });
        }

        public ActionResult Consultas()
        {
            ViewBag.ListVBEstadoConservacion = new CotitularidadHandler().ListarEstadoConservacion();
            ViewBag.ListVBMaterialEstructural = new CotitularidadHandler().ListadoMaterialEstructural();
            ViewBag.ListVBMes = new CotitularidadHandler().ListadoMes();
            ViewBag.ListVBOtrasInstalaciones = new CotitularidadHandler().ListadoOtrasInstalaciones();
            ViewBag.ListVBUnidadMedida = new CotitularidadHandler().ListadoUnidadMedida();
            //ViewBag.ListVBOtrasInstalaciones = new CotitularidadHandler().ListarOtrasInstalaciones();
            ViewBag.ListVBCodigoOtrasInstalaciones = new CotitularidadHandler().ListarCodigoOtrasInstalaciones();
            ViewBag.ListVBUsoPredio = new CotitularidadHandler().ListarUsoPredio();
            ViewBag.ListVBCodigoUsoPredio = new CotitularidadHandler().ListarCodigoUsoPredio();
            ViewBag.ListVBTipoSiNo = new CotitularidadHandler().ListadoTipoSiNo();
            ViewBag.ListVBTipoAnuncio = new CotitularidadHandler().ListadoTipoAnuncio();
            ViewBag.ListTipoLlenado = new CotitularidadHandler().ListadoTipoLlenado();
            VariablesWeb.Estatico = "true";
            return View("Index", new FiltrarUnidadCatastralViewModel
            {
                FiltrarListTipoSolicitud = new CotitularidadHandler().ListadoTipoSolicitud(),
                FiltrarListTipoDocumento = new CotitularidadHandler().ListadoTipoDocumento(),
                ListEstadoContruccion = new CotitularidadHandler().ListadoEstadoConstruccion(),
                ListCodigoInscripcionCatastral = new CotitularidadHandler().ListarCodigoInscripcion(),
                ListInscripcionCatastral = new CotitularidadHandler().ListarInscripcionCatastral(),
                ListFuenteInscripcionCatastral = new CotitularidadHandler().ListadoFuenteInscripcionCatastral(),
                ListClasificacionPredio = new CotitularidadHandler().ListarClasificacionPredio(),
                ListDepartamentoPredio = new CotitularidadHandler().ListarTipoDepartamentoPredio(),
                ListUsoPredio = new CotitularidadHandler().ListarUsoPredio(),
                ListDenominacion = new List<SelectListItem>(),
                Estatico = true,
                Consultas = true,
            });
        }

        [HttpPost]
        public ActionResult BuscarSolicitud(FiltrarUnidadCatastralViewModel modelo)
        {
            MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo.ProcedimientoNuevoViewModel ProcedimientoNuevo = new CotitularidadHandler().BuscarSolicitudes(modelo);
            if (ProcedimientoNuevo.NumeroSolicitud == null)
            {
                return Json(new { success = false, ProcedimientoNuevo = "" });
            }
            return Json(new { success = true, ProcedimientoNuevo = ProcedimientoNuevo });
        }

        public JsonResult BuscarSolicitudEstatico(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel modelo)
        {

            int totalResultado;
            var resultado = new CotitularidadHandler().BuscarUnidades(model, modelo, out totalResultado);

            return Json(new { success = true, draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        [HttpPost]
        public ActionResult BuscarUnidadSolicitud(FiltrarUnidadCatastralViewModel modelo)
        {
            UnidadSolicitudViewModel resultado = new CotitularidadHandler().BuscarUnidadSolicitud(modelo);
            if (resultado == null)
            {
                return Json(new { success = false });
            }
            return Json(new { success = true, Lotes = resultado });
        }
        [HttpPost]
        public ActionResult CargarOtrasInstalaciones(string anio)
        {
            List<SelectListItem> listaOtrasInstalaciones = new CotitularidadHandler().ListarOtrasInstalaciones(anio);
            return Json(listaOtrasInstalaciones, "json");
        }

        public ActionResult EliminarUnidadTemporal(SolicitudUnidadViewModel model)
        {
            Nullable<bool> EstadoProceso = new CotitularidadHandler().EliminarUnidadTemporal(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public JsonResult CargarSolUnidad(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltrarProcedimientoNuevo)
        {

            // --Definir variables de búsqueda
            FiltrarProcedimientoNuevo.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
            FiltrarProcedimientoNuevo.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
            FiltrarProcedimientoNuevo.FiltrarCodigoTipoDocumento = Request.Form.GetValues("FiltrarCodigoTipoDocumento").FirstOrDefault();
            FiltrarProcedimientoNuevo.FiltrarReferencia = Request.Form.GetValues("FiltrarReferencia").FirstOrDefault();

            int totalResultado;
            // --Obtener los resultados enviando información de la pagínacion
            var resultado = new CotitularidadHandler().RecargarTablaSolUnidad(model, FiltrarProcedimientoNuevo, out totalResultado);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }

        [HttpGet]
        public PartialViewResult AgregarUcNuevo()
        {
            return PartialView("_RegistrarUCNuevo", new RegistrarUnidadCatastralNuevoViewModel()
            {
                Estado = "1"
            });
        }
        [HttpPost]
        public ActionResult GrabarUnidadNuevo(List<SolicitudUnidadViewModel> model)
        {
            List<BE.SIC_RETORNO> ListEstadoProceso = new CotitularidadHandler().GrabarUnidadNuevo(model);
            //if (EstadoProceso.Ok == true)
            //{
            //    return Json(new { success = true, responseText = "Grabo correctamente" });
            //}
            return Json(new { ListEstadoProceso = ListEstadoProceso, success = false, responseText = "Error del servidor" });
        }

        [HttpPost]
        public ActionResult ValidarUnidadNuevo(SolicitudUnidadViewModel model)
        {
            BE.SIC_RETORNO ListEstadoProceso = new CotitularidadHandler().ValidarUnidadNuevo(model);
            //if (EstadoProceso.Ok == true)
            //{
            //    return Json(new { success = true, responseText = "Grabo correctamente" });
            //}
            return Json(new { ListEstadoProceso = ListEstadoProceso, success = false, responseText = "Error del servidor" });
        }

        [HttpPost]
        public ActionResult GrabarUnidadAcum(List<SolicitudUnidadViewModel> model)
        {
            List<BE.SIC_RETORNO> ListEstadoProceso = new CotitularidadHandler().GrabarUnidadAcum(model);
            //if (EstadoProceso.Ok == true)
            //{
            //    return Json(new { success = true, responseText = "Grabo correctamente" });
            //}
            return Json(new { ListEstadoProceso = ListEstadoProceso, success = false, responseText = "Error del servidor" });
        }

        [HttpPost]
        public ActionResult RegistrarUnidadCatastral(CotitularidadViewModel UnidadCatastral, List<LineasContructivasViewModel> ListaLineasContruc,
            List<OtrasInstalacionesViewModel> ListaOtrasInstalaciones, List<ActividadEconomicaViewModel> ListaActividadEconomica,
            List<ObservacionViewModel> ListaObservacionesGeneral, List<ObservacionViewModel> ListaObservacionesSunarp,
            List<ObservacionViewModel> ListaObservacionesCarga, List<QuintaLinderosViewModel> ListaLinderos)
        {

            //UnidadCatastral.Estado = 1;
            BE.SIC_RETORNO entSIC_RETORNO = new CotitularidadHandler().ProcesarUnidadCatastral(UnidadCatastral);

            if (ListaLineasContruc != null)
            {
                foreach (LineasContructivasViewModel LineasContruc in ListaLineasContruc)
                {
                    if (LineasContruc != null)
                    {
                        LineasContruc.Estado = LineasContruc.Eliminado == "0" ? (LineasContruc.CodigoCorrelativo == null ? 1 : 2) : 3;
                        BE.SIC_RETORNO entSIC_RETORNO_CONSTRUC = new CotitularidadHandler().ProcesarLineasConstructivas(LineasContruc);
                    }

                }
            }

            if (ListaOtrasInstalaciones != null)
            {
                foreach (OtrasInstalacionesViewModel OtrasInstalaciones in ListaOtrasInstalaciones)
                {
                    if (OtrasInstalaciones != null)
                    {
                        OtrasInstalaciones.Estado = OtrasInstalaciones.Eliminado == "0" ? (OtrasInstalaciones.CodigoCorrelativo == null ? 1 : 2) : 3;
                        BE.SIC_RETORNO entSIC_RETORNO_CONSTRUC = new CotitularidadHandler().ProcesarOtrasInstalaciones(OtrasInstalaciones);
                    }

                }
            }

            if (ListaActividadEconomica != null)
            {
                foreach (ActividadEconomicaViewModel ActividadEconomica in ListaActividadEconomica)
                {
                    if (ActividadEconomica != null)
                    {
                        ActividadEconomica.Estado = ActividadEconomica.Eliminado == "0" ? (ActividadEconomica.CodigoCorrelativo == null ? 1 : 2) : 3;
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new CotitularidadHandler().ProcesarActividadEconomica(ActividadEconomica);
                    }

                }
            }

            if (ListaObservacionesGeneral != null)
            {
                foreach (ObservacionViewModel Observacion in ListaObservacionesGeneral)
                {
                    if (Observacion != null)
                    {
                        Observacion.Estado = Observacion.Eliminado == "0" ? (Observacion.CodigoCorrelativo == null ? 1 : 2) : 3;
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new CotitularidadHandler().ProcesarObservaciones(Observacion);
                    }

                }
            }

            if (ListaObservacionesSunarp != null)
            {
                foreach (ObservacionViewModel Observacion in ListaObservacionesSunarp)
                {
                    if (Observacion != null)
                    {
                        Observacion.Estado = Observacion.Eliminado == "0" ? (Observacion.CodigoCorrelativo == null ? 1 : 2) : 3;
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new CotitularidadHandler().ProcesarObservaciones(Observacion);
                    }

                }
            }

            if (ListaObservacionesCarga != null)
            {
                foreach (ObservacionViewModel Observacion in ListaObservacionesCarga)
                {
                    if (Observacion != null)
                    {
                        Observacion.Estado = Observacion.Eliminado == "0" ? (Observacion.CodigoCorrelativo == null ? 1 : 2) : 3;
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new CotitularidadHandler().ProcesarObservaciones(Observacion);
                    }

                }
            }

            if (ListaLinderos != null)
            {
                Nullable<bool> EstadoProceso = new CotitularidadHandler().GrabarLoteLinderos(ListaLinderos);
            }


            return Json(new { success = entSIC_RETORNO.Ok });
        }

        [HttpPost]
        public JsonResult CargarDirecUnidad(DataTableAjaxPostModel model, string CodigoUniCat, int flgindirec, bool Estatico)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<NumeracionPredioViewModel> resultado = new CotitularidadHandler().CargarDirecUnidad(CodigoUniCat, flgindirec, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarDocumentosRRPPLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<LoteDocumentosRRPPViewModel> resultado = new CotitularidadHandler().CargarDocumentosRRPPLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }


        [HttpPost]
        public JsonResult CargarTitularRentas(DataTableAjaxPostModel model, string CodigoContribuyente, string CodigoTipoDocumentoIdentidad, string NumeroDocumento, string RazonSocial, string CodigoCatastrlalRentas)
        {

            int totalResultado = 0;
            List<TitularRentasViewModel> resultado = new List<TitularRentasViewModel>();

            if (CodigoContribuyente.Equals("") && CodigoTipoDocumentoIdentidad.Equals("") && NumeroDocumento.Equals("") && RazonSocial.Equals("") || CodigoCatastrlalRentas.Equals(""))
            {

                resultado = new List<TitularRentasViewModel>();
                totalResultado = 0;

            }
            else
            {
                resultado = new CotitularidadHandler().CargarTitularRentas(CodigoContribuyente, CodigoTipoDocumentoIdentidad, NumeroDocumento, RazonSocial, CodigoCatastrlalRentas);
                totalResultado = resultado.Count;
            }
            // --Obtener los resultados enviando información de la pagínacion

            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarLicenciaFuncLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<LicenciaFuncViewModel> resultado = new CotitularidadHandler().CargarLicenciaFuncLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarObrasPublicasLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<ObrasPublicasViewModel> resultado = new CotitularidadHandler().CargarObrasPublicasLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarExpedienteDocLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<LoteExpedienteDocViewModel> resultado = new CotitularidadHandler().CargarExpedienteDocLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarUnidadTitular(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadTitularViewModel> resultado = new CotitularidadHandler().CargarUnidadTitular(CodigoUniCat, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarInspecciones(DataTableAjaxPostModel model, string CodUniCat, string aniosol, string numsol, string tiposol)
        {
            // --Obtener los resultados enviando información de la pagínacion
            List<InspeccionesViewModel> resultado = new CotitularidadHandler().RecuperarInspecciones(CodUniCat, aniosol, numsol, tiposol);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarCartasInformes(DataTableAjaxPostModel model, string CodUniCat, string aniosol, string numsol, string tiposol, bool Estatico)
        {
            // --Obtener los resultados enviando información de la pagínacion
            if (Estatico == true)
            {
                List<CartasInformesViewModel> resultado = new CotitularidadHandler().RecuperarCartasInformes(CodUniCat, aniosol, numsol, tiposol, Estatico);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            }
            else
            {
                return Json(new { draw = model.draw, recordsTotal = 0, recordsFiltered = 0, data = new CotitularidadHandler() });
            }

        }

        [HttpPost]
        public JsonResult CargarUnidadRRPP(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadDocumentosRRPPViewModel> resultado = new CotitularidadHandler().CargarUnidadRRPP(CodigoUniCat, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }

        [HttpPost]
        public JsonResult CargarUnidadExpedienteDoc(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadExpedienteDocViewModel> resultado = new CotitularidadHandler().CargarUnidadExpedienteDoc(CodigoUniCat, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarUnidadLicenciasFunc(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadLicenciaFuncViewModel> resultado = new CotitularidadHandler().CargarUnidadLicenciaFunc(CodigoUniCat, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarUnidadObrasPrivadas(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadObrasPrivadasViewModel> resultado = new CotitularidadHandler().CargarUnidadObrasPrivadas(CodigoUniCat, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public ActionResult RegistrarTitularCatastral(UnidadTitularViewModel Titular)
        {
            Nullable<bool> EstadoProceso = false;
            Titular.Estado = 1;
            EstadoProceso = new CotitularidadHandler().ProcesarUnidadTitular(Titular);

            //Nullable<bool> EstadoProceso = new ProcedimientoInicialHandler().AgregarSolUnidadCatastral(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Agregado correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult RegistrarUnidadRRPP(List<UnidadDocumentosRRPPViewModel> ListaUnidadRRPP, int CodigoUniCat, string CodigoDistrito, string CodigoSector, string CodigoManzana, string CodigoLote)
        {
            Nullable<bool> EstadoProceso = false;
            foreach (UnidadDocumentosRRPPViewModel UnidadRRPP in ListaUnidadRRPP)
            {
                UnidadRRPP.CodigoUni = CodigoUniCat;
                UnidadRRPP.Estado = 1;
                UnidadRRPP.CodigoDistrito = CodigoDistrito;
                UnidadRRPP.CodigoSector = CodigoSector;
                UnidadRRPP.CodigoManzana = CodigoManzana;
                UnidadRRPP.CodigoLote = CodigoLote;
                EstadoProceso = new CotitularidadHandler().ProcesarUnidadRRPP(UnidadRRPP);
            }

            //Nullable<bool> EstadoProceso = new ProcedimientoInicialHandler().AgregarSolUnidadCatastral(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Agregado correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult RegistrarUnidadExpedienteDoc(List<UnidadExpedienteDocViewModel> ListaUnidadExpedienteDoc, int CodigoUniCat)
        {
            Nullable<bool> EstadoProceso = false;
            foreach (UnidadExpedienteDocViewModel UnidadExpedienteDoc in ListaUnidadExpedienteDoc)
            {
                UnidadExpedienteDoc.CodigoUni = CodigoUniCat;
                UnidadExpedienteDoc.Estado = 1;
                EstadoProceso = new CotitularidadHandler().ProcesarUnidadExpedienteDoc(UnidadExpedienteDoc);
            }

            //Nullable<bool> EstadoProceso = new ProcedimientoInicialHandler().AgregarSolUnidadCatastral(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Agregado correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult RegistrarUnidadLicenciaFunc(List<UnidadLicenciaFuncViewModel> ListaUnidadLicenciaFunc, int CodigoUniCat)
        {
            Nullable<bool> EstadoProceso = false;
            foreach (UnidadLicenciaFuncViewModel LicenciaFunc in ListaUnidadLicenciaFunc)
            {
                LicenciaFunc.CodigoUni = CodigoUniCat;
                LicenciaFunc.Estado = 1;
                EstadoProceso = new CotitularidadHandler().ProcesarUnidadLicenciaFunc(LicenciaFunc);
            }

            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Agregado correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult RegistrarUnidadObrasPrivadas(List<UnidadObrasPrivadasViewModel> ListaUnidadObrasPrivadas, int CodigoUniCat)
        {
            Nullable<bool> EstadoProceso = false;
            foreach (UnidadObrasPrivadasViewModel ObrasPrivadas in ListaUnidadObrasPrivadas)
            {
                ObrasPrivadas.CodigoUni = CodigoUniCat;
                ObrasPrivadas.Estado = 1;
                EstadoProceso = new CotitularidadHandler().ProcesarUnidadObrasPrivadas(ObrasPrivadas);
            }

            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Agregado correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        public ActionResult RegistrarNumeroPredio(NumeracionPredioViewModel NumeracionPredio)
        {
            if (NumeracionPredio.CodigoCorrDirecUnidad == null || NumeracionPredio.CodigoCorrDirecUnidad.Equals(""))
            {
                NumeracionPredio.Estado = 1;
            }
            else
            {
                NumeracionPredio.Estado = 2;
            }

            BE.SIC_RETORNO entSIC_RETORNO = new CotitularidadHandler().ProcesarNumeracionPredio(NumeracionPredio);
            return Json(new { success = entSIC_RETORNO.Ok });
        }

        [HttpPost]
        public ActionResult EliminarMunicipalAsignado(NumeracionPredioViewModel model)
        {
            Nullable<bool> EstadoProceso = new CotitularidadHandler().EliminarMunicipalDirec(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult EliminarTitular(UnidadTitularViewModel model)
        {
            Nullable<bool> EstadoProceso = new CotitularidadHandler().EliminarTitular(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }


        [HttpPost]
        public ActionResult EliminarDocRRPP(UnidadDocumentosRRPPViewModel model)
        {
            Nullable<bool> EstadoProceso = new CotitularidadHandler().EliminarDocRRPP(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }


        [HttpPost]

        public ActionResult RecuperarUnidadCatastral(int CodUniCat, string aniosol, string numsol, string tiposol, string docsol, string accion)
        {
            BE.SIC_RETORNO SIC_RETORNO_VAL = new CotitularidadHandler().ValidarYaTemporal(CodUniCat, aniosol, numsol, tiposol, docsol);

            if (SIC_RETORNO_VAL.NoMENSAJE == 20008)
            {
                bool resul = false;
                CotitularidadViewModel resultado = new CotitularidadHandler().RecuperarUnidadCatastral(CodUniCat, out resul);
                List<LineasContructivasViewModel> ListLineasConstructivas = new CotitularidadHandler().RecuperarUnidadListaConstruccion(CodUniCat, false);
                List<OtrasInstalacionesViewModel> ListOtrasInstalaciones = new CotitularidadHandler().RecuperarUnidadListaInstalaciones(CodUniCat, false);
                List<ActividadEconomicaViewModel> ListActividadEconomica = new CotitularidadHandler().RecuperarUnidadListaActividad(CodUniCat, false);
                List<ObservacionViewModel> ListObservacionGeneral = new CotitularidadHandler().RecuperarObservacion(CodUniCat, "010001", false);
                List<ObservacionViewModel> ListObservacionSunarp = new CotitularidadHandler().RecuperarObservacion(CodUniCat, "010002", false);
                List<ObservacionViewModel> ListObservacionCarga = new CotitularidadHandler().RecuperarObservacion(CodUniCat, "010003", false);
                return Json(new
                {
                    success = resul,
                    resultado = resultado,
                    ListLineasConstructivas = ListLineasConstructivas,
                    ListOtrasInstalaciones = ListOtrasInstalaciones,
                    ListActividadEconomica = ListActividadEconomica,
                    ListObservacionGeneral = ListObservacionGeneral,
                    ListObservacionSunarp = ListObservacionSunarp,
                    ListObservacionCarga = ListObservacionCarga
                });
            }
            {

                if (accion.Equals("Eliminar"))
                {
                    BE.SIC_RETORNO SIC_RETORNO_ELIM = new CotitularidadHandler().EliminarTemporal(CodUniCat);
                    BE.SIC_RETORNO entSIC_RETORNO_ACT = new CotitularidadHandler().ActualizarFlgTemporalNull(CodUniCat);
                }

                BE.SIC_RETORNO SIC_RETORNO = new CotitularidadHandler().ValidarTemporal(CodUniCat, aniosol, numsol, tiposol, docsol);

                if (SIC_RETORNO.NoMENSAJE == 20003)
                {
                    bool resul = false;
                    return Json(new
                    {
                        success = resul,
                        Mensaje = "20003",
                        usuario = VariablesWeb.IdUsuarioIntento,
                        OtraSolicitud = SIC_RETORNO.MENSAJE,
                    });

                }
                else
                {
                    BE.SIC_RETORNO entSIC_RETORNO_UC = new CotitularidadHandler().ProcesarMigracionEstaticoTemporal(CodUniCat);
                    BE.SIC_RETORNO entSIC_RETORNO_ACT = new CotitularidadHandler().ActualizarFlgTemporal(CodUniCat, aniosol, numsol, tiposol, docsol, "T");

                    bool resul = false;
                    CotitularidadViewModel resultado = new CotitularidadHandler().RecuperarUnidadCatastral(CodUniCat, out resul);
                    List<LineasContructivasViewModel> ListLineasConstructivas = new CotitularidadHandler().RecuperarUnidadListaConstruccion(CodUniCat, false);
                    List<OtrasInstalacionesViewModel> ListOtrasInstalaciones = new CotitularidadHandler().RecuperarUnidadListaInstalaciones(CodUniCat, false);
                    List<ActividadEconomicaViewModel> ListActividadEconomica = new CotitularidadHandler().RecuperarUnidadListaActividad(CodUniCat, false);
                    List<ObservacionViewModel> ListObservacionGeneral = new CotitularidadHandler().RecuperarObservacion(CodUniCat, "010001", false);
                    List<ObservacionViewModel> ListObservacionSunarp = new CotitularidadHandler().RecuperarObservacion(CodUniCat, "010002", false);
                    List<ObservacionViewModel> ListObservacionCarga = new CotitularidadHandler().RecuperarObservacion(CodUniCat, "010003", false);

                    return Json(new
                    {
                        success = resul,
                        resultado = resultado,
                        ListLineasConstructivas = ListLineasConstructivas,
                        usuario = VariablesWeb.IdUsuarioIntento,
                        ListOtrasInstalaciones = ListOtrasInstalaciones,
                        ListActividadEconomica = ListActividadEconomica,
                        ListObservacionGeneral = ListObservacionGeneral,
                        ListObservacionSunarp = ListObservacionSunarp,
                        ListObservacionCarga = ListObservacionCarga
                    });
                }

            }
        }

        public ActionResult RecuperarUnidadCatastralEST(int CodUniCat, string aniosol, string numsol, string tiposol, string docsol, string accion, bool Estatico)
        {
            bool resul = false;
            CotitularidadViewModel resultado = new CotitularidadHandler().RecuperarUnidadCatastralEST(CodUniCat, Estatico, out resul);
            List<LineasContructivasViewModel> ListLineasConstructivas = new CotitularidadHandler().RecuperarUnidadListaConstruccion(CodUniCat, true);
            List<OtrasInstalacionesViewModel> ListOtrasInstalaciones = new CotitularidadHandler().RecuperarUnidadListaInstalaciones(CodUniCat, true);
            List<ActividadEconomicaViewModel> ListActividadEconomica = new CotitularidadHandler().RecuperarUnidadListaActividad(CodUniCat, true);
            List<ObservacionViewModel> ListObservacionGeneral = new CotitularidadHandler().RecuperarObservacion(CodUniCat, "010001", true);
            List<ObservacionViewModel> ListObservacionSunarp = new CotitularidadHandler().RecuperarObservacion(CodUniCat, "010002", true);
            List<ObservacionViewModel> ListObservacionCarga = new CotitularidadHandler().RecuperarObservacion(CodUniCat, "010003", true);

            return Json(new
            {
                success = resul,
                resultado = resultado,
                ListLineasConstructivas = ListLineasConstructivas,
                ListOtrasInstalaciones = ListOtrasInstalaciones,
                ListActividadEconomica = ListActividadEconomica,
                ListObservacionGeneral = ListObservacionGeneral,
                ListObservacionSunarp = ListObservacionSunarp,
                ListObservacionCarga = ListObservacionCarga
            });
        }


        [HttpPost]
        public ActionResult ObtenerDescripcionInstalacion(string Codigo)
        {
            string Descripcion = "";
            if (Codigo.Equals(""))
            {
                return Json(new { success = false, Descripcion = Descripcion });
            }
            else
            {
                Descripcion = new CotitularidadHandler().ObtenerDescripcionInstalacion(Codigo);
                return Json(new { success = true, Descripcion = Descripcion });
            }


        }

        [HttpGet]
        public PartialViewResult AgregarMunicipalAsignado()
        {
            return PartialView("_RegistrarNumeroPredio", new NumeracionPredioViewModel()
            {
                Estado = 1,
                Opcion = 1,
                ListarTipoDireccion = new CotitularidadHandler().ListadoTipoDireccion(),
                ListTipoInterior = new CotitularidadHandler().TipoInterior(),
                //ListEstadoInterior = new CotitularidadHandler().EstadoInterior(),
                ListEstadoInterior = new List<SelectListItem>(),
                ListInscripcionCatastral = new CotitularidadHandler().ListarInscripcionCatastral()
            });
        }

        [HttpPost]
        public PartialViewResult AgregarMunicipalAsignado(NumeracionPredioViewModel model)
        {

            //NumeracionPredioViewModel Direccion = new NumeracionPredioViewModel();
            NumeracionPredioViewModel Direccion = new CotitularidadHandler().RecuperarMunicipalDirec(model);
            Direccion.Estado = 2;
            //Direccion.Opcion = 1;
            Direccion.ListarTipoDireccion = new CotitularidadHandler().ListadoTipoDireccion();
            Direccion.ListTipoInterior = new CotitularidadHandler().TipoInterior();
            Direccion.ListEstadoInterior = new CotitularidadHandler().EstadoInteriorAsignacion(Direccion.Asignacion, Direccion.Opcion.ToString());
            Direccion.ListEstadoInterior = new List<SelectListItem>();
            Direccion.ListInscripcionCatastral = new CotitularidadHandler().ListarInscripcionCatastral();
            return PartialView("_RegistrarNumeroPredio", Direccion);
        }

        [HttpPost]
        public PartialViewResult AgregarMunicipalAsignadoTemporal(NumeracionPredioViewModel model)
        {

            //NumeracionPredioViewModel Direccion = new NumeracionPredioViewModel();
            NumeracionPredioViewModel Direccion = new CotitularidadHandler().RecuperarMunicipalDirec(model);
            Direccion.Estado = 1;
            Direccion.Opcion = 2;
            Direccion.CodigoCorrDirecUnidad = "";
            Direccion.EstadoInterior = null;
            Direccion.TipoInscripcion = null;
            Direccion.TipoInterior = null;
            Direccion.NumeroInterior = null;
            Direccion.LetraInterior = null;
            Direccion.ListarTipoDireccion = new CotitularidadHandler().ListadoTipoDireccion();
            Direccion.ListTipoInterior = new CotitularidadHandler().TipoInterior();
            Direccion.ListEstadoInterior = new CotitularidadHandler().EstadoInteriorAsignacion(Direccion.Asignacion, Direccion.Opcion.ToString());
            Direccion.ListEstadoInterior = new List<SelectListItem>();
            Direccion.ListInscripcionCatastral = new CotitularidadHandler().ListarInscripcionCatastral();
            return PartialView("_RegistrarNumeroPredio", Direccion);
        }


        [HttpGet]
        public PartialViewResult AgregarTitular()
        {
            ViewBag.ListVBTipoDocumentoIdentidad = new CotitularidadHandler().ListadoTipoDocumentoIdentidad();
            ViewBag.ListVBCondicionPropietario = new CotitularidadHandler().CondicionPropiedad();
            return PartialView("_RegistrarTitular");
        }

        [HttpGet]
        public PartialViewResult AgregarDocumentoRPP()
        {
            return PartialView("_RegistrarDocumentoRRPP");
        }

        [HttpGet]
        public PartialViewResult AgregarExpeDoc()
        {
            return PartialView("_RegistrarExpedienteDoc");
        }

        [HttpGet]
        public PartialViewResult AgregarLicenciaFunc()
        {
            return PartialView("_RegistrarLicenciaFunc");
        }

        [HttpGet]
        public PartialViewResult AgregarObrasPrivadas()
        {
            return PartialView("_RegistrarObrasPrivadas");
        }

        /*[HttpPost]
        public PartialViewResult AgregarMunicipalAsignado(NumeracionPredioViewModel model)
        {
            NumeracionPredioViewModel Municipal = new CotitularidadHandler().RecuperarMunicipalDirec(model);
            Municipal.Estado = 2;
            Municipal.ListTipoInterior = new CotitularidadHandler().TipoInterior();
            Municipal.ListEstadoInterior = new CotitularidadHandler().EstadoInterior();
            Municipal.ListInscripcionCatastral = new CotitularidadHandler().ListarInscripcionCatastral();
            return PartialView("_RegistrarNumeroPredio", Municipal);
        }*/

        [HttpPost]
        public ActionResult GrabarImagen(CotitularidadViewModel model)
        {
            Nullable<bool> EstadoProceso = new CotitularidadHandler().GrabarUnidadImagen(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente " });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        [HttpPost]
        public ActionResult CargarImagen(CotitularidadViewModel model)
        {

            return Json(new { success = true, responseText = "Imagen subida correctamente ", imagen = new CotitularidadHandler().RecuperarLoteImagen(model) });
            //byte[] bytes = new CotitularidadHandler().RecuperarLoteImagen(model);
            //if (bytes == null || !bytes.Any())
            //    return Content("false");
            //return File(bytes, "image/png");
            //return Json(new { initialPreview = new string[] { "<img src='C:\\\\ARCHIVOS\\REPOSIC\\2018\\JULIO\\MSICAS20180709122321316.PNG' class='file-preview-image' alt='Desert'>" } });
        }

        [HttpPost]
        public ActionResult CargarListasNumeroPredio(CotitularidadViewModel Unidad, string Asignacion, string Opcion)
        {
            List<SelectListItem> resultado = new CotitularidadHandler().ListadoLoteVia(Unidad, Asignacion);
            List<SelectListItem> resultadoTipoInterior = new CotitularidadHandler().TipoInterior();
            List<SelectListItem> resultadoEstadoInterior = new CotitularidadHandler().EstadoInteriorAsignacion(Asignacion, Opcion);
            return Json(new { success = true, ListarLoteVia = resultado, ListarTipoInterior = resultadoTipoInterior, ListarEstadoInterior = resultadoEstadoInterior });
        }

        [HttpPost]
        public ActionResult CargarListasInterior()
        {
            List<SelectListItem> resultadoTipoInterior = new CotitularidadHandler().TipoInterior();
            List<SelectListItem> resultadoEstadoInterior = new CotitularidadHandler().EstadoInterior();
            return Json(new { success = true, ListarTipoInterior = resultadoTipoInterior, ListarEstadoInterior = resultadoEstadoInterior });
        }

        [HttpPost]
        public ActionResult CargarCuadra(CotitularidadViewModel Unidad, string concodvia)
        {
            List<SelectListItem> resultadoCuadra = new CotitularidadHandler().ListadoCuadra(Unidad, concodvia);
            return Json(new { success = true, ListarCuadra = resultadoCuadra });
        }


        [HttpPost]
        public ActionResult CargarLado(CotitularidadViewModel Unidad, string concodvia, int cuadra)
        {
            List<SelectListItem> resultadoLado = new CotitularidadHandler().ListadoLado(Unidad, concodvia, cuadra);
            return Json(new { success = true, ListarLado = resultadoLado });
        }

        [HttpPost]
        public ActionResult CargarEdificacion(CotitularidadViewModel Unidad, string concodvia, int cuadra, string lado)
        {
            List<SelectListItem> resultadoEdificacion = new CotitularidadHandler().ListadoEdificacion(Unidad, concodvia, cuadra, lado);
            return Json(new { success = true, ListarEdificacion = resultadoEdificacion });
        }

        [HttpPost]
        public ActionResult CargarPuerta(CotitularidadViewModel Unidad, string concodvia, int cuadra, string lado, string edificacion)
        {
            List<SelectListItem> resultadoPuerta = new CotitularidadHandler().ListadoPuerta(Unidad, concodvia, cuadra, lado, edificacion);
            return Json(new { success = true, ListarPuerta = resultadoPuerta });
        }

        [HttpPost]


        public JsonResult BuscarLoteLinderos(DataTableAjaxPostModel model, QuintaLinderosViewModel FiltrarDirecMunicipal)
        {

            int totalResultado = 0;
            List<QuintaLinderosViewModel> resultado = new List<QuintaLinderosViewModel>();
            if (FiltrarDirecMunicipal.codUniCat != null)
            {
                resultado = new CotitularidadHandler().BuscarLoteLinderos(FiltrarDirecMunicipal);
                totalResultado = resultado.Count;
            }
            foreach (var item in resultado)
            {

                item.ListaUnidadColindantes = string.Empty;
                foreach (var itemDet in item.ListaColindantes)
                {
                    item.ListaUnidadColindantes += itemDet.Text + " <br/><hr/>";
                }

            }

            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public ActionResult EliminarLinderoUnidad(QuintaLinderosViewModel model)
        {
            Nullable<bool> EstadoProceso = new CotitularidadHandler().EliminarLinderoUnidad(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpGet]
        public PartialViewResult AgregarLindero(string id)
        {
            return PartialView("_RegistrarLindero", new QuintaLinderosViewModel()
            {
                ListLado = new CotitularidadHandler().ListarLadoLinderoSelect(),
                ListTipoColindante = new CotitularidadHandler().ListarTipoColindanteSelect(),
                CodigoLado = id,
                Estado = "1"
            });
        }
        [HttpPost]
        public PartialViewResult AgregarLindero(QuintaLinderosViewModel model)
        {
            QuintaLinderosViewModel Lindero = new CotitularidadHandler().RecuperarUnidadLinderoDetalle(model);
            Lindero.Estado = "2";
            return PartialView("_RegistrarLindero", Lindero);
        }
        public JsonResult CargarDetalleColindante(DataTableAjaxPostModel model, QuintaLinderosViewModel FiltrarDirecMunicipal)
        {

            int totalResultado = 0;
            List<QuintaLinderosViewModel> resultado = new List<QuintaLinderosViewModel>();

            resultado = new CotitularidadHandler().CargarDetalleColindante(FiltrarDirecMunicipal);
            totalResultado = resultado.Count;


            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        public ActionResult EliminarDetalleLindero(QuintaLinderosViewModel model)
        {
            Nullable<bool> EstadoProceso = new CotitularidadHandler().EliminarDetalleLindero(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult GrabarUnidadLinderoDetalle(QuintaLinderosViewModel model)
        {
            var EstadoProceso = new CotitularidadHandler().GrabarUnidadLinderoDetalle(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente", codigo = EstadoProceso.CODIGO });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
    }
}