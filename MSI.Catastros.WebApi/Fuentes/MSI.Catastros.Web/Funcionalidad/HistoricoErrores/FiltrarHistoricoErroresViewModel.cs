using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.HistoricoErrores
{
    public class FiltrarHistoricoErroresViewModel
    {

        [Display(Name = "Nro. de Trámite Documentario")]
        public string NroTramiteDocumentario { get; set; }
        [Display(Name = "Nro. de Solicitud")]
        public string NroSolicitud { get; set; }
        [Display(Name = "Área Solicitante")]
        public string AreaSolicitante { get; set; }
        [Display(Name = "Estado Atención")]
        public IEnumerable<SelectListItem> EstadoAtencion { get; set; }
        [Display(Name = "Estado Solicitud")]
        public string EstadoSolicitud { get; set; }
        [Display(Name = "Fecha Solicitud")]
        public string FechaSolicitud { get; set; }
        [Display(Name = "Fecha Fin Atención")]
        public string FechaFinAtencion { get; set; }
        [Display(Name = "Tipo Requerimiento")]
        public string TipoRequerimiento { get; set; }
         

    }

}