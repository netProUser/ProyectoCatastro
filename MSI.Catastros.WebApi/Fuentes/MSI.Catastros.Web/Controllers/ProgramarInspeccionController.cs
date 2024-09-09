using MSI.Catastros.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.ProgramarInspeccion;
using MSI.Catastros.Web.Funcionalidad.RecepcionDocumentos;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class ProgramarInspeccionController : Controller
    {
        // GET: ProgramarInspeccion
        public ActionResult Index()
        {
            return View(new FiltrarProgramarInspeccionViewModel
            {
                TipoSolicitud = new ProgramarInspeccionHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new RecepcionDocumentosHandler().ListadoTipoDocumento()
            });
        }

        [HttpPost]
        public ActionResult BuscarSolicitud(FiltrarProgramarInspeccionViewModel modelo)
        {
            if (string.IsNullOrEmpty(modelo.Estado))
            {
                Session["DataTemp"] = null;
                Session["DataTempSoli"] = null;
            }
            FiltrarProgramarInspeccionViewModel ProcedimientoNuevo = new ProgramarInspeccionHandler().BuscarSolicitud(modelo);
            Session["DataTempSoli"] = ProcedimientoNuevo;
            if (ProcedimientoNuevo.ListCatastral != null)
            {
                return Json(new { success = true, ProcedimientoNuevo = ProcedimientoNuevo });
            }
            else
            {
                return Json(new { success = false, ProcedimientoNuevo = ProcedimientoNuevo });
            }

        }
        [HttpGet]
        public PartialViewResult RegistrarInspeccion()
        {
            return PartialView("_RegistrarInspeccion", new RegistrarInspeccion()
            {
                //ListadoInspectores = new ProgramarInspeccionHandler().ListadoInspectores()
            });
        }

        [HttpPost]
        public ActionResult AgregarInspeccion(RegistrarInspeccion modelo)
        {
            List<RegistrarInspeccion> ListProInspeccion;
            if (Session["DataTemp"] != null)
            {
                ListProInspeccion = (List<RegistrarInspeccion>)Session["DataTemp"];
            }
            else
            {
                ListProInspeccion = new List<RegistrarInspeccion>();
            }
            if (!string.IsNullOrEmpty(modelo.temCodInspeccion))
            {
                foreach (var item in ListProInspeccion)
                {
                    if (modelo.temCodInspeccion == item.NroInspeccion)
                    {
                        item.EstadoInspeccion = "REPROGRAMADA";
                    }
                }
            }
            modelo.NroInspeccion = "TEMP_" + DateTime.Now.ToString("MMddHHmmssf");//Guid.NewGuid().ToString();
            modelo.EstadoInspeccion = "PROGRAMADA";
            ListProInspeccion.Add(modelo);
            RegistrarInspeccion query = new RegistrarInspeccion();
            Session["DataTemp"] = ListProInspeccion;
            return Json(new { success = true, responseText = "Se agregó la inspección", ProcedimientoNuevo = query });
        }

        [HttpPost]
        public ActionResult ListarInspecciones()
        {
            List<RegistrarInspeccion> ListProInspeccion;
            if (Session["DataTemp"] != null)
            {
                ListProInspeccion = (List<RegistrarInspeccion>)Session["DataTemp"];
            }
            else
            {
                if (Session["DataTempSoli"] != null)
                {
                    ListProInspeccion = new ProgramarInspeccionHandler().ListadoInsecciones((FiltrarProgramarInspeccionViewModel)Session["DataTempSoli"]);
                }
                else ListProInspeccion = new List<RegistrarInspeccion>();

                if (ListProInspeccion.Count() > 0)
                {
                    Session["DataTemp"] = ListProInspeccion;
                }
            }

            foreach (var item in ListProInspeccion)
            {
                if (item.Index == "")
                {
                    item.Index = "#";
                }
                item.Inspectores = string.Empty;
                foreach (var itemDet in item.codInspectores)
                {
                    item.Inspectores += itemDet.Text + " <br/><hr/>";
                }
                item.Responsable = string.Empty;
                foreach (var itemDet in item.codResponsable)
                {
                    item.Responsable += itemDet.Text + " <br/>";
                }
            }
            return Json(new { success = true, responseText = "", data = ListProInspeccion });
        }

        [HttpPost]
        public ActionResult EliminarInspeccion(string id)
        {
            RegistrarInspeccion query = new RegistrarInspeccion();
            if (Session["DataTemp"] != null)
            {
                List<RegistrarInspeccion> ListProInspeccion = (List<RegistrarInspeccion>)Session["DataTemp"];
                string codigo = ""; ;
                foreach (var item in ListProInspeccion)
                {
                    if (!string.IsNullOrEmpty(item.temCodInspeccion))
                    {
                        codigo = item.temCodInspeccion;
                    }
                }
                foreach (var item in ListProInspeccion)
                {
                    if (item.NroInspeccion == codigo)
                    {
                        item.EstadoInspeccion = "PROGRAMADA";
                    }
                }
                var data = ListProInspeccion.Single(r => r.NroInspeccion == id);
                ListProInspeccion.Remove(data);
                Session["DataTemp"] = ListProInspeccion;
            }
            return Json(new { success = true, responseText = "Se Eliminó correctamente", ProcedimientoNuevo = query });
        }

        [HttpPost]
        public ActionResult ListarInspectores(string fecha)
        {
            var data = new ProgramarInspeccionHandler().ListadoInspectores(fecha);
            return Json(new { success = true, responseText = "", data = data });
        }
        [HttpPost]
        public ActionResult RegistrarInspeccion(FiltrarProgramarInspeccionViewModel modelo)
        {
            FiltrarProgramarInspeccionViewModel data = (FiltrarProgramarInspeccionViewModel)Session["DataTempSoli"];
            data.Representante = modelo.Representante;
            data.Solicitante = modelo.Solicitante;
            data.FechaLimite = modelo.FechaLimite;
            data.FechaLimiProgInspec = modelo.FechaLimiProgInspec;
            data.FechaLimiteInspeccion = modelo.FechaLimiteInspeccion;
            data.TelefonoInspeccion = modelo.TelefonoInspeccion;
            data.Ubicacion = modelo.Ubicacion;





            ///data.CodigoTipoDocumentoReg = modelo.CodigoTipoDocumentoReg;
            List<RegistrarInspeccion> listInpescon = (List<RegistrarInspeccion>)Session["DataTemp"];

            Nullable<bool> EstadoProceso = new ProgramarInspeccionHandler().ProcesarInspeccion(data, listInpescon);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        public ActionResult ProcesarAtencion(string id, string idProceso)
        {
            Session["DataTemp"] = null;
            FiltrarProgramarInspeccionViewModel entQuery = (FiltrarProgramarInspeccionViewModel)Session["DataTempSoli"];
            entQuery.NroInspeccion = id;
            entQuery.EstadoAtencion = idProceso;
            Nullable<bool> EstadoProceso = new ProgramarInspeccionHandler().ProcesoAtencion(entQuery);
            if (EstadoProceso == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

    }
}