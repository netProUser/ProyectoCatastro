using MSI.Catastros.Web.Funcionalidad.Parametros;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Foolproof;

namespace MSI.Catastros.Web.Funcionalidad.Vias
{
    public class FiltrarViasViewModel : PaginacionViewModel
    {
        [Display(Name = "Vía")]
        public string FiltrarNombreVia { get; set; }

        [Display(Name = "Distrito")]
        public string DistritoVia { get; set; }

        [Display(Name = "Tipo Vía")]
        public string FiltrarCodTipoVia { get; set; }

        [Display(Name = "Código Vía Equilavente")]
        public string CodViaEquivalente { get; set; }

        public string CodigoParametro { get; set; }

        public List<ViaViewModel> listVias { get; set; }

        public IEnumerable<ParametrosViewModel> listTipoVias { get; set; }

        public FiltrarViasViewModel()
        {
            listVias = new List<ViaViewModel>();
        }
    }

    public class RegistroViaViewModel: ViaViewModel
    {
        [Display(Name = "Distrito")]
        public string Distrito { get; set; }

        [Display(Name = "Tipo Vía")]
        [Required(ErrorMessage = "Registre tipo de vía")]
        public string CodTipoVia { get; set; }

        [Display(Name = "Convertir Vía Anterior")]
        public bool ConvertirViaAnterior { get; set; }


        [Display(Name = "Tipo Vía Anterior")]
        [RequiredIfTrue("ConvertirViaAnterior", ErrorMessage = "Registre tipo de vía anterior")]
        public string NombreTipoViaAnterior { get; set; }
        
        [Display(Name = "Vía Anterior")]
        [RequiredIfTrue("ConvertirViaAnterior", ErrorMessage = "Registre vía anterior")]
        public string NombreViaAnterior { get; set; }

        [Display(Name = "Normativa")]
        [RequiredIfTrue("ConvertirViaAnterior", ErrorMessage = "Registre normativa")]
        public string Normativa { get; set; }

        public string FechaViaAnterior { get; set; }

        [Display(Name = "Desde")]
        [RequiredIfTrue("ConvertirViaAnterior", ErrorMessage = "Ingrese fecha de Inicio")]
        public DateTime? FechaInicio { get; set; }


        public int Estado { get; set; }

    }

    public class ViaViewModel : PaginacionViewModel
    {
        [Display(Name = "Código Vía")]
        // [Required(ErrorMessage = "Registre código de vía")]
        [StringLength(4, MinimumLength = 4)]
        public string CodigoVia { get; set; }

        [Display(Name = "Vía")]
        [Required(ErrorMessage = "Registre nombre de vía")]
        public string NombreVia { get; set; }

        [Display(Name = "Tipo Vía")]
        public string DesTipoVia { get; set; }

        [Display(Name = "Clasificación de Vía")]
        public string DesClaseVia { get; set; }

        [Display(Name = "Código Vía Equilavente")]
        public string CodViaEquivalente { get; set; }

        [Display(Name = "Clase de Vía")]
        [Required(ErrorMessage = "Registre clase de vía")]
        public string CodClaseVia { get; set; }

        [Display(Name = "Administración de Vía")]
        public string DesAdmVia { get; set; }
    }
}