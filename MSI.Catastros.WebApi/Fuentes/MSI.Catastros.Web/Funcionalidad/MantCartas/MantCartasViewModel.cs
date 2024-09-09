using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.MantCartas
{

    public class CartasConfigViewModel
    {
        [Display(Name = "Tipo de Carta")]
        public IEnumerable<SelectListItem> ListTipoInforme { get; set; }
        [Display(Name = "Codigo Carta")]
        public IEnumerable<SelectListItem> ListCodigoCarta { get; set; }
        public string FiltrarCodigoCarta { get; set; }
        public string FiltrarCodigoCorrelativo { get; set; }
        public string FiltrarCodigoPeriodoInforme { get; set; }
        public string FiltrarCodigoTipoInforme { get; set; }
        public string FiltrarCodigoTipoSolicitud { get; set; }
        [Display(Name = "Nro. Solicitud")]
        public string FiltrarNumeroSolicitud { get; set; }
        public string FiltrarCodigoPeriodo { get; set; }
        public string FiltrarCodigoTipoDocumentoReg { get; set; }

        //Datos Precargados
        #region REPORTE1

        [Display(Name = "TituloGeneral")]
        public string TituloGeneral { get; set; }
        [Display(Name = "CodigoOficina")]
        public string CodigoOficina { get; set; }
        [Display(Name = "Sigla")]
        public string NombreSigla { get; set; }
        [Display(Name = "Nombre del Año")]
        public string NombreAnio { get; set; }

        [Display(Name = "ConfSubtitulo1")]
        public string ConfSubtitulo1 { get; set; }
        [Display(Name = "ConfSubtitulo2")]
        public string ConfSubtitulo2 { get; set; }
        [Display(Name = "ConfSubtitulo3")]
        public string ConfSubtitulo3 { get; set; }
        [Display(Name = "ConfSubtitulo4")]
        public string ConfSubtitulo4 { get; set; }
        [Display(Name = "ConfSubtitulo5")]
        public string ConfSubtitulo5 { get; set; }
        [Display(Name = "ConfSubtitulo6")]
        public string ConfSubtitulo6 { get; set; }
        [Display(Name = "ConfSubtitulo7")]
        public string ConfSubtitulo7 { get; set; }

        [Display(Name = "ConfParrafo1")]
        public string ConfParrafo1 { get; set; }
        [Display(Name = "ConfParrafo2")]
        public string ConfParrafo2 { get; set; }
        [Display(Name = "ConfParrafo3")]
        public string ConfParrafo3 { get; set; }
        [Display(Name = "ConfParrafo4")]
        public string ConfParrafo4 { get; set; }
        [Display(Name = "ConfParrafo5")]
        public string ConfParrafo5 { get; set; }
        [Display(Name = "ConfParrafo6")]
        public string ConfParrafo6 { get; set; }
        [Display(Name = "ConfParrafo7")]
        public string ConfParrafo7 { get; set; }
        [Display(Name = "ConfParrafo8")]
        public string ConfParrafo8 { get; set; }
        [Display(Name = "ConfParrafo9")]
        public string ConfParrafo9 { get; set; }
        [Display(Name = "ConfParrafo10")]
        public string ConfParrafo10 { get; set; }

        [Display(Name = "ConfFirma1")]
        public string ConfFirma1 { get; set; }
        [Display(Name = "ConfFirma2")]
        public string ConfFirma2 { get; set; }
        [Display(Name = "ConfFirma3")]
        public string ConfFirma3 { get; set; }
        [Display(Name = "ConfFirma4")]
        public string ConfFirma4 { get; set; }
        [Display(Name = "ConfFirma5")]
        public string ConfFirma5 { get; set; }
        [Display(Name = "ConfPiePagina")]
        public string ConfPiePagina { get; set; }
        #endregion
        [Display(Name = "Version")]
        public IEnumerable<SelectListItem> ListVersionInforme { get; set; }
        public string FiltrarCodigoVersion { get; set; }
    }

}