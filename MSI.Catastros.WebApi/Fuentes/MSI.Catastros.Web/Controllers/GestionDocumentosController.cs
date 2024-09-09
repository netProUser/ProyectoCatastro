using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.RecepcionDocumentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    public class GestionDocumentosController : Controller
    {
        [Authorize]
        [LogActionAttribute]
        [LogExceptionAttribute]

        public ActionResult Index()
        {
            return View(new FiltrarRecepcionDocumentosViewModel
            {
                ListTipoSolicitud = new RecepcionDocumentosHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new RecepcionDocumentosHandler().ListadoTipoDocumento(),
            });
        }

        [HttpPost]
        public ActionResult DocInterno()
        {
            var ListTipoDocumentoInt = new RecepcionDocumentosHandler().ListadoTipoDocumentoInt();
            return Json(ListTipoDocumentoInt, "json");
        }
        [HttpPost]
        public ActionResult DocExterno()
        {
            var ListTipoDocumentoInt = new RecepcionDocumentosHandler().ListadoTipoDocumento();
            return Json(ListTipoDocumentoInt, "json");
        }

        //public ActionResult CargarGrilla(DataTableAjaxPostModel model, FiltrarRecepcionDocumentosViewModel FiltroGestionDocumentos)
        //{
        //    int totalResultado = 0;

        //    FiltroGestionDocumentos.EstadoRecepcion = Request.Form.GetValues("EstadoDocumento").FirstOrDefault();
        //    FiltroGestionDocumentos.CodigoTipoSolicitudReg = Request.Form.GetValues("CodigoTipoSolicitud").FirstOrDefault();
        //    FiltroGestionDocumentos.CodigoTipoDocumentoReg = Request.Form.GetValues("CodigoTipoDocumentoReg").FirstOrDefault();
        //    FiltroGestionDocumentos.NumeroSolicitudReg = Request.Form.GetValues("NumeroSolicitud").FirstOrDefault();
        //    FiltroGestionDocumentos.FechaInicio = Request.Form.GetValues("FecInicio").FirstOrDefault();
        //    FiltroGestionDocumentos.FechaFin = Request.Form.GetValues("FecFin").FirstOrDefault();

        //    //List<RecepcionDocumentosViewModel> resultado;
        //    //    resultado = new RecepcionDocumentosHandler().CargarGrilla(model, FiltroGestionDocumentos);
        //    //    totalResultado = resultado.Count;

        //    //return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        //}
        public ActionResult RecuperarDatosSolicitud(string CodigoPeriodoSolicitud,string CodigoTipoSolicitud, string NumeroSolicitud , string CodigoTipoDocumento)
        {
            bool resul = false;
            RecepcionDocumentosViewModel resultado = new RecepcionDocumentosHandler().RecuperarDatosSolicitud(CodigoPeriodoSolicitud, CodigoTipoSolicitud, NumeroSolicitud, CodigoTipoDocumento, out resul);

            return Json(new
            {
                success = resul,
                resultado = resultado,
            });
        }
        public ActionResult RechazaraDocumentos(FiltrarRecepcionDocumentosViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new RecepcionDocumentosHandler().RechazaraDocumentos(modelo);

            return Json(new { success = true, responseText = "Grabo correctamente" });
           
        }
    }
}
