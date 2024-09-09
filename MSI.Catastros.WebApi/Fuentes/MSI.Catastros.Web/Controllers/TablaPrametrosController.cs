using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class TablaPrametrosController : Controller
    {
        // GET: TablaPrametros
        public ActionResult Index()
        {
            return View(new FiltrarParametrosViewModel());
        }
        public ActionResult ParametrosList()
        {
            return View("Index", new FiltrarParametrosViewModel()
            {
                listParametros = new ParametrosHandler().ListarParametros("")
            });
        }
    }
}