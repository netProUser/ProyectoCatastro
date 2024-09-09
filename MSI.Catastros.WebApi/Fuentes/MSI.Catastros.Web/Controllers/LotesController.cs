using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Lotes;
using Proc = MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System.Net;
using MSI.Catastros.Web.Decoradores;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class LotesController : Controller
    {
        // GET: Lotes
        public ActionResult Index()
        {
            ViewBag.TipoDocRRPP = new LotesHandler().ListarTipoDocRRPP();
            return View(new FiltrarLotesViewModel
            {
                ListTipoSolicitud = new Proc.ProcedimientoNuevoHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new Proc.ProcedimientoNuevoHandler().ListadoTipoDocumento(),
            });
        }

        public ActionResult Estatico()
        {
            ViewBag.TipoDocRRPP = new LotesHandler().ListarTipoDocRRPP();
            return View("Index",new FiltrarLotesViewModel
            {
                ListTipoSolicitud = new Proc.ProcedimientoNuevoHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new Proc.ProcedimientoNuevoHandler().ListadoTipoDocumento(),
                Estatico = true
            });
        }
        public ActionResult Consultas()
        {
            ViewBag.TipoDocRRPP = new LotesHandler().ListarTipoDocRRPP();
            return View("Index", new FiltrarLotesViewModel
            {
                ListTipoSolicitud = new Proc.ProcedimientoNuevoHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new Proc.ProcedimientoNuevoHandler().ListadoTipoDocumento(),
                Estatico = true,
                Consultas = true
            });
        }

        #region BUSCAR/RECUPERAR TABLA
        [HttpPost]
        public ActionResult BuscarLoteSolicitud(FiltrarLotesViewModel modelo)
        {
            List<LoteSolicitudViewModel> resultado = new LotesHandler().BuscarLoteSolicitud(modelo);
            if (resultado.Count == 0)
            {
                return Json(new { success = false});
            }
            return Json(new { success = true, Lotes = resultado });
        }
        // - Inicial
        [HttpPost]
        public ActionResult BuscarSolicitud(FiltrarLotesViewModel modelo)
        {
            MSI.Catastros.Web.Funcionalidad.Lotes.ProcedimientoNuevoViewModel ProcedimientoNuevo = new LotesHandler().BuscarSolicitudes(modelo);
            if (ProcedimientoNuevo.NumeroSolicitud == null) {
                return Json(new { success = false, ProcedimientoNuevo = "" });
            }
            return Json(new { success = true, ProcedimientoNuevo = ProcedimientoNuevo });
        }
        [HttpPost]
        public ActionResult BuscarSolicitudEstatico(FiltrarLotesViewModel modelo)
        {
            MSI.Catastros.Web.Funcionalidad.Lotes.FiltrarLotes ProcedimientoNuevo = new LotesHandler().BuscarLotes(modelo);
            if (ProcedimientoNuevo.CodigoLote == null)
            {
                return Json(new { success = false, ProcedimientoNuevo = "" });
            }
            return Json(new { success = true, ProcedimientoNuevo = ProcedimientoNuevo });
        }
        [HttpPost]
        public ActionResult BuscarGrabar(SolicitudUnidadViewModel model)
        {
            bool resul = false;
            SolicitudUnidadViewModel resultado = new LotesHandler().RecuperarGrabarLote(model, out resul);
            return Json(new { success = resul, SolicitudUnidad = resultado });
        }
        [HttpPost]
        public ActionResult Recuperar(SolicitudUnidadViewModel model)
        {
            bool resul = false;
            RegistrarLoteViewModel resultado = new LotesHandler().RecuperarLote(model);
            
            return Json(new { success = resul, RegistrarLote = resultado });
        }
        [HttpPost]
        public ActionResult BuscarUnidadNueva(SolicitudUnidadViewModel model)
        {
            string mensaje = "";
            bool resultado = new LotesHandler().RecuperarUnidadNueva(model, out mensaje);
            return Json(new { success = true, Total = resultado, Mensaje = mensaje });
        }
        
        // - FInicial

        // - Tab 2
        [HttpPost]
        public ActionResult BuscarLoteLinderos(SolicitudUnidadViewModel model)
        {
            bool resul = false;
            List<LoteLinderosViewModel> resultado = new LotesHandler().BuscarLoteLinderos(model);
            return Json(new { success = resul, LoteObservacion = resultado });
        }
        // - FTab 2

        // - Tab 4
        [HttpPost]
        public ActionResult RecuperarZonificacion(ZonifManzaViewModel model)
        {
            string resultado = new LotesHandler().RecuperarZonificacion(model);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult RecuperarZonifLote(ZonifLoteViewModel model)
        {
            string resultado = new LotesHandler().RecuperarZonifLote(model);
            return Json(resultado, "json");
        }
        
        [HttpPost]
        public ActionResult BuscarLoteZonificacion(SolicitudUnidadViewModel model)
        {
            bool resul = false;
            List<ZonifLoteViewModel> resultado = new LotesHandler().BuscarLoteZonificacion(model);
            return Json(new { success = resul, LoteZonificacion = resultado });
        }
        // - FTab 4

        // - Tab 5
        [HttpPost]
        public ActionResult RecuperarManzanaMedidas(RegistrarRetiroMunicipalViewModel model)
        {
            ManzanaMediasViewModel resultado = new LotesHandler().RecuperarManzanaMedidas(model);
            return Json(resultado, "json");
        }
        // - FTab 5

        // - Tab 6
        [HttpPost]
        public ActionResult BuscarLoteDocumentosRRPP(SolicitudUnidadViewModel model)
        {
            bool resul = false;
            List<LoteDocumentosRRPPViewModel> resultado = new LotesHandler().BuscarLoteDocumentosRRPP(model);
            return Json(new { success = resul, LoteObservacion = resultado });
        }
        
        [HttpPost]
        public ActionResult BuscarLoteDocumentos(SolicitudUnidadViewModel model)
        {
            bool resul = false;
            List<LoteDocumentosViewModel> resultado = new LotesHandler().BuscarLoteDocumentos(model);
            return Json(new { success = resul, LoteObservacion = resultado });
        }
        // - FTab 6

        // - Tab 7
        [HttpPost]
        public ActionResult BuscarLoteObservacion(SolicitudUnidadViewModel model)
        {
            bool resul = false;
            List<LoteObservacionViewModel> resultado = new LotesHandler().BuscarLoteObservacion(model);
            return Json(new { success = resul, LoteObservacion = resultado });
        }
        // - FTab 7

        #endregion

        #region CARGAR DATATABLES
        [HttpPost]
        public JsonResult CargarHabilitacion(DataTableAjaxPostModel model, SolicitudUnidadViewModel FiltrarHabilitacion)
        {
            
                int totalResultado = 0;
                List<RegistrarHabilitacionViewModel> resultado = new List<RegistrarHabilitacionViewModel>();
                if (FiltrarHabilitacion.CodigoLote != null)
                {
                        resultado = new LotesHandler().CargarHabilitacion(FiltrarHabilitacion);
                        totalResultado = resultado.Count;
                    
                }
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }
        
        [HttpPost]
        public JsonResult CargarLinderos(DataTableAjaxPostModel model, SolicitudUnidadViewModel FiltrarDirecMunicipal)
        {
            
                int totalResultado = 0;
                List<LoteLinderosViewModel> resultado = new List<LoteLinderosViewModel>();
                if (FiltrarDirecMunicipal.CodigoSector != null && FiltrarDirecMunicipal.CodigoManzana != null && FiltrarDirecMunicipal.CodigoLote != null)
                {
                    resultado = new LotesHandler().CargarLinderos(FiltrarDirecMunicipal);
                    totalResultado = resultado.Count;
                }
                foreach (var item in resultado)
                {
                   
                    item.ListaLoteColindantes = string.Empty;
                    foreach (var itemDet in item.ListaColindantes)
                    {
                        item.ListaLoteColindantes += itemDet.Text + " <br/><hr/>";
                    }
                   
                }

            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        public JsonResult DocumentosLote(DataTableAjaxPostModel model, SolicitudUnidadViewModel FiltrarDocumentos)
        {

            int totalResultado = 0;


            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal;


            List<SolicitudUnidadViewModel> resultado;

            resultado = new LotesHandler().DocumentosLote(draw, start, length, pageSize, skip, model, FiltrarDocumentos, out recordsTotal);

            totalResultado = resultado.Count;

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = resultado });
        }

        public JsonResult CargarDetalleColindante(DataTableAjaxPostModel model, SolicitudUnidadViewModel FiltrarDirecMunicipal)
        {

            int totalResultado = 0;
            List<LoteLinderosViewModel> resultado = new List<LoteLinderosViewModel>();
           
                resultado = new LotesHandler().CargarDetalleColindante(FiltrarDirecMunicipal);
                totalResultado = resultado.Count;
            

            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarDirecMunicipal(DataTableAjaxPostModel model, SolicitudUnidadViewModel FiltrarDirecMunicipal)
        {
            
                int totalResultado = 0;
                List<RegistrarDirecMunicipalViewModel> resultado = new List<RegistrarDirecMunicipalViewModel>();
                if (FiltrarDirecMunicipal.CodigoLote != null)
                {
                    resultado = new LotesHandler().CargarDirecMunicipal(FiltrarDirecMunicipal); totalResultado = resultado.Count;
                }
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }
        [HttpPost]
        public JsonResult CargarRetiroMunicipal(DataTableAjaxPostModel model, SolicitudUnidadViewModel FiltrarRetiroMunicipal)
        {
            
                int totalResultado = 0; List<RegistrarRetiroMunicipalViewModel> resultado = new List<RegistrarRetiroMunicipalViewModel>();
                if (FiltrarRetiroMunicipal.CodigoLote != null)
                {
                    resultado = new LotesHandler().CargarRetiroMunicipal(FiltrarRetiroMunicipal);
                    totalResultado = resultado.Count;
                }
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarLoteDocumentosObras(DataTableAjaxPostModel model, SolicitudUnidadViewModel FiltrarObras)
        {
                int totalResultado = 0; List<LicenciaEdificacionViewModel> resultado = new List<LicenciaEdificacionViewModel>();
                if (FiltrarObras.CodigoLote != null) {
                    resultado = new LotesHandler().BuscarLoteDocumentosObras(FiltrarObras);
                    totalResultado = resultado.Count;
                }
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        [HttpPost]
        public JsonResult CargarLoteOtrosDocumentos(DataTableAjaxPostModel model, SolicitudUnidadViewModel FiltrarOtrosDocumentos)
        {
            int totalResultado = 0; List<LicenciaEdificacionViewModel> resultado = new List<LicenciaEdificacionViewModel>();
            if (FiltrarOtrosDocumentos.CodigoLote != null)
            {
                resultado = new LotesHandler().CargarLoteOtrosDocumentos(FiltrarOtrosDocumentos);
                totalResultado = resultado.Count;
            }
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });

        }

        [HttpPost]
        public JsonResult CargarLoteDocumentosLicencias(DataTableAjaxPostModel model, SolicitudUnidadViewModel FiltrarLicencias)
        {

            
                int totalResultado = 0; List<LicenciaViewModel> resultado = new List<LicenciaViewModel>();
                if (FiltrarLicencias.CodigoLote != null)
                {
                    resultado = new LotesHandler().BuscarLoteDocumentosLicencias(FiltrarLicencias);
                    totalResultado = resultado.Count;
                }
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }
        [HttpPost]
        public JsonResult CargarLoteDocumentosInspecciones(DataTableAjaxPostModel model, SolicitudUnidadViewModel FiltrarInspecciones)
        {

            
                int totalResultado = 0;List<InspeccionesViewModel> resultado = new List<InspeccionesViewModel>();
                if (FiltrarInspecciones.CodigoLote != null)
                {
                    resultado = new LotesHandler().BuscarLoteDocumentosInspecciones(FiltrarInspecciones);
                    totalResultado = resultado.Count;
                }
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }
        [HttpPost]
        public JsonResult CargarSolUnidad(DataTableAjaxPostModel model, FiltrarLotesViewModel FiltrarLotes)
        {
            
                int totalResultado = 0;var resultado= new List<SolicitudUnidadViewModel>();
                if (FiltrarLotes.FiltrarNumeroSolicitud != null && FiltrarLotes.FiltrarCodigoTipoSolicitud != null)
                {
                    resultado = new LotesHandler().RecargarTablaSolUnidad(model, FiltrarLotes, out totalResultado);
                }
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }
        [HttpPost]
        public JsonResult CargarSolUnidadEstatico(DataTableAjaxPostModel model, FiltrarLotesViewModel FiltrarLotes)
        {
            
                int totalResultado = 0;var resultado = new List<SolicitudUnidadViewModel>();
                if (FiltrarLotes.FiltrarCodigoSector != null && FiltrarLotes.FiltrarCodigoManzana != null )
                {
                    resultado = new LotesHandler().RecargarTablaLote(model, FiltrarLotes, out totalResultado);
                }
                return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
            
        }

        private object List<T1>()
        {
            throw new NotImplementedException();
        }

        #endregion
        
        #region VENTANAS MODALES

        [HttpGet]
        public PartialViewResult Registrar()
        {
            return PartialView("_Registrar");
        }
        [HttpGet]
        public PartialViewResult RegistrarHabilitacion()
        {
            return PartialView("_RegistrarHabilitacion", new RegistrarHabilitacionViewModel()
            {
                ListTipoHabilitacionUrbana = new TipoHabilitacionHandler().ListarTipoHabilitacionSelect(),
                ListHabilitacionUrbana = new List<SelectListItem>(),
                ListManzanaUrbana = new List<SelectListItem>()
            });
        }
        [HttpPost]
        public PartialViewResult EditarHabilitacion(RegistrarHabilitacionViewModel model)
        {
            RegistrarHabilitacionViewModel Habilitacion = new LotesHandler().RecuperarHabilitacionUrbana(model);
            Habilitacion.ListTipoHabilitacionUrbana = new TipoHabilitacionHandler().ListarTipoHabilitacionSelect();
            Habilitacion.Estado = "2";
            return PartialView("_RegistrarHabilitacion", Habilitacion);
        }
        [HttpGet]
        public PartialViewResult PorcentajeBienComun()
        {
            return PartialView("PorcentajeBienComun");
        }

        [HttpGet]
        public PartialViewResult AgregarLindero(string id)
        {
            return PartialView("_RegistrarLindero", new LoteLinderosViewModel()
            {
                ListLado = new LotesHandler().ListarLadoLinderoSelect(),
                ListFuente = new LotesHandler().ListarFuentesColinSelect(),
                ListTipoColindante = new LotesHandler().ListarTipoColindanteSelect(),
                ListColindante = new List<SelectListItem>(),
                ListAlturaVia = new LotesHandler().ListarParamAlturaVia(),
                CodigoLado = id,
                Estado = "1"
            });
        }
        [HttpPost]
        public PartialViewResult AgregarLindero(LoteLinderosViewModel model)
        {
            LoteLinderosViewModel Lindero = new LotesHandler().RecuperarLoteLindero(model);
            Lindero.Estado = "2";
            return PartialView("_RegistrarLindero", Lindero);
        }
        [HttpGet]
        public PartialViewResult AgregarMunicipalAsignado()
        {
            return PartialView("_RegistrarDirecMunicipal", new RegistrarDirecMunicipalViewModel()
            {
                Estado = "1"
            });
        }
        [HttpGet]
        public PartialViewResult AgregarDocumentoAsignado()
        {
            return PartialView("_RegistrarDocumentosExpediente", new LoteDocumentosViewModel()
            {
                Estado = "1"
            });
        }
        [HttpGet]
        public PartialViewResult AgregarOtrosDocumentoAsignado()
        {
            return PartialView("_RegistrarOtrosDocumentos", new LoteOtrosDocumentosViewModel()
            {
                Estado = "1",
                ListTipoDocumento = new LotesHandler().ListarTipoOtrosDocumentos(),

            });
        }
        [HttpPost]
        public PartialViewResult AgregarOtrosDocumentoAsignado(LoteOtrosDocumentosViewModel model)
        {
            LoteOtrosDocumentosViewModel Lindero = new LotesHandler().AgregarOtrosDocumentoAsignado(model);
            Lindero.Estado = "2";
            return PartialView("_RegistrarOtrosDocumentos", Lindero);
        }
        [HttpGet]
        public PartialViewResult AgregarLoteNuevo()
        {
            return PartialView("_RegistrarLoteNuevo", new RegistrarLoteNuevoViewModel()
            {
                Estado = "1"
            });
        }
        [HttpPost]
        public PartialViewResult AgregarMunicipalAsignado(RegistrarDirecMunicipalViewModel model)
        {
            RegistrarDirecMunicipalViewModel Municipal = new LotesHandler().RecuperarMunicipalDirec(model);
            Municipal.Estado = "2";
            return PartialView("_RegistrarDirecMunicipal", Municipal);
        }

        [HttpGet]
        public PartialViewResult AgregarRetiroMunicipal()
        {
            return PartialView("_RegistrarRetiroMunicipal", new RegistrarRetiroMunicipalViewModel()
            {
                Estado = "1"
            });
        }
        [HttpPost]
        public PartialViewResult AgregarRetiroMunicipal(RegistrarRetiroMunicipalViewModel model)
        {
            RegistrarRetiroMunicipalViewModel Retiro = new LotesHandler().RecuperarRetiro(model);
            Retiro.Estado = "2";
            return PartialView("_RegistrarRetiroMunicipal", Retiro);
        }

        #endregion

        #region GRABAR, ACTUALIZAR Y ELIMINAR TABLAS

        [HttpPost]
        public ActionResult Grabar(RegistrarLoteViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLote(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarImagen(RegistrarLoteViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteImagen(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente " });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        //[HttpPost]
        //public JsonResult CargarUnidad(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltrarUnidadCatastral)
        //{
        
        //        // --Definir variables de búsqueda
        //        FiltrarUnidadCatastral.FiltrarCodigoDistrito = Request.Form.GetValues("FiltrarCodigoDistrito").FirstOrDefault();
        //        FiltrarUnidadCatastral.FiltrarCodigoSector = Request.Form.GetValues("FiltrarCodigoSector").FirstOrDefault();
        //        FiltrarUnidadCatastral.FiltrarCodigoManzana = Request.Form.GetValues("FiltrarCodigoManzana").FirstOrDefault();
        //        FiltrarUnidadCatastral.FiltrarCodigoLote = Request.Form.GetValues("FiltrarCodigoLote").FirstOrDefault();
        //        FiltrarUnidadCatastral.FiltrarEd = Request.Form.GetValues("FiltrarEd").FirstOrDefault();
        //        FiltrarUnidadCatastral.FiltrarEntrada = Request.Form.GetValues("FiltrarEntrada").FirstOrDefault();
        //        FiltrarUnidadCatastral.FiltrarPiso = Request.Form.GetValues("FiltrarPiso").FirstOrDefault();
        //        FiltrarUnidadCatastral.FiltrarUnidad = Request.Form.GetValues("FiltrarUnidad").FirstOrDefault();
        //        int totalResultado;
        //        // --Obtener los resultados enviando información de la pagínacion
        //        var resultado = new List<UnidadCatastralViewModel>();
        //        if (FiltrarUnidadCatastral.FiltrarCodigoDistrito != "" && FiltrarUnidadCatastral.FiltrarCodigoSector != "" &&
        //           FiltrarUnidadCatastral.FiltrarCodigoSector != "" && FiltrarUnidadCatastral.FiltrarCodigoManzana != "" && FiltrarUnidadCatastral.FiltrarCodigoLote != "" &&
        //           FiltrarUnidadCatastral.FiltrarEd != "" && FiltrarUnidadCatastral.FiltrarEntrada != "" && FiltrarUnidadCatastral.FiltrarPiso != "" &&
        //           FiltrarUnidadCatastral.FiltrarUnidad != "")
        //        {
        //            resultado = new LotesHandler().RecargarTablaUnidad(model, FiltrarUnidadCatastral, out totalResultado);
        //            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        //        }
        //        else {
        //            return Json(new { draw = model.draw, recordsTotal = 0, recordsFiltered = 0, data = resultado });
        //        }
        //}
        [HttpPost]
        public ActionResult CargarImagen(RegistrarLoteViewModel model)
        {
            //byte[] bytes = new LotesHandler().RecuperarLoteImagen(model);
            //if (bytes == null || !bytes.Any())
            //    return Content("false");
            //return File(bytes, "image/png");
            return Json(new { success = true, responseText = "Imagen subida correctamente ", imagen = new LotesHandler().RecuperarLoteImagen(model) });
            //return Json(new { initialPreview = new string[] { "<img src='C:\\\\ARCHIVOS\\REPOSIC\\2018\\JULIO\\MSICAS20180709122321316.PNG' class='file-preview-image' alt='Desert'>" } });
        }
        [HttpPost]
        //public ActionResult GrabarLoteLinderos(List<LoteLinderosViewModel> model)
        //{
        //    Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteLinderos(model);
        //    if (EstadoProceso == true)
        //    {
        //        return Json(new { success = true, responseText = "Grabo correctamente" });
        //    }
        //    return Json(new { success = false, responseText = "Error del servidor" });
        //}
        //[HttpPost]
        public ActionResult GrabarLoteNormaUrbana(List<LoteNormaUrbanaViewModel> model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteNormaUrbana(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarLoteLindero(LoteLinderosViewModel model)
        {
            var EstadoProceso = new LotesHandler().GrabarLoteLindero(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente", codigo = EstadoProceso.CODIGO });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarLoteOtrosDocumentos(LoteOtrosDocumentosViewModel model)
        {
            var EstadoProceso = new LotesHandler().GrabarLoteOtrosDocumentos(model);
            if (EstadoProceso.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente", codigo = EstadoProceso.CODIGO });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        public ActionResult GrabarLoteLinderoDetalle(LoteLinderosViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteLinderoDetalle(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarLoteNuevo(List<SolicitudUnidadViewModel> model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteNuevo(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult EliminarLoteTemporal(SolicitudUnidadViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().EliminarLoteTemporal(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        
        [HttpPost]
        public ActionResult GrabarLoteDirecMunicipal(RegistrarDirecMunicipalViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteDirecMunicipal(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarLoteRetiroMunicipal(RegistrarRetiroMunicipalViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteRetiroMunicipal(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "ERROR EN EL REGISTRO NO DEBE SUPERAR EL ANCHO NORMATIVO DE LA VÍA, REVISAR EL RETIRO CAMPO Y/O JARDIN ASILAMIENTO CAMPO REGISTRADO" });
        }
        [HttpPost]
        public ActionResult GrabarLoteDocumentoRRPP(LoteDocumentosRRPPViewModel model)
        {
            string correlativo;
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteDocumentoRRPP(model, out correlativo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = correlativo });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarLoteDocumentoRRPPImagen(LoteDocumentosRRPPViewModel model)
        {
            string correlativo;
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteDocumentoRRPPImagen(model, out correlativo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente", correl = correlativo });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarLoteOtroDocumentoRRPPImagen(LoteOtrosDocumentosViewModel model)
        {
            string correlativo;
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteOtroDocumentoRRPPImagen(model, out correlativo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Imagen subida correctamente", correl = correlativo });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        [HttpGet]
        public ActionResult DescargarLoteDocumentoRRPP(LoteDocumentosRRPPViewModel model)
        {
            byte[] pdfFile;
            string ruta_archivo = new LotesHandler().BuscarRutaDocumentoRRPP(model);
            if (ruta_archivo != null)
            {
                //try
                //{
                //    try
                //    {
                        pdfFile = System.IO.File.ReadAllBytes(ruta_archivo);

                        //pdfFile = GetByteArray();
                        var fileName = ruta_archivo;
                        var fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        fileStream.Write(pdfFile, 0, pdfFile.Length);
                        fileStream.Close();
                        return File(pdfFile, "application/pdf");
                //    }
                //    catch (System.IO.DirectoryNotFoundException ex)
                //    {
                //        Console.WriteLine(ex);
                //        return Content("Se ha encontrado un problema al cargar el archivo");
                //    }
                //}
                //catch (System.IO.FileNotFoundException ex)
                //{
                //    Console.WriteLine(ex);
                //    return Content("Se ha encontrado un problema al cargar el archivo");
                //}
            }
            else {
                return Content("Se ha encontrado un problema al cargar el archivo");
            }
        }
        [HttpGet]
        public ActionResult DescargarOtrosDocumento(LoteOtrosDocumentosViewModel model)
        {
            byte[] pdfFile;
            string ruta_archivo = new LotesHandler().DescargarOtrosDocumento(model);
            if (ruta_archivo != null)
            {

                pdfFile = System.IO.File.ReadAllBytes(ruta_archivo);
                var fileName = ruta_archivo;
                var fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                fileStream.Write(pdfFile, 0, pdfFile.Length);
                fileStream.Close();
                return File(pdfFile, "application/pdf");
            }
            else
            {
                return Content("El PDF no se encuentra cargado CORRECTAMENTE");
            }
        }

        [HttpPost]
        public ActionResult GrabarLoteDocumento(List<LoteDocumentosViewModel> model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteDocumento(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarLoteObras(List<LicenciaEdificacionViewModel> model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteObras(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarLoteLicencias(List<LicenciaViewModel> model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteLicencias(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarLoteObservacion(List<LoteObservacionViewModel> model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarLoteObservacion(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult GrabarZonifLote(List<ZonifLoteViewModel> model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().GrabarZonifLote(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult EliminarHabilitacion(RegistrarHabilitacionViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().EliminarHabilitacion(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult EliminarLindero(LoteLinderosViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().EliminarLindero(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpPost]
        public ActionResult EliminarOtrosDocumentos(LoteOtrosDocumentosViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().EliminarOtrosDocumentos(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        public ActionResult EliminarDetalleLindero(LoteLinderosViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().EliminarDetalleLindero(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult EliminarMunicipalAsignado(RegistrarDirecMunicipalViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().EliminarMunicipalDirec(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        public ActionResult EliminarRetiroMunicipal(RegistrarRetiroMunicipalViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().EliminarRetiroMunicipal(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult RegistrarHabilitacion(RegistrarHabilitacionViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            Nullable<bool> EstadoProceso = new LotesHandler().ProcesarHabilitacion(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        #endregion

        #region LISTAR COMBOS
        [HttpPost]
        public ActionResult ListarNormaUrbana(SolicitudUnidadViewModel model)
        {
            List<LoteNormaUrbanaViewModel> resultado = new LotesHandler().BuscarNormaUrbana(model);
            return Json(resultado, "json");
        }

        [HttpPost]
        public ActionResult ListarViasMuni(SolicitudUnidadViewModel model)
        {
            List<SelectListItem> resultado = new LotesHandler().ListarViasMuniSelect(model);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarViasRetiro(SolicitudUnidadViewModel model)
        {
            List<SelectListItem> resultado = new LotesHandler().ListarViasRetMuniSelect(model);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarColindante(SolicitudUnidadViewModel model)
        {
            List<SelectListItem> resultado = new LotesHandler().ListarColindanteSelect(model);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarColindanteParque(SolicitudUnidadViewModel model)
        {
            List<SelectListItem> resultado = new LotesHandler().ListarColindanteSelect(model);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarColindanteLote(SolicitudUnidadViewModel model)
        {
            List<SelectListItem> resultado = new LotesHandler().ListarColindanteLoteSelect(model);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarParamConfirmacion()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarParamConfirmacionSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarAlturaVia()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarParamAlturaVia();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarTipoLote()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarTipoLoteSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarLadoLote()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarLadoLoteSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarTipoEdificacion()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarTipoEdificacionSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarTipoPuerta()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarTipoPuertaSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarLadoLindero()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarLadoLinderoSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarTipoColindante()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarTipoColindanteSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarFuentesColin()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarFuentesColinSelect();
            return Json(resultado, "json");
        }
        
        [HttpPost]
        public ActionResult ListarTipoDocRRPP()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarTipoDocRRPP();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarFuente()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarFuenteSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarTipoDocumentoRRPP()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarTipoDocumentoRRPPSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarDescripcionRetiro()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarDescripcionRetiroSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarAsignacionRetiro()
        {
            List<SelectListItem> resultado = new LotesHandler().ListarAsignacionRetiroSelect();
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarZonificacion(SolicitudUnidadViewModel model)
        {
            List<SelectListItem> resultado = new LotesHandler().ListarZonificacionSelect(model);
            return Json(resultado, "json");
        }
        [HttpPost]
        public ActionResult ListarZonificacion2(SolicitudUnidadViewModel model)
        {
            List<SelectListItem> resultado = new LotesHandler().ListarZonificacion2Select(model);
            return Json(resultado, "json");
        }
        #endregion
        public ActionResult AgregarDocumentos(SolicitudUnidadViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().AgregarDocumentos(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Se Registro Correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
        public ActionResult EliminarDocumentos(SolicitudUnidadViewModel model)
        {
            Nullable<bool> EstadoProceso = new LotesHandler().EliminarDocumentos(model);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }
    }
}