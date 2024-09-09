using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using Foolproof;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.HabilitacionUrbana
{
    public class FiltrarHabilitacionUrbanaViewModel
    {
        //[Required(AllowEmptyStrings = true)]
        [Display(Name = "Habilitación urbana")]
        public string NombreHabilitacionUrbana { get; set; }

        [Display(Name = "Codigo habilitacion urbana")]
        public string CodigoHabilitacionUrbana { get; set; }

        [Display(Name = "Tipo de habilitación urbana")]
        public string CodigoTipoHabilitacion { get; set; }

        public IEnumerable<TipoHabilitacionViewModel> TipoHabilitacion { get; set; }

        public IEnumerable<HabilitacionUrbanaViewModel> listHabilitacionUrbana { get; set; }

        public FiltrarHabilitacionUrbanaViewModel()
        {
            listHabilitacionUrbana = new List<HabilitacionUrbanaViewModel>();
        }
    }

    public class RegistroHabilitacionUrbanaViewModel : HabilitacionUrbanaViewModel
    {
        [Display(Name = "Tipo habilitación urbana")]
        [Required]
        public string CodigoTipoHabilitacion { get; set; }

        //[RequiredIfEmpty("NombreDocumento", ErrorMessage = "Es necesario adjuntar un documento pdf")]
        public HttpPostedFileBase archivo { get; set; }

        public int Estado { get; set; }

    }

    public class HabilitacionUrbanaViewModel
    {
        [Display(Name = "Código")]
        public string CodigoHabilitacionUrbana { get; set; }

        [Display(Name = "Habilitación urbana")]
        [Required]
        [StringLength(100)]
        public string NombreHabilitacionUrbana { get; set; }

        [Display(Name = "Codigo tipo habilitacion urbana")]
        public string CodigoTipoHabilitacionUrbana { get; set; }

        [Display(Name = "Nombre tipo habilitacion urbana")]
        public string NombreTipoHabilitacion { get; set; }
        public string NombreDiferenciador { get; set; }
        public string NombreRealDiferenciador { get; set; }
        public string NombreDocumento { get; set; }
        public string NombreDocumentoRandom { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        public string txtFechaAprobacion { get; set; }
        public string NumeroDocumento { get; set; }

        public string Ruta { get; set; }

        public IEnumerable<TipoHabilitacionViewModel> TipoHabilitacion { get; set; }
        public List<SelectListItem> ListDiferenciador { get; set; }
    }

    public class ObservacionViewModel
    {
        public string CodigoHabilitacionUrbana { get; set; }
        public string Detalle { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }
    }

    public class    ImagenHabilitacion
    {
        public string CodigoHabilitacionUrbana { get; set; }
        public string CodigoImagen { get; set; }
        public HttpPostedFileBase Archivo { get; set; }
        public string rutaImagen { get; set; }
    }
}