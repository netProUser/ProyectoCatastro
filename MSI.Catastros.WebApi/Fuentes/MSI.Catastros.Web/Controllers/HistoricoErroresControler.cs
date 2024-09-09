using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.HistoricoErrores;
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
    public class HistoricoErroresController : Controller
    {
        // GET: HistoricoErrores
        public ActionResult Index()
        {
            return View(new FiltrarHistoricoErroresViewModel
            {
               
                FechaSolicitud = DateTime.Now.ToShortTimeString(),
                FechaFinAtencion = DateTime.Now.ToShortTimeString(),
                 
                 
            });
        }
    }
}