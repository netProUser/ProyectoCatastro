using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.PrimeraAsignacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class AsignarSolicitudOtrosController : Controller
    {
        // GET: AsignarSolicitudOtros
        public ActionResult Index()
        {
            return View(new FilterAsignarSolicitudOtrosViewModel
            {
                ListTipoSolicitud = new PrimeraAsignacionHandler().ListadoTipoSolicitud(),
                ListAreaSolicitante = new PrimeraAsignacionHandler().ListadoAreaSolicitante(),
                ListAccion = new PrimeraAsignacionHandler().ListadoAcciones(),
                ListAsignarResponsable = new PrimeraAsignacionHandler().ListadoResponsable()
            });
        }
    }
}