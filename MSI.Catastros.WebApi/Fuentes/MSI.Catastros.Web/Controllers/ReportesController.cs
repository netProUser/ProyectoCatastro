using MSI.Catastros.Web.Funcionalidad.HabilitacionUrbana;
using MSI.Catastros.Web.Funcionalidad.ManzanaVia;
using MSI.Catastros.Web.Funcionalidad.RecepcionDocumentos;
using MSI.Catastros.Web.Funcionalidad.Reporte;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    public class ReportesController : Controller
    {
        //
        // GET: /Reportes/
        public ActionResult Index()
        {
            
            return View(new ReporteViewModel
            {
                ListTipoSolicitud = new ReporteHandler().ListadoTipoFiltro(),
            });

        }

        public ActionResult FichaManzana()
        {
            return View("_FichaManzana", new ReporteViewModel()
            {
                ParametroManzana = new ReporteHandler().ParametroManzana("0"),
                ParametroSector = new ManzanaViaHandler().ParametroSector()
            });
        }

        public ActionResult FichaUrbanizacion()
        {
            return View("_FichaUrbana", new ReporteViewModel()
            {
                TipoHabilitacion = new TipoHabilitacionHandler().ListarTipoHabilitacion(new FiltrarTipoHabilitacionViewModel()),
                HabilitacionUrbana = new List<HabilitacionUrbanaViewModel>()
            });
        }

        public ActionResult LoteUC()
        {
            return View("_LoteUC", new ReporteViewModel()
            {
                ListTipoReporte = new ReporteHandler().ListaReportes(),
            });
        }
        public ActionResult ConsultaEstadistica()
        {
            return View("_ConsultaEstadistica", new ReporteViewModel()
            {
                ListTipoReporte = new ReporteHandler().ListaReportes(),
            });
        }


    }
}