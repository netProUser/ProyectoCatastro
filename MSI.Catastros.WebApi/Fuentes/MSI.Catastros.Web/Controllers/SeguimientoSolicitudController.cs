using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.RecepcionDocumentos;
using MSI.Catastros.Web.Funcionalidad.SeguimientoSolicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class SeguimientoSolicitudController : Controller
{
    // GET: Seguimiento de Solicitud
    public ActionResult Index()
    {

        return View(new FiltrarSeguimientoSolicitudViewModel
        {
            ListTipoSolicitud = new RecepcionDocumentosHandler().ListadoTipoSolicitud()
            //FechaInicio = DateTime.Now.Date.AddDays(-1),
            //FechaFin = DateTime.Now.Date
        });
    }

    public ActionResult Consultas()
    {
        return View("Index", new FiltrarSeguimientoSolicitudViewModel
        {
            //FechaInicio = DateTime.Now.Date.AddDays(-1),
            //FechaFin = DateTime.Now.Date
        });
    }
    [HttpPost]
    public ActionResult Listar(FiltrarSeguimientoSolicitudViewModel modelo)
    {
        //if (ModelState.IsValid)
        //{
        //return View("Index", new FiltrarSeguimientoSolicitudViewModel()
        //{
        //    ListadoSeguimiento = new SeguimentoSolicitudHandler().ListadoSeguimiento(modelo.codTipoBusqueda, modelo.NroSolicitud, modelo.FechaInicio, modelo.FechaFin)
        //});
        //}
        var data = new FiltrarSeguimientoSolicitudViewModel()
        {
            ListadoSeguimiento = new SeguimentoSolicitudHandler().ListadoSeguimiento(modelo.codTipoBusqueda, modelo.CodigoTipoSolicitud, modelo.NroSolicitud, modelo.FechaInicio, modelo.FechaFin, modelo.Asunto, modelo.Titular)
        };
        return Json(new { success = true, responseText = "Se Encontró resultado", data = data.ListadoSeguimiento });
        //return View("Index", modelo);
    }
    [HttpPost]
    public ActionResult Detalle(FiltrarSeguimientoSolicitudViewModel modelo)
    {
        var data = new SeguimentoSolicitudHandler().DetalleSeguimiento(modelo.NroSolicitud);

        return Json(new { success = true, responseText = "Se Encontró resultado", data = data });
        //return View("Index", modelo);
    }
}
