using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSI.Catastros.Web.Funcionalidad.RegistrarAtencion
{
    public class AtencionViewModel
    {
        [Display(Name = "Codigo Atencion")]
        public string CodigoDistrito { get; set; }
        [Display(Name = "Nombre Atencion")]
        public string NombreAtencion { get; set; }

        [Display(Name = "Nro. Trámite")]
        public string NumeroTramite { get; set; }

        [Display(Name = "Nro. Solicitud")]
        public string NumeroSolicitud { get; set; }

        [Display(Name = "Folios")]
        public string Folios { get; set; }

        [Display(Name = "Tipo Requerimiento")]
        public string TipoRequerimiento { get; set; }

        [Display(Name = "Responsable Actual")]
        public string ResponsableActual { get; set; }

        [Display(Name = "Tipo Procedimiento Actual")]
        public string TipoProcedimientoActual { get; set; }

        [Display(Name = "Fecha Inicio")]
        public string FechaInicio { get; set; }

        [Display(Name = "Fecha Recepcion")]
        public string FechaRecepcion { get; set; }

        [Display(Name = "Fecha Atencion")]
        public string FechaAtencion { get; set; }

        [Display(Name = "Estado Atencion")]
        public string EstadoAtencion { get; set; }

        [Display(Name = "Nuevo Procedimiento")]
        public string NuevoProcedimiento { get; set; }

        [Display(Name = "Observación Remitente")]
        public string ObservacionRemitente { get; set; }

        [Display(Name = "Observacion Recepcion")]
        public string ObservacionRecepcion { get; set; }
    }
    public class ControlCalidadViewModel {

        [Display(Name = "Nro. Revisión")]
        public string NumeroRevision { get; set; }

        [Display(Name = "Fecha Revisión")]
        public string FechaRevision { get; set; }

        [Display(Name = "TipoError")]
        public string TipoError { get; set; }

        [Display(Name = "DescripcionError")]
        public string DescripcionError { get; set; }

        [Display(Name = "Detalle")]
        public string Detalle { get; set; }
    }
}