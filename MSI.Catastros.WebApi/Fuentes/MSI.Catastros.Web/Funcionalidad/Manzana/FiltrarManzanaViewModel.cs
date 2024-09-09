using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Manzana
{
    public class FiltrarManzanaViewModel
    {

        [Display(Name = "Código Sector")]
        public string CodigoSector { get; set; }

        public List<SelectListItem> ListadoSectores { get; set; }

        //[Required(AllowEmptyStrings = true)]
        [Display(Name = "Ingrese Manzana")]
        public string Manzana { get; set; }

        //[Display(Name = "Código Sector")]
        //public string CodigoSector { get; set; }

        [Display(Name = "Distrito")]
        public string DistritoManzana { get; set; }

        [Display(Name = "Departamento")]
        public string Departamento { get; set; }

        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [Display(Name = "Sector")]
        public string NombreSector { get; set; }
        [Display(Name = "Código Manzana")]
        public string CodigoManzana { get; set; }

        [Display(Name = "Manzana")]
        public string NombreManzana { get; set; }

        public List<SelectListItem> ListadoTematica { get; set; }
        [Display(Name = "Temática")]
        public string NombreTematica { get; set; }

        [Display(Name = "Manzana Urbana")]
        public string NombreManzanaUrbana { get; set; }

        public IEnumerable<ManzanaViewModel> listManzana { get; set; }
        public FiltrarManzanaViewModel()
        {
            listManzana = new List<ManzanaViewModel>();
        }
    }

    public class RegistroManzanaViewModel : ManzanaViewModel
    {
        public List<SelectListItem> ListadoSectores { get; set; }

        [Display(Name = "Temática")]
        public List<SelectListItem> ListadoTematica { get; set; }

        /*adicionales*/
        public string codSectorizacion { get; set; }
        [Display(Name = "Código Sectorización")]
        public List<SelectListItem> ListadoSectorizacion { get; set; }
        public string codSubSectorizacion { get; set; }
        [Display(Name = "Código Sub Sectorización")]
        public List<SelectListItem> ListadoSubSectorizacion { get; set; }

        public string codZonificacionSuelo { get; set; }
        [Display(Name = "Código Zonificación de uso de Suelo")]
        public List<SelectListItem> ListadoZonificacionSuelo { get; set; }

        public IEnumerable<Zonificacion> tablaCodZonificacion { get; set; }

        public string codDescripcionZonificacionUso { get; set; }
        [Display(Name = "Descripción Zonificación Uso")]
        public List<SelectListItem> ListadoDescripcionZonificacionUso { get; set; }
        public int Estado { get; set; }

        public RegistroManzanaViewModel()
        {
            ListadoTematica = new List<SelectListItem>() { 
                //new SelectListItem { Text = "Sin Tematica", Value = "00"},
                //new SelectListItem { Text = "El Golf", Value = "02" },
                //new SelectListItem { Text = "El Olivar", Value = "03" },
                //new SelectListItem { Text = "Zona Litigio", Value = "01" }              
            };

            ListadoSectorizacion = new List<SelectListItem>() { 
                new SelectListItem { Text="1", Value="1"},
                new SelectListItem { Text="2", Value="2"},
                new SelectListItem { Text="3", Value="3"},
                new SelectListItem { Text="4", Value="4"},
                new SelectListItem { Text="5", Value="5"}
            };
            ListadoSubSectorizacion = new List<SelectListItem>();
            ListadoZonificacionSuelo = new List<SelectListItem>() { };
            ListadoDescripcionZonificacionUso = new List<SelectListItem>() { };
        }
    }

    public class Zonificacion
    {
        public string CodigoZonicacion { get; set; }
        public string Descripcion { get; set; }
    }

    public class ManzanaViewModel
    {
        [Display(Name = "Código Sector")]
        public string CodigoSector { get; set; }

        [Display(Name = "Distrito")]
        public string Distrito { get; set; }

        [Display(Name = "Departamento")]
        public string Departamento { get; set; }

        [Display(Name = "Provincia")]
        public string Provincia { get; set; }
        [Display(Name = "NombreSector")]
        public string NombreSector { get; set; }
        [Display(Name = "Código Manzana")]

        public string CodigoManzana { get; set; }

        [Required(ErrorMessage = "Ingrese la Manzana")]
        [Display(Name = "Manzana")]

        public string CodigoTematica { get; set; }
        public string NombreManzana { get; set; }
        [Display(Name = "Temática")]
        public string NombreTematica { get; set; }

        //[Required(ErrorMessage = "Ingrese la Manzana Urbana")]
        [Display(Name = "Manzana Urbana")]
        public string NombreManzanaUrbana { get; set; }


        public string SectorizacionVecinal { get; set; }
        public string SubSectorizacionVecinal { get; set; }
        public string ZonificacionUsoSuelo { get; set; }

        public string Ruta { get; set; }

    }

    public class ImagenManzana
    {
        public string NombreManzana { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }

        public string CodigoImagen { get; set; }
        public HttpPostedFileBase ARCHIVO { get; set; }
        public string rutaImagen { get; set; }
    }
}