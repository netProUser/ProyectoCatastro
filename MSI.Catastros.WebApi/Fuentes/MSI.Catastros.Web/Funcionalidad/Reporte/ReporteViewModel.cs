using MSI.Catastros.Web.Funcionalidad.HabilitacionUrbana;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Reporte
{
    public class ReporteViewModel
    {
        [Display(Name = "Sector")]
        public string CodigoSector { get; set; }

        [Display(Name = "Manzana")]
        public string CodigoManzana{ get; set; }

        [Display(Name = "Tipo Habilitacion")]
        public string CodigoTipoHabilitacion { get; set; }

        [Display(Name = "Habilitacion Urbana")]
        public string CodigoHabilitacionUrbana { get; set; }

        [Display(Name = "Tipo Reporte")]
        public string CodigoTipoReporte { get; set; }
        
        public IEnumerable<SelectListItem> ParametroSector { get; set; }

        public IEnumerable<SelectListItem> ParametroManzana { get; set; }
        public IEnumerable<TipoHabilitacionViewModel> TipoHabilitacion { get; set; }
        public IEnumerable<HabilitacionUrbanaViewModel> HabilitacionUrbana { get; set; }
        public string FiltrarCodigoTipoDocumento { get; set; }




        public IEnumerable<SelectListItem> ListTipoReporte { get; set; }

        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }

    }
}