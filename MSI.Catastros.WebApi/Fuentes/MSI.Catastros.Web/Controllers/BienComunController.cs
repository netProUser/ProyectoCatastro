using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.BienComun;
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
    public class BienComunController : Controller
    {
        //
        // GET: /BienComun/
        public ActionResult Index()
        {
            ViewBag.ListVBEstadoConservacion = new BienComunHandler().ListarEstadoConservacion();
            ViewBag.ListVBMaterialEstructural = new BienComunHandler().ListadoMaterialEstructural();
            ViewBag.ListVBMes = new BienComunHandler().ListadoMes();
            ViewBag.ListVBOtrasInstalaciones = new BienComunHandler().ListadoOtrasInstalaciones();
            ViewBag.ListVBUnidadMedida = new BienComunHandler().ListadoUnidadMedida();
           // ViewBag.ListVBOtrasInstalaciones = new BienComunHandler().ListarOtrasInstalaciones();
            ViewBag.ListVBCodigoOtrasInstalaciones = new BienComunHandler().ListarCodigoOtrasInstalaciones();
            ViewBag.ListVBUsoPredio = new BienComunHandler().ListarUsoPredio();
            ViewBag.ListVBCodigoUsoPredio = new BienComunHandler().ListarCodigoUsoPredio();
            ViewBag.ListVBTipoSiNo = new BienComunHandler().ListadoTipoSiNo();
            ViewBag.ListVBTipoAnuncio = new BienComunHandler().ListadoTipoAnuncio();
            VariablesWeb.Estatico = "";
            return View(new FiltrarBienComunViewModel
            {
                FiltrarListTipoSolicitud = new BienComunHandler().ListadoTipoSolicitud(),
                FiltrarListTipoDocumento = new BienComunHandler().ListadoTipoDocumento(),
                ListEstadoContruccion = new BienComunHandler().ListadoEstadoConstruccion(),
                ListCodigoInscripcionCatastral = new BienComunHandler().ListarCodigoInscripcion(),
                ListInscripcionCatastral = new BienComunHandler().ListarInscripcionCatastral(),
                ListFuenteInscripcionCatastral = new BienComunHandler().ListadoFuenteInscripcionCatastral(),
                ListClasificacionPredio = new BienComunHandler().ListarClasificacionPredio(),
                ListDepartamentoPredio = new BienComunHandler().ListarTipoDepartamentoPredio(),
                ListUsoPredio = new BienComunHandler().ListarUsoPredio(),
                ListDenominacion = new List<SelectListItem>(),

            });
            //return View(new BienComunViewModel());

        }
        public ActionResult Estatico()
        {
            ViewBag.ListVBEstadoConservacion = new BienComunHandler().ListarEstadoConservacion();
            ViewBag.ListVBMaterialEstructural = new BienComunHandler().ListadoMaterialEstructural();
            ViewBag.ListVBMes = new BienComunHandler().ListadoMes();
            ViewBag.ListVBOtrasInstalaciones = new BienComunHandler().ListadoOtrasInstalaciones();
            ViewBag.ListVBUnidadMedida = new BienComunHandler().ListadoUnidadMedida();
            // ViewBag.ListVBOtrasInstalaciones = new BienComunHandler().ListarOtrasInstalaciones();
            ViewBag.ListVBCodigoOtrasInstalaciones = new BienComunHandler().ListarCodigoOtrasInstalaciones();
            ViewBag.ListVBUsoPredio = new BienComunHandler().ListarUsoPredio();
            ViewBag.ListVBCodigoUsoPredio = new BienComunHandler().ListarCodigoUsoPredio();
            ViewBag.ListVBTipoSiNo = new BienComunHandler().ListadoTipoSiNo();
            ViewBag.ListVBTipoAnuncio = new BienComunHandler().ListadoTipoAnuncio();
            VariablesWeb.Estatico = "true";
            return View("Index", new FiltrarBienComunViewModel
            {
                FiltrarListTipoSolicitud = new BienComunHandler().ListadoTipoSolicitud(),
                FiltrarListTipoDocumento = new BienComunHandler().ListadoTipoDocumento(),
                ListEstadoContruccion = new BienComunHandler().ListadoEstadoConstruccion(),
                ListCodigoInscripcionCatastral = new BienComunHandler().ListarCodigoInscripcion(),
                ListInscripcionCatastral = new BienComunHandler().ListarInscripcionCatastral(),
                ListFuenteInscripcionCatastral = new BienComunHandler().ListadoFuenteInscripcionCatastral(),
                ListClasificacionPredio = new BienComunHandler().ListarClasificacionPredio(),
                ListDepartamentoPredio = new BienComunHandler().ListarTipoDepartamentoPredio(),
                ListUsoPredio = new BienComunHandler().ListarUsoPredio(),
                ListDenominacion = new List<SelectListItem>(),
                Estatico = true
            });
            //return View(new BienComunViewModel());

        }
        public ActionResult Consultas()
        {
            ViewBag.ListVBEstadoConservacion = new BienComunHandler().ListarEstadoConservacion();
            ViewBag.ListVBMaterialEstructural = new BienComunHandler().ListadoMaterialEstructural();
            ViewBag.ListVBMes = new BienComunHandler().ListadoMes();
            ViewBag.ListVBOtrasInstalaciones = new BienComunHandler().ListadoOtrasInstalaciones();
            ViewBag.ListVBUnidadMedida = new BienComunHandler().ListadoUnidadMedida();
            // ViewBag.ListVBOtrasInstalaciones = new BienComunHandler().ListarOtrasInstalaciones();
            ViewBag.ListVBCodigoOtrasInstalaciones = new BienComunHandler().ListarCodigoOtrasInstalaciones();
            ViewBag.ListVBUsoPredio = new BienComunHandler().ListarUsoPredio();
            ViewBag.ListVBCodigoUsoPredio = new BienComunHandler().ListarCodigoUsoPredio();
            ViewBag.ListVBTipoSiNo = new BienComunHandler().ListadoTipoSiNo();
            ViewBag.ListVBTipoAnuncio = new BienComunHandler().ListadoTipoAnuncio();
            VariablesWeb.Estatico = "true";
            return View("Index", new FiltrarBienComunViewModel
            {
                FiltrarListTipoSolicitud = new BienComunHandler().ListadoTipoSolicitud(),
                FiltrarListTipoDocumento = new BienComunHandler().ListadoTipoDocumento(),
                ListEstadoContruccion = new BienComunHandler().ListadoEstadoConstruccion(),
                ListCodigoInscripcionCatastral = new BienComunHandler().ListarCodigoInscripcion(),
                ListInscripcionCatastral = new BienComunHandler().ListarInscripcionCatastral(),
                ListFuenteInscripcionCatastral = new BienComunHandler().ListadoFuenteInscripcionCatastral(),
                ListClasificacionPredio = new BienComunHandler().ListarClasificacionPredio(),
                ListDepartamentoPredio = new BienComunHandler().ListarTipoDepartamentoPredio(),
                ListUsoPredio = new BienComunHandler().ListarUsoPredio(),
                ListDenominacion = new List<SelectListItem>(),
                Estatico = true,
                Consultas = true,
            });
            //return View(new BienComunViewModel());

        }


        [HttpPost]
        public ActionResult BuscarSolicitud(FiltrarBienComunViewModel modelo)
        {
            MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo.ProcedimientoNuevoViewModel 
                ProcedimientoNuevo = new BienComunHandler().BuscarSolicitudes(modelo);
            if (ProcedimientoNuevo.NumeroSolicitud == null)
            {
                return Json(new { success = false, ProcedimientoNuevo = "" });
            }
            return Json(new { success = true, ProcedimientoNuevo = ProcedimientoNuevo });
        }
        public JsonResult  BuscarSolicitudEstatico(DataTableAjaxPostModel model, FiltrarBienComunViewModel modelo)
        {
            int totalResultado;
            var resultado = new BienComunHandler().BuscarUnidades(model, modelo, out totalResultado);
            return Json(new { success = true, draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }


        [HttpPost]
        public ActionResult CargarOtrasInstalaciones(string anio)
        {
            List<SelectListItem> listaOtrasInstalaciones = new BienComunHandler().ListarOtrasInstalaciones(anio);
            return Json(listaOtrasInstalaciones, "json");
        }

        public ActionResult CargarAreaComunCalc(string anio)
        {
            List<SelectListItem> listaOtrasInstalaciones = new BienComunHandler().ListarOtrasInstalaciones(anio);
            return Json(listaOtrasInstalaciones, "json");
        }

        [HttpPost]
        public JsonResult CargarSolUnidad(DataTableAjaxPostModel model, FiltrarBienComunViewModel FiltrarProcedimientoNuevo)
        {
          
                // --Definir variables de búsqueda
                FiltrarProcedimientoNuevo.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
                FiltrarProcedimientoNuevo.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
                int totalResultado;
                // --Obtener los resultados enviando información de la pagínacion
                var resultado = new BienComunHandler().RecargarTablaSolUnidad(model, FiltrarProcedimientoNuevo, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
           
        }
        [HttpPost]
        public ActionResult RecapitularBienComun(BienComunViewModel UnidadCatastral, List<BienComunViewModel> ListaLineasBC)
        {
            BE.SIC_RETORNO entSIC_RETORNO_BC = new BE.SIC_RETORNO();;
            if (ListaLineasBC != null)
            {
                foreach (BienComunViewModel LineasBC in ListaLineasBC)
                {
                    if (LineasBC != null)
                    {
                        LineasBC.Estado = 1;
                        entSIC_RETORNO_BC = new BienComunHandler().ProcesarLineasBC(LineasBC);
                    }

                }
                BE.SIC_RETORNO entSIC_RETORNO_RECAP = new BienComunHandler().RecapitularBienComun(UnidadCatastral);
            }
            return Json(new { success = entSIC_RETORNO_BC });
        }


        [HttpPost]
        public ActionResult RegistrarBienComun(BienComunViewModel UnidadCatastral, List<LineasContructivasViewModel> ListaLineasContruc,
            List<OtrasInstalacionesViewModel> ListaOtrasInstalaciones, List<ActividadEconomicaViewModel> ListaActividadEconomica,
            List<ObservacionViewModel> ListaObservacionesGeneral, List<ObservacionViewModel> ListaObservacionesSunarp,
            List<ObservacionViewModel> ListaObservacionesCarga, List<BienComunLinderosViewModel> ListaLinderos)
        {

            //UnidadCatastral.Estado = 1;
            BE.SIC_RETORNO entSIC_RETORNO = new BienComunHandler().ProcesarUnidadCatastral(UnidadCatastral);

            if (ListaLineasContruc != null)
            {
                foreach (LineasContructivasViewModel LineasContruc in ListaLineasContruc)
                {
                    if (LineasContruc != null)
                    {
                        LineasContruc.Estado = LineasContruc.Eliminado == "0" ? (LineasContruc.CodigoCorrelativo == null ? 1 : 2) : 3;
                        BE.SIC_RETORNO entSIC_RETORNO_CONSTRUC = new BienComunHandler().ProcesarLineasConstructivas(LineasContruc);
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
                        BE.SIC_RETORNO entSIC_RETORNO_CONSTRUC = new BienComunHandler().ProcesarOtrasInstalaciones(OtrasInstalaciones);
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
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new BienComunHandler().ProcesarActividadEconomica(ActividadEconomica);
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
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new BienComunHandler().ProcesarObservaciones(Observacion);
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
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new BienComunHandler().ProcesarObservaciones(Observacion);
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
                        BE.SIC_RETORNO entSIC_RETORNO_ACTECON = new BienComunHandler().ProcesarObservaciones(Observacion);
                    }

                }
            }

            if (ListaLinderos != null)
            {
                Nullable<bool> EstadoProceso = new BienComunHandler().GrabarLoteLinderos(ListaLinderos);
            }


            return Json(new { success = entSIC_RETORNO.Ok });
        }

        [HttpPost]
        public JsonResult CargarDirecUnidad(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
           
                // --Obtener los resultados enviando información de la pagínacion
                List<NumeracionPredioViewModel> resultado = new BienComunHandler().CargarDirecUnidad(CodigoUniCat, Estatico);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
           
        }

        public PartialViewResult AgregarUcNuevo()
        {
            return PartialView("_RegistrarUCNuevo", new RegistrarUnidadCatastralNuevoViewModel()
            {
                Estado = "1"
            });
        }
        [HttpGet]
        public PartialViewResult AgregarUnidadBC()
        {
            return PartialView("_RegistrarUnidad", new FiltrarUnidadCatastralViewModel()
            {
                
            });
        }
        [HttpPost]
        public ActionResult AgregarSolUnidad(List<UnidadBCViewModel> ListaUnidad)
        {
            string Mensaje = "";
            BE.SIC_RETORNO entSIC_RETORNO;
            foreach (UnidadBCViewModel SolicitudUnidad in ListaUnidad)
            {
                entSIC_RETORNO = new BienComunHandler().AgregarSolUnidadCatastral(SolicitudUnidad);
                if (entSIC_RETORNO.NoMENSAJE == 99) {
                    Mensaje = entSIC_RETORNO.MENSAJE;
                }
            }
            return Json(new { success = true, responseText = Mensaje });
        }
        [HttpPost]
        public JsonResult CargarUnidadesBC(DataTableAjaxPostModel model, string CodigoUniCat,bool Estatico)
        {
            // --Obtener los resultados enviando información de la pagínacion
            List<UnidadBCViewModel> resultado;
            if (CodigoUniCat != "")
            {
                resultado = new BienComunHandler().CargarUnidadesBC(CodigoUniCat, Estatico);
            }
            else {
                resultado = new List<UnidadBCViewModel>();
            }
            int totalResultado = resultado.Count;
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarDocumentosRRPPLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {
           
                // --Obtener los resultados enviando información de la pagínacion
                List<LoteDocumentosRRPPViewModel> resultado = new BienComunHandler().CargarDocumentosRRPPLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, Estatico);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
           
        }

        [HttpPost]
        public JsonResult CargarLicenciaFuncLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote)
        {
           
                // --Obtener los resultados enviando información de la pagínacion
                List<LicenciaFuncViewModel> resultado = new BienComunHandler().CargarLicenciaFuncLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
           
        }

        [HttpPost]
        public JsonResult CargarObrasPublicasLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {
           
                // --Obtener los resultados enviando información de la pagínacion
                List<ObrasPublicasViewModel> resultado = new BienComunHandler().CargarObrasPublicasLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, Estatico);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
           
        }

        [HttpPost]
        public JsonResult CargarExpedienteDocLote(DataTableAjaxPostModel model, string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {
           
                // --Obtener los resultados enviando información de la pagínacion
                List<LoteExpedienteDocViewModel> resultado = new BienComunHandler().CargarExpedienteDocLote(CodigoDistrito, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, Estatico);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
           
        }

        [HttpPost]
        public JsonResult CargarUnidadTitular(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
           
                // --Obtener los resultados enviando información de la pagínacion
                List<UnidadTitularViewModel> resultado = new BienComunHandler().CargarUnidadTitular(CodigoUniCat, Estatico);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
           
        }

        [HttpPost]
        public JsonResult CargarUnidadRRPP(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
           
                // --Obtener los resultados enviando información de la pagínacion
                List<UnidadDocumentosRRPPViewModel> resultado = new BienComunHandler().CargarUnidadRRPP(CodigoUniCat, Estatico);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
           
        }

        [HttpPost]
        public JsonResult CargarUnidadExpedienteDoc(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
            
                // --Obtener los resultados enviando información de la pagínacion
                List<UnidadExpedienteDocViewModel> resultado = new BienComunHandler().CargarUnidadExpedienteDoc(CodigoUniCat, Estatico);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
           
        }

        [HttpPost]
        public JsonResult CargarUnidadLicenciasFunc(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
           
                // --Obtener los resultados enviando información de la pagínacion
                List<UnidadLicenciaFuncViewModel> resultado = new BienComunHandler().CargarUnidadLicenciaFunc(CodigoUniCat, Estatico);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
           
        }

        [HttpPost]
        public JsonResult CargarUnidadObrasPrivadas(DataTableAjaxPostModel model, string CodigoUniCat, bool Estatico)
        {
            
                // --Obtener los resultados enviando información de la pagínacion
                List<UnidadObrasPrivadasViewModel> resultado = new BienComunHandler().CargarUnidadObrasPrivadas(CodigoUniCat, Estatico);
                int totalResultado = resultado.Count;
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
           
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
                EstadoProceso = new BienComunHandler().ProcesarUnidadRRPP(UnidadRRPP);
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
                EstadoProceso = new BienComunHandler().ProcesarUnidadExpedienteDoc(UnidadExpedienteDoc);
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
                EstadoProceso = new BienComunHandler().ProcesarUnidadLicenciaFunc(LicenciaFunc);
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
                EstadoProceso = new BienComunHandler().ProcesarUnidadObrasPrivadas(ObrasPrivadas);
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

            BE.SIC_RETORNO entSIC_RETORNO = new BienComunHandler().ProcesarNumeracionPredio(NumeracionPredio);
            return Json(new { success = entSIC_RETORNO.Ok });
        }
        
        [HttpPost]
        public ActionResult EliminarUnidadBC(UnidadBCViewModel model)
        {
            Nullable<bool> EstadoProceso = new BienComunHandler().EliminarUnidadBC(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult EliminarMunicipalAsignado(NumeracionPredioViewModel model)
        {
            Nullable<bool> EstadoProceso = new BienComunHandler().EliminarMunicipalDirec(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult RecuperarAreaTerrenoComun(FiltrarBienComunViewModel model)
        {
            bool resul = false;
            BienComunViewModel resultado = new BienComunHandler().RecuperarBienComunAreaTerreno(model.Coduni, model.Tipo, model.Porcentaje, out resul);
            return Json(new
            {
                success = resul,
                resultado = resultado
            });
        }

        public ActionResult RecuperarPorcentajeCalc(List<BienComunViewModel> ListaLineasBC, int CodUniCat, int CodUniPad, decimal AreaOc)
        {
            bool resul = false;
            BE.SIC_RETORNO entSIC_RETORNO_BC = new BE.SIC_RETORNO(); ;
            if (ListaLineasBC != null)
            {
                foreach (BienComunViewModel LineasBC in ListaLineasBC)
                {
                    if (LineasBC != null)
                    {
                        LineasBC.Estado = 1;
                        entSIC_RETORNO_BC = new BienComunHandler().ProcesarLineasBC(LineasBC);
                    }

                }
            }
            BienComunViewModel resultado = new BienComunHandler().RecuperarBienComunPorcCalc(CodUniCat, CodUniPad, AreaOc, out resul);
            return Json(new
            {
                success = resul,
                resultado = resultado
            });
        }

        [HttpPost]
        public ActionResult RecuperarBienComun(int CodUniCat,  string aniosol, string numsol, string tiposol, string docsol, string accion)
        {
            BE.SIC_RETORNO SIC_RETORNO_VAL = new BienComunHandler().ValidarYaTemporal(CodUniCat, aniosol, numsol, tiposol, docsol);

            if (SIC_RETORNO_VAL.NoMENSAJE == 20008)
            {
                bool resul = false;
                BienComunViewModel resultado = new BienComunHandler().RecuperarBienComun(CodUniCat, out resul);
                List<LineasContructivasViewModel> ListLineasConstructivas = new BienComunHandler().RecuperarUnidadListaConstruccion(CodUniCat, false);
                List<OtrasInstalacionesViewModel> ListOtrasInstalaciones = new BienComunHandler().RecuperarUnidadListaInstalaciones(CodUniCat, false);
                List<ActividadEconomicaViewModel> ListActividadEconomica = new BienComunHandler().RecuperarUnidadListaActividad(CodUniCat, false);
                List<ObservacionViewModel> ListObservacionGeneral = new BienComunHandler().RecuperarObservacion(CodUniCat, "010001", false);
                List<ObservacionViewModel> ListObservacionSunarp = new BienComunHandler().RecuperarObservacion(CodUniCat, "010002", false);
                List<ObservacionViewModel> ListObservacionCarga = new BienComunHandler().RecuperarObservacion(CodUniCat, "010003", false);
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
                    BE.SIC_RETORNO SIC_RETORNO_ELIM = new BienComunHandler().EliminarTemporal(CodUniCat);
                    BE.SIC_RETORNO entSIC_RETORNO_ACT = new BienComunHandler().ActualizarFlgTemporalNull(CodUniCat);
                }

                BE.SIC_RETORNO SIC_RETORNO = new BienComunHandler().ValidarTemporal(CodUniCat, aniosol, numsol, tiposol, docsol);

                if (SIC_RETORNO.NoMENSAJE == 20003)
                {
                    bool resul = false;
                    return Json(new
                    {
                        success = resul,
                        Mensaje = "20003",
                        OtraSolicitud = SIC_RETORNO.MENSAJE,
                    });

                }
                else
                {

                    BE.SIC_RETORNO entSIC_RETORNO_UC = new BienComunHandler().ProcesarMigracionEstaticoTemporal(CodUniCat);
                    BE.SIC_RETORNO entSIC_RETORNO_ACT = new BienComunHandler().ActualizarFlgTemporal(CodUniCat, aniosol, numsol, tiposol, docsol, "T");

                    bool resul = false;
                    BienComunViewModel resultado = new BienComunHandler().RecuperarBienComun(CodUniCat, out resul);
                    List<LineasContructivasViewModel> ListLineasConstructivas = new BienComunHandler().RecuperarUnidadListaConstruccion(CodUniCat, false);
                    List<OtrasInstalacionesViewModel> ListOtrasInstalaciones = new BienComunHandler().RecuperarUnidadListaInstalaciones(CodUniCat, false);
                    List<ActividadEconomicaViewModel> ListActividadEconomica = new BienComunHandler().RecuperarUnidadListaActividad(CodUniCat, false);
                    List<ObservacionViewModel> ListObservacionGeneral = new BienComunHandler().RecuperarObservacion(CodUniCat, "010001", false);
                    List<ObservacionViewModel> ListObservacionSunarp = new BienComunHandler().RecuperarObservacion(CodUniCat, "010002", false);
                    List<ObservacionViewModel> ListObservacionCarga = new BienComunHandler().RecuperarObservacion(CodUniCat, "010003", false);
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

            }
            /*bool resul = false;
            BienComunViewModel resultado = new BienComunHandler().RecuperarBienComun(CodUniCat, out resul);
            List<LineasContructivasViewModel> ListLineasConstructivas = new BienComunHandler().RecuperarUnidadListaConstruccion(CodUniCat);
            List<OtrasInstalacionesViewModel> ListOtrasInstalaciones = new BienComunHandler().RecuperarUnidadListaInstalaciones(CodUniCat);
            List<ActividadEconomicaViewModel> ListActividadEconomica = new BienComunHandler().RecuperarUnidadListaActividad(CodUniCat);
            List<ObservacionViewModel> ListObservacionGeneral = new BienComunHandler().RecuperarObservacion(CodUniCat, "010001");
            List<ObservacionViewModel> ListObservacionSunarp = new BienComunHandler().RecuperarObservacion(CodUniCat, "010002");
            List<ObservacionViewModel> ListObservacionCarga = new BienComunHandler().RecuperarObservacion(CodUniCat, "010003");
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
            });*/
        }
        public ActionResult RecuperarBienComunEST(int CodUniCat)
        {
                bool resul = false;
                BienComunViewModel resultado = new BienComunHandler().RecuperarBienComunEST(CodUniCat, out resul);
                List<LineasContructivasViewModel> ListLineasConstructivas = new BienComunHandler().RecuperarUnidadListaConstruccion(CodUniCat, true);
                List<OtrasInstalacionesViewModel> ListOtrasInstalaciones = new BienComunHandler().RecuperarUnidadListaInstalaciones(CodUniCat, true);
                List<ActividadEconomicaViewModel> ListActividadEconomica = new BienComunHandler().RecuperarUnidadListaActividad(CodUniCat, true);
                List<ObservacionViewModel> ListObservacionGeneral = new BienComunHandler().RecuperarObservacion(CodUniCat, "010001", true);
                List<ObservacionViewModel> ListObservacionSunarp = new BienComunHandler().RecuperarObservacion(CodUniCat, "010002", true);
                List<ObservacionViewModel> ListObservacionCarga = new BienComunHandler().RecuperarObservacion(CodUniCat, "010003", true);
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


        [HttpGet]
        public PartialViewResult AgregarMunicipalAsignado()
        {
            return PartialView("_RegistrarNumeroPredio", new NumeracionPredioViewModel()
            {
                Estado = 1,
                ListarTipoDireccion = new BienComunHandler().ListadoTipoDireccion(),
                ListTipoInterior = new BienComunHandler().TipoInterior(),
                ListEstadoInterior = new List<SelectListItem>(),
                ListInscripcionCatastral = new BienComunHandler().ListarInscripcionCatastral()
            });
        
        }

        public PartialViewResult AgregarMunicipalAsignado(NumeracionPredioViewModel model)
        {

            //NumeracionPredioViewModel Direccion = new NumeracionPredioViewModel();
            NumeracionPredioViewModel Direccion = new BienComunHandler().RecuperarMunicipalDirec(model);
            Direccion.Estado = 2;
            Direccion.ListarTipoDireccion = new BienComunHandler().ListadoTipoDireccion();
            Direccion.ListTipoInterior = new BienComunHandler().TipoInterior();
            Direccion.ListEstadoInterior = new BienComunHandler().EstadoInteriorAsignacion(Direccion.Asignacion);
            Direccion.ListEstadoInterior = new List<SelectListItem>();
            Direccion.ListInscripcionCatastral = new BienComunHandler().ListarInscripcionCatastral();
            return PartialView("_RegistrarNumeroPredio", Direccion);
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
   
        [HttpPost]
        public ActionResult GrabarImagen(BienComunViewModel model)
        {
            Nullable<bool> EstadoProceso = new BienComunHandler().GrabarUnidadImagen(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente " });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        [HttpPost]
        public ActionResult CargarImagen(BienComunViewModel model)
        {
            return Json(new { success = true, responseText = "Imagen subida correctamente ", imagen = new BienComunHandler().RecuperarLoteImagen(model) });
            /*byte[] bytes = new BienComunHandler().RecuperarLoteImagen(model);
            if (bytes == null || !bytes.Any())
                return Content("false");
            return File(bytes, "image/png");*/
            //return Json(new { initialPreview = new string[] { "<img src='C:\\\\ARCHIVOS\\REPOSIC\\2018\\JULIO\\MSICAS20180709122321316.PNG' class='file-preview-image' alt='Desert'>" } });
        }

        [HttpPost]
        public ActionResult CargarListasNumeroPredio(BienComunViewModel Unidad, string Asignacion)
        {
            List<SelectListItem> resultado = new BienComunHandler().ListadoLoteVia(Unidad, Asignacion);
            List<SelectListItem> resultadoTipoInterior = new BienComunHandler().TipoInterior();
            List<SelectListItem> resultadoEstadoInterior = new BienComunHandler().EstadoInteriorAsignacion(Asignacion);
            return Json(new { success = true, ListarLoteVia = resultado, ListarTipoInterior = resultadoTipoInterior, ListarEstadoInterior = resultadoEstadoInterior });
        }

        [HttpPost]
        public ActionResult CargarListasInterior()
        {
            List<SelectListItem> resultadoTipoInterior = new BienComunHandler().TipoInterior();
            List<SelectListItem> resultadoEstadoInterior = new BienComunHandler().EstadoInterior();
            return Json(new { success = true, ListarTipoInterior = resultadoTipoInterior, ListarEstadoInterior = resultadoEstadoInterior });
        }

        [HttpPost]
        public ActionResult CargarCuadra(BienComunViewModel Unidad, string concodvia)
        {
            List<SelectListItem> resultadoCuadra = new BienComunHandler().ListadoCuadra(Unidad, concodvia);
            return Json(new { success = true, ListarCuadra = resultadoCuadra });
        }


        [HttpPost]
        public ActionResult CargarLado(BienComunViewModel Unidad, string concodvia, int cuadra)
        {
            List<SelectListItem> resultadoLado = new BienComunHandler().ListadoLado(Unidad, concodvia, cuadra);
            return Json(new { success = true, ListarLado = resultadoLado });
        }

        [HttpPost]
        public ActionResult CargarEdificacion(BienComunViewModel Unidad, string concodvia, int cuadra, string lado)
        {
            List<SelectListItem> resultadoEdificacion = new BienComunHandler().ListadoEdificacion(Unidad, concodvia, cuadra, lado);
            return Json(new { success = true, ListarEdificacion = resultadoEdificacion });
        }

        [HttpPost]
        public ActionResult CargarPuerta(BienComunViewModel Unidad, string concodvia, int cuadra, string lado, string edificacion)
        {
            List<SelectListItem> resultadoPuerta = new BienComunHandler().ListadoPuerta(Unidad, concodvia, cuadra, lado, edificacion);
            return Json(new { success = true, ListarPuerta = resultadoPuerta });
        }

        [HttpPost]
        public ActionResult ListarLadoLote()
        {
            List<SelectListItem> resultado = new BienComunHandler().ListarLadoLoteSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarFuente()
        {
            List<SelectListItem> resultado = new BienComunHandler().ListarFuenteSelect();
            return Json(resultado, "json");
        }

        [HttpPost]
        public ActionResult ListarLadoLindero()
        {
            List<SelectListItem> resultado = new BienComunHandler().ListarLadoLinderoSelect();
            return Json(resultado, "json");
        }

        [HttpPost]
        public ActionResult ListarTipoColindante()
        {
            List<SelectListItem> resultado = new BienComunHandler().ListarTipoColindanteSelect();
            return Json(resultado, "json");
        }

        [HttpPost]
        public ActionResult ListarColindante(SolicitudUnidadViewModel model)
        {
            List<SelectListItem> resultado = new BienComunHandler().ListarColindanteSelect(model);
            return Json(resultado, "json");
        }

        [HttpPost]
        public ActionResult ListarColindanteLote(SolicitudUnidadViewModel model)
        {
            List<SelectListItem> resultado = new BienComunHandler().ListarColindanteLoteSelect(model);
            return Json(resultado, "json");
        }

        [HttpPost]
        public ActionResult ListarColindanteEdificacion(SolicitudUnidadViewModel model)
        {
            List<SelectListItem> resultado = new BienComunHandler().ListarColindanteEdificacionSelect(model);
            return Json(resultado, "json");
        }

        [HttpPost]
        public ActionResult ListarColindanteUnidad(SolicitudUnidadViewModel model)
        {
            List<SelectListItem> resultado = new BienComunHandler().ListarColindanteUnidadSelect(model);
            return Json(resultado, "json");
        }

        [HttpPost]
        public ActionResult ListarFuentesColin()
        {
            List<SelectListItem> resultado = new BienComunHandler().ListarFuentesColinSelect();
            return Json(resultado, "json");
        }

        //[HttpPost]
        //public ActionResult BuscarLoteLinderos(Int32 codUniCat)
        //{
        //    bool resul = false;
        //    List<BienComunLinderosViewModel> resultado = new BienComunHandler().BuscarLoteLinderos(codUniCat);
        //    return Json(new { success = resul, LoteObservacion = resultado });
        //}
        [HttpGet]
        public PartialViewResult AgregarLindero(string id)
        {
            return PartialView("_RegistrarLindero", new BienComunLinderosViewModel()
            {
                ListLado = new BienComunHandler().ListarLadoLinderoSelect(),
                ListTipoColindante = new BienComunHandler().ListarTipoColindanteSelect(),
                CodigoLado = id,
                Estado = "1"
            });
        }
        [HttpPost]
        public PartialViewResult AgregarLindero(BienComunLinderosViewModel model)
        {
            BienComunLinderosViewModel Lindero = new BienComunHandler().RecuperarUnidadLinderoDetalle(model);
            Lindero.Estado = "2";
            return PartialView("_RegistrarLindero", Lindero);
        }

        [HttpPost]
        public JsonResult BuscarLoteLinderos(DataTableAjaxPostModel model, BienComunLinderosViewModel FiltrarDirecMunicipal)
        {

            int totalResultado = 0;
            List<BienComunLinderosViewModel> resultado = new List<BienComunLinderosViewModel>();
            if (FiltrarDirecMunicipal.CodUnidadLindero != null)
            {
                resultado = new BienComunHandler().BuscarLoteLinderos(FiltrarDirecMunicipal);
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
        public ActionResult EliminarLinderoUnidad(BienComunLinderosViewModel model)
        {
            Nullable<bool> EstadoProceso = new BienComunHandler().EliminarLinderoUnidad(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        public JsonResult CargarDetalleColindante(DataTableAjaxPostModel model, BienComunLinderosViewModel FiltrarDirecMunicipal)
        {

            int totalResultado = 0;
            List<BienComunLinderosViewModel> resultado = new List<BienComunLinderosViewModel>();

            resultado = new BienComunHandler().CargarDetalleColindante(FiltrarDirecMunicipal);
            totalResultado = resultado.Count;


            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }
        public ActionResult EliminarDetalleLindero(BienComunLinderosViewModel model)
        {
            Nullable<bool> EstadoProceso = new BienComunHandler().EliminarDetalleLindero(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult GrabarUnidadLinderoDetalle(BienComunLinderosViewModel model)
        {
            var EstadoProceso = new BienComunHandler().GrabarUnidadLinderoDetalle(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente", codigo = EstadoProceso.CODIGO });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
    }
}