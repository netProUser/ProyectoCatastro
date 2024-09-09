using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.RecepcionDocumentos;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Filters;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class RecepcionDocumentosController : Controller
    {
        //
        // GET: /RecepcionDocumentos/
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

        // POST: /RecepcionDocumentos/Recepcionar
        [HttpPost]
        public ActionResult Recepcionar(FiltrarRecepcionDocumentosViewModel modelo)
        {
            Nullable<bool> EstadoProceso = new RecepcionDocumentosHandler().ProcesarRecepcionDocumento(modelo);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        // POST: /RecepcionDocumentos/CargarGrid
        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarRecepcionDocumentosViewModel FiltroRecepcionDocumentos)
        {
            int totalResultado;
            FiltroRecepcionDocumentos.NumeroSolicitudReg = Request.Form.GetValues("NumeroSolicitud").FirstOrDefault();
            FiltroRecepcionDocumentos.CodigoTipoSolicitudReg = Request.Form.GetValues("CodigoTipoSolicitud").FirstOrDefault();
            FiltroRecepcionDocumentos.NombreTipoSolicitudReg = Request.Form.GetValues("NombreTipoSolicitudReg").FirstOrDefault();
            FiltroRecepcionDocumentos.CodigoTipoDocumentoReg = Request.Form.GetValues("CodigoTipoDocumentoReg").FirstOrDefault();
            FiltroRecepcionDocumentos.NombreTipoDocumentoReg = Request.Form.GetValues("NombreTipoDocumentoReg").FirstOrDefault();
            FiltroRecepcionDocumentos.Periodo = Request.Form.GetValues("Periodo").FirstOrDefault();
            
            
            List<RecepcionDocumentosViewModel> resultado;
            if(FiltroRecepcionDocumentos.EstadoInicial == "1") {
                resultado = new RecepcionDocumentosHandler().ListarGrid(model, FiltroRecepcionDocumentos, out totalResultado);
            } else {
                resultado = new List<RecepcionDocumentosViewModel>();
                totalResultado = 0;
            }
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }


    }
}
