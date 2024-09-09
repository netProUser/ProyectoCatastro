using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.UnidadCatastral;
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
    public class UnidadCatastralController : Controller
    {
        //
        // GET: /UnidadCatastral/
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
            ViewBag.ListTipoLlenado = new UnidadCatastralHandler().ListadoTipoLlenado();
            VariablesWeb.Estatico = "";
            return View(new FiltrarUnidadCatastralViewModel
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
        public ActionResult Estatico()
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
            ViewBag.ListTipoLlenado = new UnidadCatastralHandler().ListadoTipoLlenado();
            ViewBag.ListVBTipoAnuncio = new UnidadCatastralHandler().ListadoTipoAnuncio();
            VariablesWeb.Estatico = "true";
            return View("Index", new FiltrarUnidadCatastralViewModel
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
                Estatico = true,
            });
        }

        public ActionResult Consultas()
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
            ViewBag.ListTipoLlenado = new UnidadCatastralHandler().ListadoTipoLlenado();
            VariablesWeb.Estatico = "true";
            return View("Index", new FiltrarUnidadCatastralViewModel
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
                Estatico = true,
                Consultas = true,
            });
        }

        [HttpPost]
        public ActionResult BuscarSolicitud(FiltrarUnidadCatastralViewModel modelo)
        {
            MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo.ProcedimientoNuevoViewModel ProcedimientoNuevo = new UnidadCatastralHandler().BuscarSolicitudes(modelo);
            if (ProcedimientoNuevo.NumeroSolicitud == null)
            {
                return Json(new { success = false, ProcedimientoNuevo = "" });
            }
            return Json(new { success = true, ProcedimientoNuevo = ProcedimientoNuevo });
        }

        public JsonResult BuscarSolicitudEstatico(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel modelo)
        {
           
            int totalResultado;
            var resultado = new UnidadCatastralHandler().BuscarUnidades(model, modelo, out totalResultado);

            return Json(new { success = true, draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
      
        }
        [HttpPost]
        public ActionResult BuscarUnidadSolicitud(FiltrarUnidadCatastralViewModel modelo)
        {
            UnidadSolicitudViewModel resultado = new UnidadCatastralHandler().BuscarUnidadSolicitud(modelo);
            if (resultado == null)
            {
                return Json(new { success = false });
            }
            return Json(new { success = true, Lotes = resultado });
        }
        [HttpPost]
        public ActionResult CargarOtrasInstalaciones(string anio)
        {
            List<SelectListItem> listaOtrasInstalaciones = new UnidadCatastralHandler().ListarOtrasInstalaciones(anio);
            return Json(listaOtrasInstalaciones, "json");
        }

        public ActionResult EliminarUnidadTemporal(SolicitudUnidadViewModel model)
        {
            Nullable<bool> EstadoProceso = new UnidadCatastralHandler().EliminarUnidadTemporal(model);
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
            var resultado = new UnidadCatastralHandler().RecargarTablaSolUnidad(model, FiltrarProcedimientoNuevo, out totalResultado);
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
            List<BE.SIC_RETORNO> ListEstadoProceso = new UnidadCatastralHandler().GrabarUnidadNuevo(model);
            //if (EstadoProceso.Ok == true)
            //{
            //    return Json(new { success = true, responseText = "Grabo correctamente" });
            //}
            return Json(new { ListEstadoProceso = ListEstadoProceso, success = false, responseText = "Error del servidor" });
        }

        [HttpPost]
        public ActionResult ValidarUnidadNuevo(SolicitudUnidadViewModel model)
        {
            BE.SIC_RETORNO ListEstadoProceso = new UnidadCatastralHandler().ValidarUnidadNuevo(model);
            //if (EstadoProceso.Ok == true)
            //{
            //    return Json(new { success = true, responseText = "Grabo correctamente" });
            //}
            return Json(new { ListEstadoProceso = ListEstadoProceso, success = false, responseText = "Error del servidor" });
        }

        [HttpPost]
        public ActionResult GrabarUnidadAcum(List<SolicitudUnidadViewModel> model)
        {
            List<BE.SIC_RETORNO> ListEstadoProceso = new UnidadCatastralHandler().GrabarUnidadAcum(model);
            //if (EstadoProceso.Ok == true)
            //{
            //    return Json(new { success = true, responseText = "Grabo correctamente" });
            //}
            return Json(new { ListEstadoProceso = ListEstadoProceso, success = false, responseText = "Error del servidor" });
        }

        [HttpPost]
        public ActionResult RegistrarUnidadCatastral(UnidadCatastralViewModel UnidadCatastral, List<LineasContructivasViewModel> ListaLineasContruc,
            List<OtrasInstalacionesViewModel> ListaOtrasInstalaciones, List<ActividadEconomicaViewModel> ListaActividadEconomica,
            List<ObservacionViewModel> ListaObservacionesGeneral, List<ObservacionViewModel> ListaObservacionesSunarp,
            List<ObservacionViewModel> ListaObservacionesCarga, List<QuintaLinderosViewModel> ListaLinderos)
        {

            //UnidadCatastral.Estado = 1;
            BE.SIC_RETORNO entSIC_RETORNO = new UnidadCatastralHandler().ProcesarUnidadCatastral(UnidadCatastral);

            if (ListaLineasContruc != null)
            {
                foreach (LineasContructivasViewModel LineasContruc in ListaLineasContruc)
                {
                    if (LineasContruc != null)
                    {
                        LineasContruc.Estado = LineasContruc.Eliminado == "0" ? (LineasContruc.CodigoCorrelativo == null ? 1 : 2) : 3;
                        BE.SIC_RETORNO entSIC_RETORNO_CONSTRUC = new UnidadCatastralHandler().ProcesarLineasConstructivas(LineasContruc);
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
                        BE.SIC_RETORNO entSIC_RETORNO_CONSTRUC = new UnidadCatastralHandler().ProcesarOtrasInstalaciones(OtrasInstalaciones);
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
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new UnidadCatastralHandler().ProcesarActividadEconomica(ActividadEconomica);
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
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new UnidadCatastralHandler().ProcesarObservaciones(Observacion);
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
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new UnidadCatastralHandler().ProcesarObservaciones(Observacion);
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
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new UnidadCatastralHandler().ProcesarObservaciones(Observacion);
                    }

                }
            }

            if (ListaLinderos != null)
            {
                Nullable<bool> EstadoProceso = new UnidadCatastralHandler().GrabarLoteLinderos(ListaLinderos);
            }


            return Json(new { success = entSIC_RETORNO.Ok });
        }

        [HttpPost]
        public JsonResult CargarDirecUnidad(DataTableAjaxPostModel model, string CodigoUniCat, int flgindirec, bool Estatico)
        {
            
            // --Obtener los resultados enviando información de la pagínacion
            List<NumeracionPredioViewModel> resultado = new UnidadCatastralHandler().CargarDirecUnidad(CodigoUniCat, flgindirec, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarDocumentosRRPPLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {
            
            // --Obtener los resultados enviando información de la pagínacion
            List<LoteDocumentosRRPPViewModel> resultado = new UnidadCatastralHandler().CargarDocumentosRRPPLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }


        [HttpPost]
        public JsonResult CargarTitularRentas(DataTableAjaxPostModel model, string CodigoContribuyente, string CodigoTipoDocumentoIdentidad, string NumeroDocumento, string RazonSocial, string CodigoCatastrlalRentas)
        {

            int totalResultado = 0;
            List<TitularRentasViewModel> resultado = new List<TitularRentasViewModel>();

            if (CodigoContribuyente.Equals("") && CodigoTipoDocumentoIdentidad.Equals("") && NumeroDocumento.Equals("") && RazonSocial.Equals("")  || CodigoCatastrlalRentas.Equals(""))
            {

                resultado = new List<TitularRentasViewModel>();
                totalResultado = 0;

            }
            else
            {
                resultado = new UnidadCatastralHandler().CargarTitularRentas(CodigoContribuyente, CodigoTipoDocumentoIdentidad, NumeroDocumento, RazonSocial, CodigoCatastrlalRentas);
                totalResultado = resultado.Count;
            }
            // --Obtener los resultados enviando información de la pagínacion
                
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarLicenciaFuncLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {
            
            // --Obtener los resultados enviando información de la pagínacion
            List<LicenciaFuncViewModel> resultado = new UnidadCatastralHandler().CargarLicenciaFuncLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarObrasPublicasLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {
            
            // --Obtener los resultados enviando información de la pagínacion
            List<ObrasPublicasViewModel> resultado = new UnidadCatastralHandler().CargarObrasPublicasLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarExpedienteDocLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {

            // --Obtener los resultados enviando información de la pagínacion
            List<LoteExpedienteDocViewModel> resultado = new UnidadCatastralHandler().CargarExpedienteDocLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarUnidadTitular(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadTitularViewModel> resultado = new UnidadCatastralHandler().CargarUnidadTitular(CodigoUniCat, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarInspecciones(DataTableAjaxPostModel model, string CodUniCat, string aniosol, string  numsol, string tiposol)
        {
            // --Obtener los resultados enviando información de la pagínacion
            List<InspeccionesViewModel> resultado = new UnidadCatastralHandler().RecuperarInspecciones(CodUniCat, aniosol, numsol, tiposol);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarCartasInformes(DataTableAjaxPostModel model, string CodUniCat, string aniosol, string numsol, string tiposol, bool Estatico)
        {
            // --Obtener los resultados enviando información de la pagínacion
            if (Estatico == true) {
                List<CartasInformesViewModel> resultado = new UnidadCatastralHandler().RecuperarCartasInformes(CodUniCat, aniosol, numsol, tiposol, Estatico);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            }
            else{
                 return Json(new { draw = model.draw, recordsTotal = 0, recordsFiltered = 0, data = new UnidadCatastralHandler() });
            }
            
        }

        [HttpPost]
        public JsonResult CargarUnidadRRPP(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
            
            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadDocumentosRRPPViewModel> resultado = new UnidadCatastralHandler().CargarUnidadRRPP(CodigoUniCat, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }

        [HttpPost]
        public JsonResult CargarUnidadExpedienteDoc(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
            
            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadExpedienteDocViewModel> resultado = new UnidadCatastralHandler().CargarUnidadExpedienteDoc(CodigoUniCat, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarUnidadLicenciasFunc(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
            
            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadLicenciaFuncViewModel> resultado = new UnidadCatastralHandler().CargarUnidadLicenciaFunc(CodigoUniCat, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarUnidadObrasPrivadas(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
            
            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadObrasPrivadasViewModel> resultado = new UnidadCatastralHandler().CargarUnidadObrasPrivadas(CodigoUniCat, Estatico);
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public ActionResult RegistrarTitularCatastral(UnidadTitularViewModel Titular)
        {
            Nullable<bool> EstadoProceso = false;
                Titular.Estado = 1;
                EstadoProceso = new UnidadCatastralHandler().ProcesarUnidadTitular(Titular);

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
                EstadoProceso = new UnidadCatastralHandler().ProcesarUnidadRRPP(UnidadRRPP);
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
                EstadoProceso = new UnidadCatastralHandler().ProcesarUnidadExpedienteDoc(UnidadExpedienteDoc);
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
                EstadoProceso = new UnidadCatastralHandler().ProcesarUnidadLicenciaFunc(LicenciaFunc);
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
                EstadoProceso = new UnidadCatastralHandler().ProcesarUnidadObrasPrivadas(ObrasPrivadas);
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
            
            BE.SIC_RETORNO entSIC_RETORNO = new UnidadCatastralHandler().ProcesarNumeracionPredio(NumeracionPredio);
            return Json(new { success = entSIC_RETORNO.Ok });
        }

        [HttpPost]
        public ActionResult EliminarMunicipalAsignado(NumeracionPredioViewModel model)
        {
            Nullable<bool> EstadoProceso = new UnidadCatastralHandler().EliminarMunicipalDirec(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult EliminarTitular(UnidadTitularViewModel model)
        {
            Nullable<bool> EstadoProceso = new UnidadCatastralHandler().EliminarTitular(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        
        [HttpPost]
        public ActionResult EliminarDocRRPP(UnidadDocumentosRRPPViewModel model)
        {
            Nullable<bool> EstadoProceso = new UnidadCatastralHandler().EliminarDocRRPP(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }


        [HttpPost]
        
        public ActionResult RecuperarUnidadCatastral(int CodUniCat, string aniosol, string numsol, string tiposol, string docsol, string accion)
        {
            BE.SIC_RETORNO SIC_RETORNO_VAL = new UnidadCatastralHandler().ValidarYaTemporal(CodUniCat, aniosol, numsol, tiposol, docsol);

            if (SIC_RETORNO_VAL.NoMENSAJE == 20008)
            {
                bool resul = false;
                UnidadCatastralViewModel resultado = new UnidadCatastralHandler().RecuperarUnidadCatastral(CodUniCat, out resul);
                List<LineasContructivasViewModel> ListLineasConstructivas = new UnidadCatastralHandler().RecuperarUnidadListaConstruccion(CodUniCat, false);
                List<OtrasInstalacionesViewModel> ListOtrasInstalaciones = new UnidadCatastralHandler().RecuperarUnidadListaInstalaciones(CodUniCat, false);
                List<ActividadEconomicaViewModel> ListActividadEconomica = new UnidadCatastralHandler().RecuperarUnidadListaActividad(CodUniCat, false);
                List<ObservacionViewModel> ListObservacionGeneral = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010001", false);
                List<ObservacionViewModel> ListObservacionSunarp = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010002", false);
                List<ObservacionViewModel> ListObservacionCarga = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010003", false);
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
            } { 
            
                if (accion.Equals("Eliminar"))
                {
                    BE.SIC_RETORNO SIC_RETORNO_ELIM = new UnidadCatastralHandler().EliminarTemporal(CodUniCat);
                    BE.SIC_RETORNO entSIC_RETORNO_ACT = new UnidadCatastralHandler().ActualizarFlgTemporalNull(CodUniCat);
                }

                BE.SIC_RETORNO SIC_RETORNO = new UnidadCatastralHandler().ValidarTemporal(CodUniCat, aniosol, numsol, tiposol, docsol);

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
                    BE.SIC_RETORNO entSIC_RETORNO_UC = new UnidadCatastralHandler().ProcesarMigracionEstaticoTemporal(CodUniCat);
                    BE.SIC_RETORNO entSIC_RETORNO_ACT = new UnidadCatastralHandler().ActualizarFlgTemporal(CodUniCat, aniosol, numsol, tiposol, docsol, "T");

                    bool resul = false;
                    UnidadCatastralViewModel resultado = new UnidadCatastralHandler().RecuperarUnidadCatastral(CodUniCat, out resul);
                    List<LineasContructivasViewModel> ListLineasConstructivas = new UnidadCatastralHandler().RecuperarUnidadListaConstruccion(CodUniCat, false);
                    List<OtrasInstalacionesViewModel> ListOtrasInstalaciones = new UnidadCatastralHandler().RecuperarUnidadListaInstalaciones(CodUniCat, false);
                    List<ActividadEconomicaViewModel> ListActividadEconomica = new UnidadCatastralHandler().RecuperarUnidadListaActividad(CodUniCat, false);
                    List<ObservacionViewModel> ListObservacionGeneral = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010001", false);
                    List<ObservacionViewModel> ListObservacionSunarp = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010002", false);
                    List<ObservacionViewModel> ListObservacionCarga = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010003", false);
                    
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
                    UnidadCatastralViewModel resultado = new UnidadCatastralHandler().RecuperarUnidadCatastralEST(CodUniCat, Estatico, out resul);
                    List<LineasContructivasViewModel> ListLineasConstructivas = new UnidadCatastralHandler().RecuperarUnidadListaConstruccion(CodUniCat, true);
                    List<OtrasInstalacionesViewModel> ListOtrasInstalaciones = new UnidadCatastralHandler().RecuperarUnidadListaInstalaciones(CodUniCat, true);
                    List<ActividadEconomicaViewModel> ListActividadEconomica = new UnidadCatastralHandler().RecuperarUnidadListaActividad(CodUniCat, true);
                    List<ObservacionViewModel> ListObservacionGeneral = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010001", true);
                    List<ObservacionViewModel> ListObservacionSunarp = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010002", true);
                    List<ObservacionViewModel> ListObservacionCarga = new UnidadCatastralHandler().RecuperarObservacion(CodUniCat, "010003", true);

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
            string Descripcion="";
            if (Codigo.Equals("")){
                return Json(new { success = false, Descripcion = Descripcion });
            }
            else
            {
                 Descripcion = new UnidadCatastralHandler().ObtenerDescripcionInstalacion(Codigo);
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
                ListarTipoDireccion = new UnidadCatastralHandler().ListadoTipoDireccion(),
                ListTipoInterior = new UnidadCatastralHandler().TipoInterior(),
                //ListEstadoInterior = new UnidadCatastralHandler().EstadoInterior(),
                ListEstadoInterior = new List<SelectListItem>(),
                ListInscripcionCatastral = new UnidadCatastralHandler().ListarInscripcionCatastral()
            });
        }

        [HttpPost]
        public PartialViewResult AgregarMunicipalAsignado(NumeracionPredioViewModel model)
        {

            //NumeracionPredioViewModel Direccion = new NumeracionPredioViewModel();
            NumeracionPredioViewModel Direccion = new UnidadCatastralHandler().RecuperarMunicipalDirec(model);
            Direccion.Estado = 2;
            //Direccion.Opcion = 1;
            Direccion.ListarTipoDireccion = new UnidadCatastralHandler().ListadoTipoDireccion();
            Direccion.ListTipoInterior = new UnidadCatastralHandler().TipoInterior();
            Direccion.ListEstadoInterior = new UnidadCatastralHandler().EstadoInteriorAsignacion(Direccion.Asignacion, Direccion.Opcion.ToString());
            Direccion.ListEstadoInterior = new List<SelectListItem>();
            Direccion.ListInscripcionCatastral = new UnidadCatastralHandler().ListarInscripcionCatastral();
            return PartialView("_RegistrarNumeroPredio", Direccion);
        }

        [HttpPost]
        public PartialViewResult AgregarMunicipalAsignadoTemporal(NumeracionPredioViewModel model)
        {

            //NumeracionPredioViewModel Direccion = new NumeracionPredioViewModel();
            NumeracionPredioViewModel Direccion = new UnidadCatastralHandler().RecuperarMunicipalDirec(model);
            Direccion.Estado = 1;
            Direccion.Opcion = 2;
            Direccion.CodigoCorrDirecUnidad = "";
            Direccion.EstadoInterior = null;
            Direccion.TipoInscripcion = null;
            Direccion.TipoInterior = null;
            Direccion.NumeroInterior = null;
            Direccion.LetraInterior = null;
            Direccion.ListarTipoDireccion = new UnidadCatastralHandler().ListadoTipoDireccion();
            Direccion.ListTipoInterior = new UnidadCatastralHandler().TipoInterior();
            Direccion.ListEstadoInterior = new UnidadCatastralHandler().EstadoInteriorAsignacion(Direccion.Asignacion, Direccion.Opcion.ToString());
            Direccion.ListEstadoInterior = new List<SelectListItem>();
            Direccion.ListInscripcionCatastral = new UnidadCatastralHandler().ListarInscripcionCatastral();
            return PartialView("_RegistrarNumeroPredio", Direccion);
        }


        [HttpGet]
        public PartialViewResult AgregarTitular()
        {
            ViewBag.ListVBTipoDocumentoIdentidad = new UnidadCatastralHandler().ListadoTipoDocumentoIdentidad();
            ViewBag.ListVBCondicionPropietario = new UnidadCatastralHandler().CondicionPropiedad();
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
            NumeracionPredioViewModel Municipal = new UnidadCatastralHandler().RecuperarMunicipalDirec(model);
            Municipal.Estado = 2;
            Municipal.ListTipoInterior = new UnidadCatastralHandler().TipoInterior();
            Municipal.ListEstadoInterior = new UnidadCatastralHandler().EstadoInterior();
            Municipal.ListInscripcionCatastral = new UnidadCatastralHandler().ListarInscripcionCatastral();
            return PartialView("_RegistrarNumeroPredio", Municipal);
        }*/

        [HttpPost]
        public ActionResult GrabarImagen(UnidadCatastralViewModel model)
        {
            Nullable<bool> EstadoProceso = new UnidadCatastralHandler().GrabarUnidadImagen(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente " });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        [HttpPost]
        public ActionResult CargarImagen(UnidadCatastralViewModel model)
        {

            return Json(new { success = true, responseText = "Imagen subida correctamente ", imagen = new UnidadCatastralHandler().RecuperarLoteImagen(model) });
            //byte[] bytes = new UnidadCatastralHandler().RecuperarLoteImagen(model);
            //if (bytes == null || !bytes.Any())
            //    return Content("false");
            //return File(bytes, "image/png");
            //return Json(new { initialPreview = new string[] { "<img src='C:\\\\ARCHIVOS\\REPOSIC\\2018\\JULIO\\MSICAS20180709122321316.PNG' class='file-preview-image' alt='Desert'>" } });
        }

        [HttpPost]
        public ActionResult CargarListasNumeroPredio(UnidadCatastralViewModel Unidad, string Asignacion, string Opcion)
        {
            List<SelectListItem> resultado = new UnidadCatastralHandler().ListadoLoteVia(Unidad, Asignacion);
            List<SelectListItem> resultadoTipoInterior = new UnidadCatastralHandler().TipoInterior();
            List<SelectListItem> resultadoEstadoInterior = new UnidadCatastralHandler().EstadoInteriorAsignacion(Asignacion, Opcion);
            return Json(new { success = true, ListarLoteVia = resultado, ListarTipoInterior = resultadoTipoInterior, ListarEstadoInterior = resultadoEstadoInterior });
        }

        [HttpPost]
        public ActionResult CargarListasInterior()
        {
            List<SelectListItem> resultadoTipoInterior = new UnidadCatastralHandler().TipoInterior();
            List<SelectListItem> resultadoEstadoInterior = new UnidadCatastralHandler().EstadoInterior();
            return Json(new { success = true, ListarTipoInterior = resultadoTipoInterior, ListarEstadoInterior = resultadoEstadoInterior });
        }

        [HttpPost]
        public ActionResult CargarCuadra(UnidadCatastralViewModel Unidad, string concodvia)
        {
            List<SelectListItem> resultadoCuadra = new UnidadCatastralHandler().ListadoCuadra(Unidad, concodvia);
            return Json(new { success = true, ListarCuadra = resultadoCuadra});
        }


        [HttpPost]
        public ActionResult CargarLado(UnidadCatastralViewModel Unidad, string concodvia, int cuadra)
        {
            List<SelectListItem> resultadoLado = new UnidadCatastralHandler().ListadoLado(Unidad, concodvia, cuadra);
            return Json(new { success = true, ListarLado = resultadoLado });
        }

        [HttpPost]
        public ActionResult CargarEdificacion(UnidadCatastralViewModel Unidad, string concodvia, int cuadra, string lado)
        {
            List<SelectListItem> resultadoEdificacion = new UnidadCatastralHandler().ListadoEdificacion(Unidad, concodvia, cuadra, lado);
            return Json(new { success = true, ListarEdificacion = resultadoEdificacion });
        }

        [HttpPost]
        public ActionResult CargarPuerta(UnidadCatastralViewModel Unidad, string concodvia, int cuadra, string lado, string edificacion)
        {
            List<SelectListItem> resultadoPuerta = new UnidadCatastralHandler().ListadoPuerta(Unidad, concodvia, cuadra, lado,edificacion);
            return Json(new { success = true, ListarPuerta = resultadoPuerta });
        }

        [HttpPost]
    

        public JsonResult BuscarLoteLinderos(DataTableAjaxPostModel model, QuintaLinderosViewModel FiltrarDirecMunicipal)
        {

            int totalResultado = 0;
            List<QuintaLinderosViewModel> resultado = new List<QuintaLinderosViewModel>();
            if (FiltrarDirecMunicipal.codUniCat != null)
            {
                resultado = new UnidadCatastralHandler().BuscarLoteLinderos(FiltrarDirecMunicipal);
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
            Nullable<bool> EstadoProceso = new UnidadCatastralHandler().EliminarLinderoUnidad(model);
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
                ListLado = new UnidadCatastralHandler().ListarLadoLinderoSelect(),
                ListTipoColindante = new UnidadCatastralHandler().ListarTipoColindanteSelect(),
                CodigoLado = id,
                Estado = "1"
            });
        }
        [HttpPost]
        public PartialViewResult AgregarLindero(QuintaLinderosViewModel model)
        {
            QuintaLinderosViewModel Lindero = new UnidadCatastralHandler().RecuperarUnidadLinderoDetalle(model);
            Lindero.Estado = "2";
            return PartialView("_RegistrarLindero", Lindero);
        }
        public JsonResult CargarDetalleColindante(DataTableAjaxPostModel model, QuintaLinderosViewModel FiltrarDirecMunicipal)
        {

            int totalResultado = 0;
            List<QuintaLinderosViewModel> resultado = new List<QuintaLinderosViewModel>();

            resultado = new UnidadCatastralHandler().CargarDetalleColindante(FiltrarDirecMunicipal);
            totalResultado = resultado.Count;


            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        public ActionResult EliminarDetalleLindero(QuintaLinderosViewModel model)
        {
            Nullable<bool> EstadoProceso = new UnidadCatastralHandler().EliminarDetalleLindero(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult GrabarUnidadLinderoDetalle(QuintaLinderosViewModel model)
        {
            var EstadoProceso = new UnidadCatastralHandler().GrabarUnidadLinderoDetalle(model);
            if (EstadoProceso.Ok == true )
            {
                return Json(new { success = true, responseText = "Grabo correctamente" , codigo = EstadoProceso.CODIGO });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
  
       


    }
}