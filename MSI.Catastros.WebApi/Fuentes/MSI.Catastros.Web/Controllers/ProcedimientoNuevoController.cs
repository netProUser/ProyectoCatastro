using MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo;
using MSI.Catastros.Web.Funcionalidad.ProgramarInspeccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.Script.Serialization;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Filters;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class ProcedimientoNuevoController : Controller
    {
        // GET: ProcedimientoNuevo
        public ActionResult Index()
        {
            return View(new FiltrarProcedimientoNuevoViewModel
            {
                ListTipoSolicitud = new ProcedimientoNuevoHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new ProcedimientoNuevoHandler().ListadoTipoDocumento(),
                ListTipoDocumentoInt = new ProcedimientoNuevoHandler().ListadoTipoDocumento()
            });
        }
        [HttpGet]
        public PartialViewResult RegistrarUnidad()
        {
            ViewBag.listVias = new ProcedimientoNuevoHandler().ListarVias();
            return PartialView("_RegistrarUnidad", new FiltrarUnidadCatastralViewModel()
            {
                Estado = 1,
                ParametroCuadra = new ProcedimientoNuevoHandler().ParametroCuadra("0"),
            });
        }
        [HttpGet]
        public PartialViewResult RegistrarSolicitarProcedimiento(String id)
        {
            return PartialView("_SolicitarProcedimiento", new FiltrarSolicitarProcedimientoViewModel()
            {
                ListTipoProcedimiento = new ProcedimientoNuevoHandler().ListadoTipoProcedimiento(id),
                ListTipoRequerimiento = new ProcedimientoNuevoHandler().ListadoTipoRequerimiento(),
                ListAsignarResponsable = new ProcedimientoNuevoHandler().ListadoResponsable(id),
                ListTipoLlenado = new ProcedimientoNuevoHandler().ListadoTipoLlenado(),
                ListAccion = new ProcedimientoNuevoHandler().ListadoAcciones(),
            });
        }
        [HttpPost]
        public ActionResult CargarReponsables(string Estado, string TipoProcedimiento, string CodigoTipoSolicitud, string NumeroSolicitud, string CodigoPeriodo)
        {
            List<SelectListItem> cargo = new ProcedimientoNuevoHandler().ObtenerResponsables(Estado, TipoProcedimiento, CodigoTipoSolicitud, NumeroSolicitud, CodigoPeriodo);
            return Json(cargo, "json");
        }

        [HttpPost]
        public ActionResult DescripcionError(string tipoerror)
        {
            List<SelectListItem> resultado = new ProcedimientoNuevoHandler().ListaTipoError(tipoerror);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListaTipoErrorDigitacion()
        {
            List<SelectListItem> resultado = new ProcedimientoNuevoHandler().ListaTipoErrorDigitacion();
            return Json(resultado, "json");
        }

        [HttpPost]
        public ActionResult EstadoActual(string Estado, string Usuario, string Tipproced)
        {
            EstadoActualViewModel resultado = new ProcedimientoNuevoHandler().ObtenerEstado(Estado, Usuario, Tipproced);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult AsignarResponsable(string idProc)
        {
            List<SelectListItem> listaResponsable = new ProcedimientoNuevoHandler().ListadoAsignarResponsableFijo(idProc,"", "");
            return Json(listaResponsable, "json");
        }

        [HttpPost]
        public ActionResult UsuarioResponsableError(RegistroErroresViewModel RegistroError)
        {
            var srcUsuario = new ProcedimientoNuevoHandler().ObtenerUsuarioResponsable(RegistroError);
            return Json(srcUsuario, "json");
        }


        [HttpPost]
        public ActionResult AgregarSolUnidad(List<SolicitudUnidadViewModel> ListaUnidad, string CodigoPeriodo, string CodigoTipoSolicitud, string CodigoNumeroSolicitud, string CodigoTipoDocumento)
        {
            Nullable<bool> EstadoProceso = false;
            string Mensaje = "";
            BE.SIC_RETORNO entSIC_RETORNO;
            foreach (SolicitudUnidadViewModel SolicitudUnidad in ListaUnidad)
            {
                SolicitudUnidad.CodigoPeriodo = CodigoPeriodo;
                SolicitudUnidad.CodigoTipoSolicitud = CodigoTipoSolicitud;
                SolicitudUnidad.CodigoNumeroSolicitud = CodigoNumeroSolicitud;
                SolicitudUnidad.CodigoTipoDocumento = CodigoTipoDocumento;
                entSIC_RETORNO = new ProcedimientoNuevoHandler().AgregarSolUnidadCatastral(SolicitudUnidad);

                if (entSIC_RETORNO.NoMENSAJE == 0)
                {
                    Mensaje = Mensaje + "La unidad: " + SolicitudUnidad.CodigoDistrito + "-"
                                            + SolicitudUnidad.CodigoSector + "-"
                                            + SolicitudUnidad.CodigoManzana + "-"
                                            + SolicitudUnidad.CodigoLote + "-"
                                            + SolicitudUnidad.Ed + "-"
                                            + SolicitudUnidad.Entrada + "-"
                                            + SolicitudUnidad.Piso + "-"
                                            + SolicitudUnidad.Unidad + "   -   Grabo correctamente <br>";
                }
                else if (entSIC_RETORNO.NoMENSAJE == 20003)
                {
                    Mensaje = Mensaje + "La unidad: " + SolicitudUnidad.CodigoDistrito + "-"
                                            + SolicitudUnidad.CodigoSector + "-"
                                            + SolicitudUnidad.CodigoManzana + "-"
                                            + SolicitudUnidad.CodigoLote + "-"
                                            + SolicitudUnidad.Ed + "-"
                                            + SolicitudUnidad.Entrada + "-"
                                            + SolicitudUnidad.Piso + "-"
                                            + SolicitudUnidad.Unidad + "   -   Se encuentra asociada a la solicitud " + entSIC_RETORNO.MENSAJE + /*"-" + SolicitudUnidad.CodigoPeriodo + */ " <br>";
                }
                else
                {
                    Mensaje = Mensaje + "La unidad: " + SolicitudUnidad.CodigoDistrito + "-"
                                            + SolicitudUnidad.CodigoSector + "-"
                                            + SolicitudUnidad.CodigoManzana + "-"
                                            + SolicitudUnidad.CodigoLote + "-"
                                            + SolicitudUnidad.Ed + "-"
                                            + SolicitudUnidad.Entrada + "-"
                                            + SolicitudUnidad.Piso + "-"
                                            + SolicitudUnidad.Unidad + "   -   No Guardo <br>";
                }

            }


            return Json(new { success = true, responseText = Mensaje });
        }
        [HttpPost]
        public ActionResult CargarTipoLLenado( string CodigoPeriodo, string CodigoTipoSolicitud, string CodigoNumeroSolicitud)
        {
            string CodigoTipoLlenado = new ProcedimientoNuevoHandler().CargarTipoLlenado(new SolicitudUnidadViewModel() { CodigoPeriodo = CodigoPeriodo, CodigoTipoSolicitud = CodigoTipoSolicitud, CodigoNumeroSolicitud = CodigoNumeroSolicitud });
            if (CodigoTipoLlenado != null) {
                return Json(new { success = true, responseText = CodigoTipoLlenado });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult AgregarErrores(RegistroErroresViewModel[] data) 
        {
            Nullable<bool> EstadoProceso = new ProcedimientoNuevoHandler().AgregarRegistroErrores(data);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Agregado correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult EditarErrores(RegistroErroresViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new ProcedimientoNuevoHandler().EditarRegistroErrores(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Agregado correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpGet]
        public PartialViewResult EditarInspecciones(string CodigoTipoSolicitud, string NumeroSolicitud, string CodigoPeriodo, string NumeroInspec)
        {
            RegistrarInspeccion RegistrarInspeccion = new ProcedimientoNuevoHandler().BuscarInspeciones(CodigoTipoSolicitud, NumeroSolicitud, CodigoPeriodo, NumeroInspec);
            return PartialView("_RegistrarInspeccion", RegistrarInspeccion);

        }
        [HttpGet]
        public PartialViewResult EditarProcedimientoInicial(string CodigoTipoSolicitud, string NumeroSolicitud, string CodigoPeriodo, string CodigoCorrelativo)
        {
            ProcedimientoInicialViewModel PrcedimientoInicial = new ProcedimientoNuevoHandler().BuscarProcedimientoInicial(CodigoTipoSolicitud, NumeroSolicitud, CodigoPeriodo, CodigoCorrelativo);
            return PartialView("_ProcedimientoInicial", PrcedimientoInicial);

        }
        [HttpPost]
        public ActionResult EditarProcedimientoInicial(ProcedimientoInicialViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new ProcedimientoNuevoHandler().ProcesarProcedimientoInicial(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpGet]
        public PartialViewResult EditarProcedimientoNuevo(string CodigoTipoSolicitud, string NumeroSolicitud, string CodigoPeriodo, string CodigoCorrelativo)
        {
            FiltrarSolicitarProcedimientoViewModel ProcedimientoNuevo = new ProcedimientoNuevoHandler().BuscarProcedimientoNuevo(CodigoTipoSolicitud, NumeroSolicitud, CodigoPeriodo, CodigoCorrelativo);
            return PartialView("_SolicitarProcedimiento", ProcedimientoNuevo);

        }
        

        [HttpPost]
        public ActionResult EliminarSolUnidad(SolicitudUnidadViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new ProcedimientoNuevoHandler().EliminarSolUnidadCatastral(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult EliminarRegistroError(FiltrarRegistroErroresViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new ProcedimientoNuevoHandler().EliminarRegistroError(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        


        [HttpPost]
        public JsonResult CargarUnidad(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltrarUnidadCatastral)
        {
            
                // --Definir variables de búsqueda
                FiltrarUnidadCatastral.FiltrarCodigoDistrito = Request.Form.GetValues("FiltrarCodigoDistrito").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarCodigoSector = Request.Form.GetValues("FiltrarCodigoSector").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarCodigoManzana = Request.Form.GetValues("FiltrarCodigoManzana").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarCodigoLote = Request.Form.GetValues("FiltrarCodigoLote").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarEd = Request.Form.GetValues("FiltrarEd").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarEntrada = Request.Form.GetValues("FiltrarEntrada").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarPiso = Request.Form.GetValues("FiltrarPiso").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarUnidad = Request.Form.GetValues("FiltrarUnidad").FirstOrDefault();
                int totalResultado;
                // --Obtener los resultados enviando información de la pagínacion
                var resultado = new ProcedimientoNuevoHandler().RecargarTablaUnidad(model, FiltrarUnidadCatastral, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            

        }

        
        [HttpPost]
        public JsonResult CargarInspecciones(DataTableAjaxPostModel model, InspeccionesViewModel Inspecciones)
        {
            
                // --Definir variables de búsqueda
                Inspecciones.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
                Inspecciones.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
                int totalResultado;
                // --Obtener los resultados enviando información de la pagínacion
                var resultado = new ProcedimientoNuevoHandler().RecargarTablaInspecciones(model, Inspecciones, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarErroresRegistro(DataTableAjaxPostModel model, FiltrarRegistroErroresViewModel Errores)
        {
            
                // --Definir variables de búsqueda
                Errores.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
                Errores.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
                Errores.FiltrarCodigoPeriodo = Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
                int totalResultado;
                // --Obtener los resultados enviando información de la pagínacion
                var resultado = new ProcedimientoNuevoHandler().RecargarTablaRegistroErrores(model, Errores, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarSolUnidad(DataTableAjaxPostModel model, FiltrarProcedimientoNuevoViewModel FiltrarProcedimientoNuevo)
        {
            
                // --Definir variables de búsqueda
                FiltrarProcedimientoNuevo.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
                FiltrarProcedimientoNuevo.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
                FiltrarProcedimientoNuevo.FiltrarCodigoPeriodo = Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
                FiltrarProcedimientoNuevo.FiltrarCodigoTipoDocumentoReg = Request.Form.GetValues("FiltrarCodigoTipoDocumentoReg").FirstOrDefault();
                int totalResultado;
                // --Obtener los resultados enviando información de la pagínacion
                var resultado = new ProcedimientoNuevoHandler().RecargarTablaSolUnidad(model, FiltrarProcedimientoNuevo, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarProcedimientoInicial(DataTableAjaxPostModel model, FiltrarProcedimientoInicialViewModel FiltrarProcedimientoInicial)
        {
            
                // --Definir variables de búsqueda
                FiltrarProcedimientoInicial.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
                FiltrarProcedimientoInicial.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
                FiltrarProcedimientoInicial.FiltrarCodigoPeriodo = Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
                int totalResultado;
                // --Obtener los resultados enviando información de la pagínacion
                var resultado = new ProcedimientoNuevoHandler().RecargarTablaProcedimientoInicial(model, FiltrarProcedimientoInicial, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarProcedimientoNuevo(DataTableAjaxPostModel model, FiltrarProcedimientoNuevoViewModel FiltrarProcedimientoNuevo)
        {
            
                // --Definir variables de búsqueda
                FiltrarProcedimientoNuevo.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
                FiltrarProcedimientoNuevo.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
                FiltrarProcedimientoNuevo.FiltrarCodigoPeriodo = Request.Form.GetValues("FiltrarCodigoPeriodo").FirstOrDefault();
                FiltrarProcedimientoNuevo.CodigoActividad = Request.Form.GetValues("cantReg").FirstOrDefault();
                int totalResultado;
                // --Obtener los resultados enviando información de la pagínacion
                var resultado = new ProcedimientoNuevoHandler().RecargarTablaProcedimientoNuevo(model, FiltrarProcedimientoNuevo, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }
        [HttpPost]
        public JsonResult CargarProcedimientoNuevoSegui(DataTableAjaxPostModel model, FiltrarProcedimientoNuevoViewModel FiltrarProcedimientoNuevo)
        {

            int totalResultado;
            // --Obtener los resultados enviando información de la pagínacion
            var resultado = new ProcedimientoNuevoHandler().RecargarTablaProcedimientoNuevoSegui(model, FiltrarProcedimientoNuevo, out totalResultado);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public ActionResult BuscarSolicitud(FiltrarProcedimientoNuevoViewModel modelo)
        {
            // 000022
            ProcedimientoNuevoViewModel ProcedimientoNuevo = new ProcedimientoNuevoHandler().BuscarSolicitudProcedimiento(modelo);
            if (ProcedimientoNuevo.DatosEncontrados == false)
            {
                return Json(new { success = false, ProcedimientoNuevo = ProcedimientoNuevo });
            }
            else 
            {
                return Json(new { success = true, ProcedimientoNuevo = ProcedimientoNuevo });
            }
            
            //return PartialView("_Registrar", PrimeraAsignacion);
        }
        [HttpPost]
        public ActionResult RegistrarProcedimientoNuevo(ProcedimientoNuevoViewModel ProcedimientoNuevo)
        {
            string CodigoCorrelativo;
            Nullable<bool> EstadoProceso = new ProcedimientoNuevoHandler().ProcesarProcedimientoNuevo(ProcedimientoNuevo, out CodigoCorrelativo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        public ActionResult GenerarFichasHistoricas(ProcedimientoNuevoViewModel ProcedimientoNuevo)
        {
            List<UnidadHistoricaViewModel> ListaUnidadHistorica = new List<UnidadHistoricaViewModel>();
            Nullable<bool> EstadoProceso = new ProcedimientoNuevoHandler().ProcesarUnidadHistoricoPDF(ProcedimientoNuevo, out ListaUnidadHistorica);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, ListaUnidadHistorica = ListaUnidadHistorica });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        [HttpPost]
        public ActionResult RegistrarProcedimientoNuevoAdicional(ProcedimientoNuevoViewModel ProcedimientoNuevo, string[] checkSelect, string tipoInsAct, string Detalle1, string Detalle2, string Detalle3, string Otros1, string Otros2)
        {
            string CodigoCorrelativo;
            Nullable<bool> EstadoProceso = new ProcedimientoNuevoHandler().ProcesarProcedimientoNuevo(ProcedimientoNuevo,out CodigoCorrelativo);
            if (EstadoProceso == true && checkSelect != null)
            {
                for (int i = 0; i < checkSelect.Length; i++)
                {
                    SoliInspeActViewModel SolInspeAct = new SoliInspeActViewModel();
                    SolInspeAct.CodigoNumeroSolicitud = ProcedimientoNuevo.NumeroSolicitud;
                    SolInspeAct.codigoTipoDocumento = ProcedimientoNuevo.CodigoTipoDocumento;
                    SolInspeAct.anoSolicitud = ProcedimientoNuevo.Periodo;
                    SolInspeAct.codigoTipoSolicitud = ProcedimientoNuevo.CodigoTipoSolicitud;
                    SolInspeAct.codIndDet = tipoInsAct.Substring(0, 1); ;
                    SolInspeAct.codTipoInsp = checkSelect[i].Substring(3, 2);
                    SolInspeAct.CodCorrSeguimiento = CodigoCorrelativo;
                    SolInspeAct.CodTipInspe = checkSelect[i].Substring(5, 6);
                    if (SolInspeAct.CodTipInspe.Equals("010001") || SolInspeAct.CodTipInspe.Equals("010003"))
                    {
                        SolInspeAct.textDetTipIns = Detalle1;
                    }
                    else if (SolInspeAct.CodTipInspe.Equals("010002") || SolInspeAct.CodTipInspe.Equals("010004"))
                    {
                        SolInspeAct.textDetTipIns = Detalle2;
                    }
                    else if (SolInspeAct.CodTipInspe.Equals("010005"))
                    {
                        SolInspeAct.textDetTipIns = Detalle3;
                    }
                    if (checkSelect[i].Substring(3, 8).Equals("12010002") || checkSelect[i].Substring(3, 8).Equals("07010004"))
                    {
                        SolInspeAct.textoDetalle = Otros1;
                    }
                    if (checkSelect[i].Substring(3, 8).Equals("13010005"))
                    {
                        SolInspeAct.textoDetalle = Otros2;
                    }
                    Nullable<bool> EstadoProceso2 = new ProcedimientoNuevoHandler().ProcesarInpeccionActualizacion(SolInspeAct);
                }
            }
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
    }
}