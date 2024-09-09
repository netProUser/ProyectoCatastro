using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSI.Catastros.Web.Funcionalidad.TipoHabilitacion
{
    public class FiltrarTipoHabilitacionViewModel
    {
        //[Required(AllowEmptyStrings = true)]
        [Display(Name = "Tipo de habilitacion urbana ")]
        public string NombreTipoHabilitacion { get; set; }

        [Display(Name = "Código ")]
        public string CodigoHabilitacion { get; set; }

        [Display(Name = "Código tipo habilitacion")]
        public string CodigoTipoHabilitacion { get; set; }

        public IEnumerable<TipoHabilitacionViewModel> listTipoHabilitacion { get; set; }

        public FiltrarTipoHabilitacionViewModel()
        {
            listTipoHabilitacion = new List<TipoHabilitacionViewModel>();
        }
    }

    public class RegistroTipoHabilitacionViewModel: TipoHabilitacionViewModel
    {
        public int Estado { get; set; }

    }

    public class TipoHabilitacionViewModel
    {
        [Display(Name = "Código")]
        public string CodigoTipoHabilitacion { get; set; }

        [Display(Name = "Tipo de habilitación")]
        [Required(ErrorMessage = "Ingrese el Nombre del Tipo de Habilitación Urb.")]
        [StringLength(30)]
        public string NombreTipoHabilitacion { get; set; }
    }
}