using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using MSI.Catastros.Web.Funcionalidad.HabilitacionUrbana;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.ManzanaUrbana
{
    public class FiltrarManzanaUrbanaViewModel
    {
        //[Required(AllowEmptyStrings = true)]
        [Display(Name = "Tipo de habilitación urbana")]
        public string CodigoTipoHabilitacionReg { get; set; }

        [Display(Name = "Codigo habilitacion urbana")]
        public string CodigoHabilitacionUrbanaReg { get; set; }

        public string CodigoManzanaUrbanaReg { get; set; }

        [Display(Name = "Nombre habilitacion urbana")]
        public string NombreHabilitacionUrbanaReg { get; set; }

        [Display(Name = "Manzana urbana")]
        public string NombreManzanaUrbanaReg { get; set; }

        [Display(Name = "Tipo Manzana Urbana")]
        public IEnumerable<SelectListItem> ListTipoManzanaUrbana { get; set; }
        public string CodigoTipoManzanaUrbanaReg { get; set; }

        public IEnumerable<TipoHabilitacionViewModel> TipoHabilitacionReg { get; set; }

        public IEnumerable<HabilitacionUrbanaViewModel> HabilitacionUrbanaReg { get; set; }

        public IEnumerable<ManzanaUrbanaViewModel> listManzanaUrbana { get; set; }

        public FiltrarManzanaUrbanaViewModel()
        {
            listManzanaUrbana = new List<ManzanaUrbanaViewModel>();
        }
    }

    public class RegistroManzanaUrbanaViewModel : ManzanaUrbanaViewModel
    {
        public int Estado { get; set; }

    }

    public class ManzanaUrbanaViewModel
    {
        [Display(Name = "Codigo manzana urbana")]
        public string CodigoManzanaUrbana { get; set; }

        [Display(Name = "Codigo habilitacion urbana")]
        public string CodigoHabilitacionUrbana { get; set; }

        [Display(Name = "Tipo habilitacion")]
        public string CodigoTipoHabilitacion { get; set; }

        [Display(Name = "Tipo de habilitacion urbana")]
        public string NombreTipoHabilitacion { get; set; }
        public string NombreTipoManzana { get; set; }

        [Display(Name = "Manzana urbana")]
        public string NombreManzanaUrbana { get; set; }

        [Display(Name = "Nombre habilitacion urbana")]
        public string NombreHabilitacionUrbana { get; set; }

        [Display(Name = "Tipo habilitación urbana")]
        public IEnumerable<TipoHabilitacionViewModel> TipoHabilitacion { get; set; }

        [Display(Name = "Habilitación urbana")]
        public IEnumerable<HabilitacionUrbanaViewModel> HabilitacionUrbana { get; set; }
        [Display(Name = "Tipo Manzana Urbana")]
        public IEnumerable<SelectListItem> ListTipoManzanaUrbana { get; set; }
        public string CodigoTipoManzanaUrbana { get; set; }

         
    }
}