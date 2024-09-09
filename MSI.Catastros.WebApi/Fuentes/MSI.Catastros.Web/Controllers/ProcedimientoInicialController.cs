using MSI.Catastros.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.ProcedimientoInicial;
using System.Globalization;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class ProcedimientoInicialController : Controller
    {
        // GET: ProcedimientoInicial
        public ActionResult Index()
        {
            return View(new FiltrarProcedimientoInicialViewModel 
            {
                FiltrarListTipoSolicitud = new ProcedimientoInicialHandler().ListadoTipoSolicitud(),
                ListTipoRequerimiento = new ProcedimientoInicialHandler().ListadoTipoRequerimiento(),
                ListTipoProcedimiento = new ProcedimientoInicialHandler().ListadoTipoProcedimiento(),
                ListAsignarReponsable = new List<SelectListItem>(),
                ListTipoLlenado = new ProcedimientoInicialHandler().ListadoTipoLlenado(),
                ListTipoAccion = new ProcedimientoInicialHandler().ListadoTipoAccion(),
                FiltrarListTipoDocumento = new ProcedimientoInicialHandler().ListadoTipoDocumento()
            });
        }

        [HttpPost]
        public ActionResult AsignarResponsable(string idProc, string idEstAteAnte)
        {
            List<SelectListItem> listaResponsable = new ProcedimientoInicialHandler().ListadoAsignarResponsable(idProc, idEstAteAnte);
            return Json(listaResponsable, "json");
        }

        [HttpPost]
        public ActionResult ListarProcedimiento(string idEstAteAnte)
        {
            List<SelectListItem> listaProcedimiento = new ProcedimientoInicialHandler().ListadoTipoProcedimiento(idEstAteAnte);
            return Json(listaProcedimiento, "json");
        }

        [HttpPost]
        public ActionResult CargoResponsable(string Usuario)
        {
            BE.SIC_TABPROCE TABPROCE = new ProcedimientoInicialHandler().ObtenerCargo(Usuario);
            return Json(new { cargo = TABPROCE.TXTDECCARG, cod_cargo = TABPROCE.CODCARCATE }, "json");
        }

        [HttpPost]
        public ActionResult EliminarSolUnidad(SolicitudUnidadViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new ProcedimientoInicialHandler().EliminarSolUnidadCatastral(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult TipoLlenadoDias(string IdTipLlen, string fechasoli)
        {
            BE.SIC_TIPOLLENA entQuery = new ProcedimientoInicialHandler().ObtenerTipoLlenadoDias(IdTipLlen);
            DateTime fecha = Convert.ToDateTime(fechasoli, new CultureInfo("es-ES"));

            int diasTotal = entQuery.NUMTIEDIAS.ToString() == "" ? 0 : Convert.ToInt32(entQuery.NUMTIEDIAS);
            string fechaLimite = new ProcedimientoInicialHandler().ObtenerFechaLimite(fecha, diasTotal);
            //string fechaLimite = fecha.AddDays(diasTotal).ToString("dd/MM/yyyy");

            int diasProgIns = entQuery.NUMTPROGINSPE.ToString() == "" ? 0 : Convert.ToInt32(entQuery.NUMTPROGINSPE);
            string fechaProgIns = new ProcedimientoInicialHandler().ObtenerFechaLimite(fecha, diasProgIns);
            //string fechaProgIns = fecha.AddDays(diasProgIns).ToString("dd/MM/yyyy");

            fecha = Convert.ToDateTime(fechaProgIns, new CultureInfo("es-ES"));
            int diasProcIns = entQuery.NUMTPROCINSPE.ToString() == "" ? 0 : Convert.ToInt32(entQuery.NUMTPROCINSPE);
            string fechaProcIns = new ProcedimientoInicialHandler().ObtenerFechaLimite(fecha, diasProcIns);
            //string fechaProcIns = fecha.AddDays(diasProcIns).ToString("dd/MM/yyyy");

            fecha = Convert.ToDateTime(fechaProcIns, new CultureInfo("es-ES"));
            int diasProcAct = entQuery.NUMTPROAC.ToString() == "" ? 0 : Convert.ToInt32(entQuery.NUMTPROAC);
            string fechaProcAct = new ProcedimientoInicialHandler().ObtenerFechaLimite(fecha, diasProcAct);
            //string fechaProcAct = fecha.AddDays(diasProcAct).ToString("dd/MM/yyyy");

            fecha = Convert.ToDateTime(fechaProcAct, new CultureInfo("es-ES"));
            int diasAnalista = entQuery.NUMTPROAF.ToString() == "" ? 0 : Convert.ToInt32(entQuery.NUMTPROAF);
            string fechaAnalista = new ProcedimientoInicialHandler().ObtenerFechaLimite(fecha, diasAnalista);
            //string fechaAnalista = fecha.AddDays(diasAnalista).ToString("dd/MM/yyyy");

            return Json(new { fechaLimite = fechaLimite, fechaProgIns = fechaProgIns, fechaProcIns = fechaProcIns, fechaProcAct = fechaProcAct, fechaAnalista = fechaAnalista });
        }

        [HttpGet]
        // GET: /ProcedimientoInicial/DetalleProcedimiento
        public PartialViewResult DetalleProcedimiento()
        {
            return PartialView("_DetalleProcedimiento");
        }

        [HttpPost]
        public ActionResult BuscarSolicitud(FiltrarProcedimientoInicialViewModel modelo)
        {
            ProcedimientoInicialViewModel ProcedimientoInicial = new ProcedimientoInicialHandler().BuscarPrimeraAsignacion(modelo);
            List<SelectListItem> listaProcedimiento = new ProcedimientoInicialHandler().ListadoTipoProcedimiento(ProcedimientoInicial.CodigoEstadoPrevio);
            if (ProcedimientoInicial.NumeroSolicitud == null)
            {
                return Json(new { success = false, responseText = "No se han encontrado solicitudes derivadas", ProcedimientoInicial = ProcedimientoInicial });
            }
            return Json(new { success = true, ProcedimientoInicial = ProcedimientoInicial, listaProcedimiento = listaProcedimiento });
        }

        [HttpPost]
        public ActionResult DerivarProcedimiento(ProcedimientoInicialViewModel ProcedimientoInicial, string[] checkSelect, string tipoInsAct, string Detalle1, string Detalle2, string Detalle3, string Otros1, string Otros2, List<UnidadCatastralViewModel> arrayCodigoUc)
        {
            ProcedimientoInicial.Estado = 1;



            BE.SIC_RETORNO entSIC_RETORNO = new ProcedimientoInicialHandler().ProcesarProcedimientoInicial(ProcedimientoInicial);

            

            if (entSIC_RETORNO.Ok == true && checkSelect != null)
            {
                for (int i = 0; i < checkSelect.Length; i++)
                {
                    SoliInspeActViewModel SolInspeAct = new SoliInspeActViewModel();
                    SolInspeAct.CodigoNumeroSolicitud = ProcedimientoInicial.NumeroSolicitud;
                    SolInspeAct.codigoTipoDocumento = ProcedimientoInicial.CodigoTipoDocumento;
                    SolInspeAct.anoSolicitud = ProcedimientoInicial.anosolicitud;
                    SolInspeAct.codigoTipoSolicitud = ProcedimientoInicial.CodigoTipoSolicitud;
                    SolInspeAct.codIndDet = tipoInsAct.Substring(0, 1); ;
                    SolInspeAct.codTipoInsp = checkSelect[i].Substring(3, 2);
                    SolInspeAct.CodCorrSeguimiento = "0003";
                    SolInspeAct.CodTipInspe = checkSelect[i].Substring(5, 6);

                    if (SolInspeAct.CodTipInspe.Equals("010001") ||SolInspeAct.CodTipInspe.Equals("010003")){
                        SolInspeAct.textDetTipIns = Detalle1;
                    }
                    else if (SolInspeAct.CodTipInspe.Equals("010002") || SolInspeAct.CodTipInspe.Equals("010004")) {
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

                    Nullable<bool> EstadoProceso2 = new ProcedimientoInicialHandler().ProcesarInpeccionActualizacion(SolInspeAct);
                }
            }

            return Json(new { success = true, CodigoValidaion = entSIC_RETORNO.CODIGO });
        }


        [HttpPost]
        public JsonResult CargarSolUnidad(DataTableAjaxPostModel model, FiltrarProcedimientoInicialViewModel FiltrarProcedimientoNuevo)
        {
            
                // --Definir variables de búsqueda
                FiltrarProcedimientoNuevo.CodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
                FiltrarProcedimientoNuevo.NumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
                FiltrarProcedimientoNuevo.CodigoTipoDocumento = Request.Form.GetValues("FiltrarCodigoTipoDocumentoReg").FirstOrDefault();
                int totalResultado;
                // --Obtener los resultados enviando información de la pagínacion
                var resultado = new ProcedimientoInicialHandler().RecargarTablaSolUnidad(model, FiltrarProcedimientoNuevo, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public ActionResult AgregarSolUnidad(List<SolicitudUnidadViewModel> ListaUnidad, string CodigoPeriodo, string CodigoTipoSolicitud, string CodigoNumeroSolicitud, string CodigoTipoDocumento)
        {
            string Mensaje = "";
            BE.SIC_RETORNO entSIC_RETORNO;
            foreach (SolicitudUnidadViewModel SolicitudUnidad in ListaUnidad)
            {
                SolicitudUnidad.CodigoPeriodo = CodigoPeriodo;
                SolicitudUnidad.CodigoTipoSolicitud = CodigoTipoSolicitud;
                SolicitudUnidad.CodigoNumeroSolicitud = CodigoNumeroSolicitud;
                SolicitudUnidad.CodigoTipoDocumento = CodigoTipoDocumento;
                entSIC_RETORNO = new ProcedimientoInicialHandler().AgregarSolUnidadCatastral(SolicitudUnidad);

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
                                            + SolicitudUnidad.Unidad + "   -   Se encuentra asociada a la solicitud " + entSIC_RETORNO.MENSAJE  + /*"-" + SolicitudUnidad.CodigoPeriodo + */ " <br>";
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
        public JsonResult CargarUnidad(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltrarUnidadCatastral)
        {
            
                // --Definir variables de búsqueda
                
                FiltrarUnidadCatastral.FiltrarCodigoDistrito = Request.Form.GetValues("FiltrarCodigoDistrito").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarCodigoSector = Request.Form.GetValues("FiltrarCodigoSector").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarCodigoManzana = Request.Form.GetValues("FiltrarCodigoManzana").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarCodigoLote = Request.Form.GetValues("FiltrarCodigoLote").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarEd = Request.Form.GetValues("FiltrarEd").FirstOrDefault();
                var prueba = Request.Form.GetValues("NumcuadraReg").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarEntrada = Request.Form.GetValues("FiltrarEntrada").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarPiso = Request.Form.GetValues("FiltrarPiso").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarUnidad = Request.Form.GetValues("FiltrarUnidad").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarTipoBusqueda = Request.Form.GetValues("TipoBusqueda").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarCodigoVia = Request.Form.GetValues("CodigoVia").FirstOrDefault();
                FiltrarUnidadCatastral.FiltrarNumeroCuadra =  Request.Form.GetValues("NumcuadraReg").FirstOrDefault() == "" ? 0 : Convert.ToInt32(Request.Form.GetValues("NumcuadraReg").FirstOrDefault());
                FiltrarUnidadCatastral.FiltrarNumeroPuerta = Request.Form.GetValues("NumeroPuerta").FirstOrDefault();



                if (FiltrarUnidadCatastral.FiltrarTipoBusqueda.Equals("1") && FiltrarUnidadCatastral.FiltrarCodigoVia.Trim().Equals("") && FiltrarUnidadCatastral.FiltrarNumeroCuadra == 0)
                {
                    List<UnidadCatastralViewModel> ListaNula = new List<UnidadCatastralViewModel>();
                    return Json(new { draw = model.draw, recordsTotal = 0, recordsFiltered = 0, data = ListaNula });
                }
                else
                {
                    // --Obtener los resultados enviando información de la pagínacion
                    int totalResultado;
                    var resultado = new ProcedimientoInicialHandler().RecargarTablaUnidad(model, FiltrarUnidadCatastral, out totalResultado);
                    return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
                }
            

        }
        [HttpPost]
        public JsonResult CargarUnidadBC(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltrarUnidadCatastral)
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
            FiltrarUnidadCatastral.FiltrarTipoBusqueda = Request.Form.GetValues("TipoBusqueda").FirstOrDefault();



            if (FiltrarUnidadCatastral.FiltrarTipoBusqueda.Equals("3"))
            {
                List<UnidadCatastralViewModel> ListaNula = new List<UnidadCatastralViewModel>();
                return Json(new { draw = model.draw, recordsTotal = 0, recordsFiltered = 0, data = ListaNula });
            }
            else
            {
                // --Obtener los resultados enviando información de la pagínacion
                int totalResultado;
                var resultado = new ProcedimientoInicialHandler().RecargarTablaUnidadBC(model, FiltrarUnidadCatastral, out totalResultado);
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            }


        }

        [HttpPost]
        public ActionResult CargarCheck()
        {
            List<BE.SIC_TIPOPROCINSPACT> ListTipoInspeccionExt = new List<BE.SIC_TIPOPROCINSPACT>();
            List<BE.SIC_TIPOPROCINSPACT> ListTipoInspeccionInt = new List<BE.SIC_TIPOPROCINSPACT>();
            List<BE.SIC_TIPOPROCINSPACT> ListTipoActualizacionInfLit = new List<BE.SIC_TIPOPROCINSPACT>();
            List<BE.SIC_TIPOPROCINSPACT> ListTipoActualizacionInfGra = new List<BE.SIC_TIPOPROCINSPACT>();
            List<BE.SIC_TIPOPROCINSPACT> ListTipoActualizacionEscan= new List<BE.SIC_TIPOPROCINSPACT>();
            ListTipoInspeccionExt = new ProcedimientoInicialHandler().ListadoTipoInsAct("010001");
            ListTipoInspeccionInt = new ProcedimientoInicialHandler().ListadoTipoInsAct("010002");
            ListTipoActualizacionInfLit = new ProcedimientoInicialHandler().ListadoTipoInsAct("010003");
            ListTipoActualizacionInfGra = new ProcedimientoInicialHandler().ListadoTipoInsAct("010004");
            ListTipoActualizacionEscan = new ProcedimientoInicialHandler().ListadoTipoInsAct("010005");
            return Json(new { success = true, ListTipoInspeccionExt = ListTipoInspeccionExt, ListTipoInspeccionInt = ListTipoInspeccionInt, 
                ListTipoActualizacionInfLit = ListTipoActualizacionInfLit, ListTipoActualizacionInfGra = ListTipoActualizacionInfGra, 
                ListTipoActualizacionEscan = ListTipoActualizacionEscan });
        }

        [HttpGet]
        public PartialViewResult RegistrarUnidad()
        {
            ViewBag.listVias = new ProcedimientoInicialHandler().ListarVias();
            return PartialView("_RegistrarUnidad", new FiltrarUnidadCatastralViewModel()
            {
                Estado = 1,
                ParametroCuadra = new ProcedimientoInicialHandler().ParametroCuadra("0"),
            });
        }
    }
}