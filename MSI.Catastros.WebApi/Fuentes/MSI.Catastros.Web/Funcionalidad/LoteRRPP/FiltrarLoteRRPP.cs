using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.LoteRRPP
{
    public class FiltrarLoteRRPP
    {
        [Display(Name = "Nro. Trámite Documentario")]
        public string FiltrarNumeroTramiteDocumentario { get; set; }
        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }
        public string FiltrarCodigoTipoSolicitud { get; set; }

        [Display(Name = "Nro. Solicitud")]
        public string FiltrarNumeroSolicitud { get; set; }
        public string FiltrarCodigoPeriodo { get; set; }
        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }
        public string FiltrarCodigoTipoDocumentoReg { get; set; }
        public string FiltrarReferencia { get; set; }

        public bool Estatico { get; set; }
        public bool Consultas { get; set; }
        public string FiltrarCodigoDistrito { get; set; }
        public string FiltrarCodigoSector { get; set; }
        public string FiltrarCodigoManzana { get; set; }
        public string FiltrarCodigoLote { get; set; }
        public string Bloqueado { get; set; }
    }
}