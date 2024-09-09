using Foolproof;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.Vias;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.ViasAnterior
{
    public class FiltrarViasAnteriorViewModel
    {
        [Display(Name = "Seleccione Vía")]
        public string ParamSelectVia { get; set; }

        [Display(Name = "Distrito")]
        public string ParamDistritoVia { get; set; }

        public IEnumerable<SelectListItem> listVia { get; set; }
    }

    public class RegistroViaAnteriorViewModel : ViaAnteriorViewModel
    {
        [Display(Name = "Distrito")]
        public string Distrito { get; set; }

        public int Estado { get; set; }

    }

    public class ViaAnteriorViewModel : PaginacionViewModel
    {

        [Display(Name = "Vía")]
        [Required(ErrorMessage = "Seleccione una vía")]
        public string CodigoVia { get; set; }

        public string CodigoCorrViaAnte { get; set; }

        [Display(Name = "Vía")]
        public string DescVia { get; set; }

        [Display(Name = "Vía Anterior")]
        [Required(ErrorMessage = "Ingrese la vía Anterior")]
        public string DesViaAnterior { get; set; }

        [Display(Name = "Tipo Vía Anterior")]
        [Required(ErrorMessage = "Ingrese tipo de vía Anterior")]
        public string DesTipoViaAnterior { get; set; }

        [Display(Name = "Normativa")]
        public string Normativa { get; set; }

        [Display(Name = "Desde")]
        [Required(ErrorMessage = "Ingrese fecha de Inicio")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? FechaInicio { get; set; }

        public string txtFechaInicio { get; set; }

        [Display(Name = "Hasta")]
        [Required(ErrorMessage = "Ingrese fecha de Fin")]

        
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [GreaterThan("FechaInicio", ErrorMessage = "La fecha de fin debe ser mayor")]
        public DateTime? FechaFinal { get; set; }

        public string txtFechaFinal { get; set; }

        [Display(Name = "Código de Vía Anterior")]
        public string CodigoViaAnterior { get; set; }

    }
}