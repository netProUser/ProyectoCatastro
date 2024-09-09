using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Distritos
{
    public class FiltrarDistritosViewModel
    {
        //[Required(AllowEmptyStrings = true)]
        [Display(Name = "Nombre de distrito")]
        public string Distro { get; set; }

        public IEnumerable<DistritoViewModel> listDistritos { get; set; }



        public FiltrarDistritosViewModel()
        {
            listDistritos = new List<DistritoViewModel>();
        }
    }

    public class RegistroDistritoViewModel : DistritoViewModel
    {
        //[Display(Name = "Distrito")]
        //public string NombreDistrito { get; set; }

        [Display(Name = "Departamento")]
        public IEnumerable<SelectListItem> Departamento { get; set; }

        [Display(Name = "Provincia")]
        public IEnumerable<SelectListItem> Provincia { get; set; }

        public int Estado { get; set; }

        public RegistroDistritoViewModel()
        {
            Departamento = new List<SelectListItem>();
            Provincia = new List<SelectListItem>();
        }
    }

    public class DistritoViewModel
    {
        [Display(Name = "Codigo Distrito")]
        public string CodigoDistrito { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe Ingrese el Nombre del Distrito")]
        [Display(Name = "Nombre Distrito")]
        public string NombreDistrio { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe Ingrese la abreviatura del Distrito")]
        [Display(Name = "Abreviatura")]
        public string Abreviatura { get; set; }
    }
}