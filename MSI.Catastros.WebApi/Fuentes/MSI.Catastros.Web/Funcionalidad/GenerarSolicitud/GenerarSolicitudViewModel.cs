using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSI.Catastros.Web.Funcionalidad.GenerarSolicitud
{
    public class GenerarSolicitudViewModel
    {
        [Display(Name = "Nro. Solicitud")]
        public string NroSolicitud { get; set; }

        [Display(Name = "Tipo Solicitud")]
        public string TipoSolicitud { get; set; }

        [Display(Name = "Tipo Documento")]
        public string TipoDocumento { get; set; }

        [Display(Name = "Area Solicitud")]
        public string AreaSolicitud { get; set; }

        [Display(Name = "Folios")]
        public string Folios { get; set; }

        [Display(Name = "Asunto")]
        [Required(ErrorMessage = "Registre un asunto")]
        public string Asunto { get; set; }
        public int Estado { get; set; }
    }
}