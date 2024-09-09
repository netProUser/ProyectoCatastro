using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.StatusInspeccion
{
    public class FilterStatusInspecionViewModel
    {
        [Display(Name = "Tipo de Búsqueda")]
        public IEnumerable<SelectListItem> TipoBusqueda { get; set; }
        [Required(ErrorMessage = "Seleccione Tipo de Busqueda")]
        public Int16 codTipoBusqueda { get; set; }
        [Display(Name = "Nro. de Solicitud")]
        public string NroSolicitud { get; set; }

        [Display(Name = "Desde")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaInicio { get; set; }
        [Display(Name = "Hasta")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaFin { get; set; }

        [Display(Name = "Codigo Catastral")]
        public string CodigoCatastral { get; set; }

        public IEnumerable<Inspecciones> ListadoInspecciones { get; set; }
        public FilterStatusInspecionViewModel()
        {
            TipoBusqueda = new List<SelectListItem>() { 
                new SelectListItem{ Value="0", Text="Todos"}, 
                new SelectListItem{ Value="2", Text="Nro. Solicitud"},
                new SelectListItem{ Value="3", Text="Fecha"}  ,
                new SelectListItem{ Value="4", Text="Codigo Catastral"}
            };
            ListadoInspecciones = new List<Inspecciones>();
            //FechaFin = DateTime.Now.Date.AddDays(-1);
            //FechaInicio = DateTime.Now.Date;
        }
    }

    public class Inspecciones
    {
        public Inspecciones()
        {
            //codInspectores = new List<SelectListItem>();
        }

        [Display(Name = "Nro. Inspeccion")]
        public string NroInspeccion { get; set; }
        [Display(Name = "Nro. Solicitud")]
        public string NroSolicitud { get; set; }
        [Display(Name = "Fecha Insp.")]
        public string FechaInspeccion { get; set; }
        [Display(Name = "Hora de Insp.")]
        public string HoraInspeccion { get; set; }
        [Display(Name = "Inspectores")]
        public string Inspectores { get; set; }
        [Display(Name = "Inspector Responsable")]
        public string Responsable { get; set; }

        [Display(Name = "Código Catastral")]
        public string CodCatastral { get; set; }
        [Display(Name = "Estado Inspección")]
        public string EstadoInspeccion { get; set; }

        [Display(Name = "Observacón")]
        public string Observacion { get; set; }

        public string Ubicacion { get; set; }
        public string Titular  { get; set; }
        public string Representante  { get; set; }
        public string TipoLlenado  { get; set; }
        public string MumeroSolicitud   { get; set; }
        public string Programado { get; set; }
        public DateTime? Fechacitacion { get; set; }
        public string txtFechacitacion { get; set; }
        public string txtFechaInspeccionInicio { get; set; }
        public string txtFechaInspeccionFin { get; set; }
        public string txtTipoBusqueda { get; set; }
    }
}