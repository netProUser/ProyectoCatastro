using MSI.Catastros.Web.Funcionalidad.Parametros;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MSI.Catastros.Web.Funcionalidad.Vias;
using Foolproof;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.DetalleVias
{
    public class FiltrarDetalleViasViewModel
    {
        //[Required(AllowEmptyStrings = true)]
        [Display(Name = "Código Vía")]
        public string ParamCodigoVia { get; set; }

        [Display(Name = "Seleccione Vía")]
        public string ParamSelectVia { get; set; }

        [Display(Name = "Distrito")]
        public string ParamDistritoVia { get; set; }

        [Display(Name = "Cuadra")]
        public string ParamCuadra { get; set; }

        public string CodigoParametro { get; set; }

        public List<DetalleViaViewModel> listDetalleVias { get; set; }

        public IEnumerable<SelectListItem> listVia { get; set; }

        public IEnumerable<ParametrosViewModel> listCuadra { get; set; }

       


        public FiltrarDetalleViasViewModel()
        {
            listDetalleVias = new List<DetalleViaViewModel>();
        }
    }

    public class RegistroDetalleViaViewModel : DetalleViaViewModel
    {
        [Display(Name = "Distrito")]
      


        public string Distrito { get; set; }

        public int Estado { get; set; }

    }

    public class DetalleViaViewModel : PaginacionViewModel
    {
        public string CodigoDetalleVia { get; set; }

        [Display(Name = "Vía")]
        [Required(ErrorMessage = "Seleccione una vía")]
        public string CodigoVia { get; set; }

        [Display(Name = "Vía")]
        public string DescVia { get; set; }

        [Display(Name = "Cuadra")]
        public int? NumCuadra { get; set; }

        [Display(Name = "Ancho de Vía")]
        [Required(ErrorMessage = "Seleccione ancho vía campo")]
        public string CodAnchoVia { get; set; }

        [Display(Name = "Ancho Vía Campo")]
        public string AnchoVia { get; set; }

        [Display(Name = "Medida de Vía")]
        public string txtMedidaViaNormativa { get; set; }

        [Display(Name = "Medida de Vía")]
        public string txtMedidaVia { get; set; }

        [Display(Name = "Medida Vía Normativa")]
        [Required(ErrorMessage = "Ingrese medida vía Normativa")]
        public decimal? MedidaViaNormativa { get; set; }

        [Display(Name = "Ancho Vía Campo")]
        public string DescAnchoVia { get; set; }

        [Display(Name = "Medida Inicial")]
        [Required(ErrorMessage = "Ingrese medida vía")]
        public decimal? MedidaInicial { get; set; }

        [Display(Name = "Medida Final")]
        [RequiredIf("CodAnchoVia", "010002", ErrorMessage = "Ingrese medida final")]
        public decimal? MedidaFinal { get; set; }

    }
}