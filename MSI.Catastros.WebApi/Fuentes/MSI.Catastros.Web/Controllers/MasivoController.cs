using ClosedXML.Excel;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Masivo;
using MSI.Catastros.Web.Funcionalidad.ProgramarInspeccion;
using MSI.Catastros.Web.Funcionalidad.RecepcionDocumentos;
using MSI.Catastros.Web.Funcionalidad.UnidadCatastral;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [MiAutorizacionAttribute]
    public class MasivoController : Controller
    {
        //
        // GET: /Masivo/
        public ActionResult Index()
        {
            ViewBag.ListadoInscripcionCatastral = new UnidadCatastralHandler().ListarInscripcionCatastral();

            return View(new MasivoViewModel()
            {
                TipoSolicitud = new ProgramarInspeccionHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new RecepcionDocumentosHandler().ListadoTipoDocumento(),
                ListInscripcionCatastral = new UnidadCatastralHandler().ListarInscripcionCatastral()
            });
        }
        [HttpPost]
        public ActionResult ListarMasivos(Configuacion modelo)
        {
            var masivo = new MasivoHandler().ListarMasivo(modelo);

            return Json(new { success = true, data = masivo });
        }

        [HttpPost]
        public FileResult Excel(Configuacion modelo)
        {
            var masivo = new MasivoHandler().Excel(modelo);

            return File(masivo.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", string.Format("{0}{1}{2}{3}", modelo.CODNUMESOLI, modelo.CODNUMESOLI, modelo.CODANOSOLI, ".xlsx"));
        }
        [HttpPost]
        public ActionResult GenerarMasivo(Configuacion modelo)
        {
            Nullable<bool> EstadoProceso = new MasivoHandler().ProcesarMasivo(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        #region Paso 3 -

        [HttpGet]
        public PartialViewResult AgregarMunicipalAsignado()
        {
            return PartialView("_RegistrarNumeroPredio", new NumeracionPredioViewModel()
            {
                Estado = 1,
                ListTipoInterior = new UnidadCatastralHandler().TipoInterior(),
                ListEstadoInterior = new UnidadCatastralHandler().EstadoInterior()
            });
        }
        [HttpGet]
        public JsonResult ListarTipoInterior()
        {
            //var data = new UnidadCatastralHandler().TipoInterior();
            var data = new UnidadCatastralHandler().ListarInscripcionCatastral();            
            return Json( data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Paso 3
        [HttpGet]
        public PartialViewResult AgregarTitular()
        {
            ViewBag.ListVBTipoDocumentoIdentidad = new UnidadCatastralHandler().ListadoTipoDocumentoIdentidad();
            ViewBag.ListVBCondicionPropietario = new UnidadCatastralHandler().CondicionPropiedad();
            return PartialView("_RegistrarTitular");
        }
        #endregion
        #region Paso 4 - Clasificacion Unidad
        [HttpGet]
        public PartialViewResult ClasificacionUnidad()
        {
            return PartialView("_ClasificacionUnidad", new ClasificacionUnidadViewModel()
            {
                ListClasificacionPredio = new UnidadCatastralHandler().ListarClasificacionPredio()
            });
        }

        [HttpPost]
        public ActionResult RegistrarClasificacionUnidad(ClasificacionUnidadViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new MasivoHandler().ProcesarClasifiacion(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        #endregion

        #region Paso 6 - Observacion General

        [HttpGet]
        public PartialViewResult ObservacionGeneral()
        {
            return PartialView("_ObservacionGeneral");
        }
        #endregion
        #region Paso 7 - Linea Constructivas
        [HttpGet]
        public PartialViewResult LineasConstructivas()
        {
            ViewBag.ListVBEstadoConservacion = new UnidadCatastralHandler().ListarEstadoConservacion();
            ViewBag.ListVBMaterialEstructural = new UnidadCatastralHandler().ListadoMaterialEstructural();
            ViewBag.ListVBMes = new UnidadCatastralHandler().ListadoMes();
            return PartialView("_LineasConstructivas");
        }
        #endregion
        #region Paso 8 - Otras Lineas
        [HttpPost]
        public PartialViewResult OtrasInstalaciones(string Id)
        {
            ViewBag.ListVBEstadoConservacion = new UnidadCatastralHandler().ListarEstadoConservacion();
            ViewBag.ListVBMes = new UnidadCatastralHandler().ListadoMes();
            ViewBag.ListVBOtrasInstalaciones = new UnidadCatastralHandler().ListadoOtrasInstalaciones();
            ViewBag.ListVBUnidadMedida = new UnidadCatastralHandler().ListadoUnidadMedida();
            ViewBag.ListVBCodigoOtrasInstalaciones = new UnidadCatastralHandler().ListarCodigoOtrasInstalaciones();
            VariablesWeb.Estatico = "false";
            ViewBag.ListInstalaciones = new UnidadCatastralHandler().RecuperarUnidadListaInstalaciones(Int32.Parse(Id), false);
            return PartialView("_OtrasInstalaciones");
        }
        #endregion
        #region Paso 9 - Observacion Individual
        [HttpPost]
        public PartialViewResult ObservacionIndividual(string Id)
        {
            VariablesWeb.Estatico = "false";
            ViewBag.ListaObservacion = new UnidadCatastralHandler().RecuperarObservacion(Int32.Parse(Id), "010001", false);
            return PartialView("_ObservacionIndividual", new MasivoViewModel() {
            });
        }
        #endregion
        #region Paso 10 - Arrea de Terreno
        [HttpPost]
        public PartialViewResult AreaTerreno(string Id)
        {
            var unidad = new UnidadCatastralHandler().RecuperarUnidad(Int32.Parse(Id));
            return PartialView("_AreaTerreno", new AreaTerreno()
            {
                ListTipoDepartamento = new UnidadCatastralHandler().ListarTipoDepartamentoPredio(),
                ListUsoPredio = new UnidadCatastralHandler().ListarUsoPredio(),
                areaOcupada = unidad.AreaOcupada.ToString(),
                areaComun = unidad.AreaComunesOficial.ToString(),
                CodTipoDepartamento = unidad.CodigoDepartamentoPredio,
                CodUsoPredio = unidad.CodgiUsoPredio
            });
        }
        #endregion
    }
}