using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.RecepcionDocumentos
{
    public class SolicitudSeguimientoViewModel
    {
        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }

        [Display(Name = "Nro. Solicitud")]
        public string NumeroSolicitud { get; set; }

        public string CodigoPeriodoSolicitud { get; set; }

        public string CodigoTipoSolicitud { get; set; }
        public string NombreTipoSolicitud { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public string NombreTipoDocumento { get; set; }
        public string CodigoAreaSolicitante { get; set; }
        public string NombreAreaSolicitante { get; set; }
        public string Asunto { get; set; }
        public int? Folios { get; set; }
        public string FechaRecepcion { get; set; }
        public string PuestoRemitente { get; set; }
        public string PuestoRecepcion { get; set; }
        public int Indice { get; set; }

        public string UsuarioRemitente { get; set; }
        public string UsuarioRecepcion { get; set; }

        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
    }

    public class FiltrarSolicitudSeguimientoViewModel : SolicitudSeguimientoViewModel
    {
        public string CodigoTipoSolicitudReg { get; set; }
        public string NumeroSolicitudReg { get; set; }
        public string EstadoInicial { get; set; }
        public string Periodo { get; set; }
    }
}