using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.StatusInspeccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proc = MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class StatusInspeccionController : Controller
    {
        //
        // GET: /StatusInspeccion/
        public ActionResult Index()
        {
            return View(new FilterStatusInspecionViewModel()
            {

            });
        }

        public ActionResult Consultas()
        {
            return View("Index", new FilterStatusInspecionViewModel()
            {

            });
        }

        //
        // GET: /StatusInspeccion/Details/5
        public ActionResult Listar(FilterStatusInspecionViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var data = new FilterStatusInspecionViewModel()
                {
                    ListadoInspecciones = new StatusInspeccionesHandler().ListadoStatusInspecciones(modelo.codTipoBusqueda, modelo.NroSolicitud, modelo.FechaInicio, modelo.FechaFin)
                };
                Session["ListadoInspecciones"] = data.ListadoInspecciones;
                return View("Index", data);
            }
            return View("Index", modelo);
        }

        public ActionResult consultaInspeccion(DataTableAjaxPostModel model ,Inspecciones FiltrarStatusInspeccion)
        {
            int totalResultado = 0;

            FiltrarStatusInspeccion.txtTipoBusqueda = Request.Form.GetValues("FiltrarcodTipoBusqueda").FirstOrDefault();
            FiltrarStatusInspeccion.NroSolicitud = Request.Form.GetValues("FiltrarNroSolicitud").FirstOrDefault();
            FiltrarStatusInspeccion.txtFechaInspeccionInicio = Request.Form.GetValues("FiltrarFechaInicio").FirstOrDefault();
            FiltrarStatusInspeccion.txtFechaInspeccionFin = Request.Form.GetValues("FiltrarFechaFin").FirstOrDefault();
            FiltrarStatusInspeccion.CodCatastral = Request.Form.GetValues("FiltrarCodigoCatastral").FirstOrDefault();


            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal;

            List<Inspecciones> resultado;

            resultado = new StatusInspeccionesHandler().ConsultaStatusInspecciones(draw, start, length, pageSize, skip, model, FiltrarStatusInspeccion, out recordsTotal);
            totalResultado = resultado.Count;

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = resultado });
        }

        /*Matenimiento*/
        [HttpGet]
        public PartialViewResult RegistarClase()
        {
            return PartialView("_ReporteInspeccion");
        }
        public JsonResult GetDiarySummary(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);
            // List<Inspecciones> listInsp = (List<Inspecciones>)Session["ListadoInspecciones"];
            List<Inspecciones> listInsp = new StatusInspeccionesHandler().ListadoStatusInspecciones(3, "", fromDate, toDate);
            //var ApptListForDate = listInsp.Where(s => Convert.ToDateTime(s.FechaInspeccion) >= fromDate && Convert.ToDateTime(s.FechaInspeccion) <= toDate);

            //var ApptListForDate = DiaryEvent.LoadAppointmentSummaryInDateRange(start, end);
            var eventList = from e in listInsp
                            select new
                            {
                                id = e.CodCatastral,
                                title = e.NroInspeccion + " - " + e.EstadoInspeccion + " - " + e.Inspectores,
                                start = Convert.ToDateTime(e.FechaInspeccion).ToString("s"),
                                //end = Convert.ToDateTime(e.FechaInspeccion).ToString("s"),
                                someKey = e.CodCatastral,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDiaryEvents(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);
            //List<Inspecciones> listInsp = (List<Inspecciones>)Session["ListadoInspecciones"];
            List<Inspecciones> listInsp = new StatusInspeccionesHandler().ListadoStatusInspecciones(3, "", fromDate, toDate);
            //var ApptListForDate = listInsp.Where(s => Convert.ToDateTime(s.FechaInspeccion) >= fromDate && Convert.ToDateTime(s.FechaInspeccion) <= toDate);

            //var ApptListForDate = DiaryEvent.LoadAllAppointmentsInDateRange(start, end);
            var eventList = from e in listInsp
                            select new
                            {
                                //id = e.ID,
                                //title = e.Title,
                                //start = e.StartDateString,
                                //end = e.EndDateString,
                                color = e.EstadoInspeccion == "ATENDIDA" ? "rgb(42, 187, 77)" : e.EstadoInspeccion == "PROGRAMADA" && Convert.ToDateTime(e.FechaInspeccion) < DateTime.Now ? "#f71a2e" : "#2572e4",
                                //className = e.EstadoInspeccion == "ATENDIDA" ? "success" : e.EstadoInspeccion == "PROGRAMADA" && Convert.ToDateTime(e.FechaInspeccion) < DateTime.Now ? "warning" : "info",
                                //someKey = e.SomeImportantKeyID,
                                //allDay = false
                                //id = e.CodCatastral,
                               // title = "INSPECCION : " + e.NroInspeccion + " - ESTADO : " + e.EstadoInspeccion,
                                description = "<strong>HORA: </strong>" + e.HoraInspeccion +
                                              "<br/><strong> COD. REF.  CATASTRAL</STRONG><br/>" + e.CodCatastral+
                                              "<br/><strong> N° BOLETA: </STRONG>" + e.NroInspeccion +
                                              "<br/><strong> TITULAR CATASTRAL: </STRONG><br/>" + e.Titular +
                                              "<strong> UBICACIÓN: </STRONG><br/>" + e.Ubicacion +
                                              "<strong> REPRESENTANTE: </STRONG><br/>" + e.Representante +
                                              "<br/><strong> TELEFONO: </STRONG>" + null +
                                              "<br/><strong> INSPECTOR: </STRONG>" + e.Responsable + //////
                                              "<br/><strong> OBSERVACIONES: </STRONG>" + e.Observacion +
                                              "<br/><strong> DOCUMENTO: </STRONG>" + e.MumeroSolicitud +
                                              "<br/><strong> TIPO DE LLENADO: </STRONG>" + e.TipoLlenado +
                                              "<br/><strong> PROGRAMADO: </STRONG>" + e.Programado +
                                              "<br/><strong> FECHA DE CITACION: </STRONG>" + e.txtFechacitacion,

                                start = Convert.ToDateTime(e.FechaInspeccion + " " + e.HoraInspeccion).ToString("s"),
                                end = Convert.ToDateTime(e.FechaInspeccion + " " + e.HoraInspeccion).AddHours(3).ToString("s"),
                                //start = Convert.ToDateTime(e.FechaInspeccion),
                                //end = Convert.ToDateTime(e.FechaInspeccion),
                                someKey = e.CodCatastral,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

    }
    public class DiaryEvent
    {

        public int ID;
        public string Title;
        public int SomeImportantKeyID;
        public string StartDateString;
        public string EndDateString;
        public string StatusString;
        public string StatusColor;
        public string ClassName;

        public static List<DiaryEvent> LoadAppointmentSummaryInDateRange(double start, double end)
        {
            var result = new List<DiaryEvent>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(new DiaryEvent()
                {
                    ID = i,
                    SomeImportantKeyID = i,
                    StartDateString = DateTime.Now.AddDays(i).ToString("s"),
                    EndDateString = DateTime.Now.AddDays(i + 1).ToString("s"),
                    Title = "sdfsdf",
                    StatusString = "sdf",
                    StatusColor = "sdf",
                    ClassName = "sdf",
                });
            }
            return result;
        }
        public static List<DiaryEvent> LoadAllAppointmentsInDateRange(double start, double end)
        {
            List<DiaryEvent> result = new List<DiaryEvent>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(new DiaryEvent()
                {
                    ID = i,
                    SomeImportantKeyID = i,
                    StartDateString = DateTime.Now.AddDays(i).ToString("s"),
                    EndDateString = DateTime.Now.AddDays(i + 1).ToString("s"),
                    Title = "sdfsdf",
                    StatusString = "sdf",
                    StatusColor = "sdf",
                    ClassName = "sdf",
                });
            }
            return result;
        }
    }
}
