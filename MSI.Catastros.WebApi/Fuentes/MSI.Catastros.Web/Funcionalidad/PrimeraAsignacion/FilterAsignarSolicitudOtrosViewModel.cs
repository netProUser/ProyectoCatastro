using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.PrimeraAsignacion
{
    public class FilterAsignarSolicitudOtrosViewModel
    {
        [Display(Name = "Número de Trámite")]
        public string NumeroTramite { get; set; }
        [Display(Name = "Número de Solicitud")]
        public string NumeroSolicitud { get; set; }
        [Display(Name = "Folio")]
        public string Folio { get; set; }

        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }
        [Display(Name = "Area Solicitante")]
        public IEnumerable<SelectListItem> ListAreaSolicitante { get; set; }

        [Display(Name = "Asignar a Responsable")]
        public IEnumerable<SelectListItem> ListAsignarResponsable { get; set; }
        [Display(Name = "Puesto Responsable")]
        public string PuestoResponsable { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Remision")]
        public DateTime? FechaRemision { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Recepción")]
        public DateTime? FechaRecepcion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Limite")]
        public DateTime? FechaLimite { get; set; }

        [Display(Name = "Programar Aviso")]
        public bool programarAviso { get; set; }

        [Display(Name = "Acción")]
        public IEnumerable<SelectListItem> ListAccion { get; set; }
        [Display(Name = "Obervacion de Remitente")]
        public string OberservacionRemitente { get; set; }
        [Display(Name = "Observacion de Recepción")]
        public string OberservacionRecepcion { get; set; }
    }
}