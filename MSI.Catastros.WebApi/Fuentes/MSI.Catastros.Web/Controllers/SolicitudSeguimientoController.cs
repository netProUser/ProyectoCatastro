using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.RecepcionDocumentos;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Filters;

namespace MSI.Catastros.Web.Controllers
{
        [Authorize]
        [LogExceptionAttribute]
    public class SolicitudSeguimientoController : Controller
    {
        // GET: SolicitudSeguimiento
        public ActionResult Index()
        {
            return View();
        }

        // POST: /SolicitudSeguimiento/CargarGrid
        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarSolicitudSeguimientoViewModel FiltrarSolicitudSeguimiento)
        {
            int totalResultado;
            FiltrarSolicitudSeguimiento.NumeroSolicitudReg = Request.Form.GetValues("NumeroSolicitud") == null ? null :Request.Form.GetValues("NumeroSolicitud").FirstOrDefault();
            FiltrarSolicitudSeguimiento.CodigoTipoSolicitudReg = Request.Form.GetValues("CodigoTipoSolicitud") == null ? null : Request.Form.GetValues("CodigoTipoSolicitud").FirstOrDefault();
            FiltrarSolicitudSeguimiento.CodigoTipoDocumento = Request.Form.GetValues("CodigoTipoDocumentoReg") == null ? null : Request.Form.GetValues("CodigoTipoDocumentoReg").FirstOrDefault();
            FiltrarSolicitudSeguimiento.Periodo = Request.Form.GetValues("Periodo") == null ? null :Request.Form.GetValues("Periodo").FirstOrDefault();
            List<SolicitudSeguimientoViewModel> resultado;
            if (FiltrarSolicitudSeguimiento.EstadoInicial == "1")
            {
                resultado = new SolicitudSeguimientoHandler().ListarGrid(model, FiltrarSolicitudSeguimiento, out totalResultado);
            }
            else
            {
                resultado = new List<SolicitudSeguimientoViewModel>();
                totalResultado = 0;
            }
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
        public ActionResult ListarDetalleSeguimiento(DataTableAjaxPostModel model, FiltrarSolicitudSeguimientoViewModel FiltrarSolicitudSeguimiento)
        {
            int totalResultado;
            FiltrarSolicitudSeguimiento.NumeroSolicitud = Request.Form.GetValues("NumeroSolicitud") == null ? null : Request.Form.GetValues("NumeroSolicitud").FirstOrDefault();
            FiltrarSolicitudSeguimiento.CodigoTipoSolicitud = Request.Form.GetValues("CodigoTipoSolicitud") == null ? null : Request.Form.GetValues("CodigoTipoSolicitud").FirstOrDefault();
            FiltrarSolicitudSeguimiento.CodigoTipoDocumento = Request.Form.GetValues("CodigoTipoDocumento") == null ? null : Request.Form.GetValues("CodigoTipoDocumento").FirstOrDefault();
            FiltrarSolicitudSeguimiento.CodigoPeriodoSolicitud = Request.Form.GetValues("CodigoPeriodoSolicitud") == null ? null : Request.Form.GetValues("CodigoPeriodoSolicitud").FirstOrDefault();
            List<SolicitudSeguimientoViewModel> resultado;
            if (FiltrarSolicitudSeguimiento.EstadoInicial == "1")
            {
                resultado = new SolicitudSeguimientoHandler().ListarDetalleSeguimiento(model, FiltrarSolicitudSeguimiento, out totalResultado);
            }
            else
            {
                resultado = new List<SolicitudSeguimientoViewModel>();
                totalResultado = 0;
            }
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
    }
}