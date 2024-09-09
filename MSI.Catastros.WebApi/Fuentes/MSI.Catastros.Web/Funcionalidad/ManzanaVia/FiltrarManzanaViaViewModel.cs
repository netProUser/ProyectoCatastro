using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.ManzanaVia
{
    public class FiltrarManzanaViaViewModel
    {
        //[Required(AllowEmptyStrings = true)]
        [Display(Name = "Cod. Sect.")]
        public string CodigoSector { get; set; }

        [Display(Name = "Distrito")]
        public string DistritoManzanaVia { get; set; }

        [Display(Name = "Departamento")]
        public string Departamento { get; set; }

        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [Display(Name = "Sector")]
        public string NombreSector { get; set; }

        [Display(Name = "Cod. Mz.")]
        public string CodigoManzana { get; set; }

        [Display(Name = "Manzana")]
        public string NombreManzana { get; set; }
        public string NombreManzanaReg { get; set; }
        public List<SelectListItem> ListadoSectores { get; set; }

        [Display(Name = "Vía")]
        public string CodigoVia { get; set; }

        [Display(Name = "Nombre via")]
        public string NombreVia { get; set; }

        [Display(Name = "Cod. manzana via")]
        public string CodigoManzanaVia { get; set; }

        [Display(Name = "Nombre manzana via")]
        public string NombreManzanaVia { get; set; }

        [Display(Name = "Cuadra")]
        public Nullable<int> Numcuadra { get; set; }
        [Display(Name = "Lado")]
        public string Posicionlado { get; set; }
        [Display(Name = "Valorización")]
        public Nullable<decimal> Valorizacion { get; set; }

        public IEnumerable<SelectListItem> ParametroVia { get; set; }

        public IEnumerable<ManzanaViaViewModel> listManzanaVia { get; set; }


        public FiltrarManzanaViaViewModel()
        {
            listManzanaVia = new List<ManzanaViaViewModel>();
        }
    }

    public class RegistroManzanaViaViewModel
    {
        [Display(Name = "Cod. manzana via")]
        public string CodigoManzanaViaReg { get; set; }
        [Display(Name = "Código Sector")]
        public string CodigoSectorReg { get; set; }
        [Display(Name = "Código Manzana")]
        public string CodigoManzanaReg { get; set; }
        [Display(Name = "Vía")]
        public string CodigoViaReg { get; set; }
        [Display(Name = "Cuadra")]
        public Nullable<int> NumcuadraReg { get; set; }
        [Display(Name = "Lado")]
        public string PosicionladoReg { get; set; }
        public IEnumerable<SelectListItem> ListAlturaVia { get; set; }
        public string CodigoAlturaVia { get; set; }
        public string NombreladoReg { get; set; }
        [Display(Name = "Valorización")]
        public Nullable<decimal> ValorizacionReg { get; set; }
        [Display(Name = "Altura Norm.")]
        public Decimal? AlturaNormativaReg { get; set; }
        public string AlturaNormativa { get; set; }
        [Display(Name = "Observación")]
        public string ObservacionNormativaReg { get; set; }
        [Display(Name = "Retiro Oficial")]
        public decimal? RetiroOficialReg { get; set; }

        [Display(Name = "Jardin Oficial")]
        public decimal? JardinOficialReg { get; set; }

        public string codZonificacionSuelo { get; set; }
        [Display(Name = "Código Zonificación de uso de Suelo")]
        public List<SelectListItem> ListadoZonificacionSuelo { get; set; }

        public IEnumerable<Zonificacion> tablaCodZonificacion { get; set; }

        public string codDescripcionZonificacionUso { get; set; }
        [Display(Name = "Descripción Zonificación Uso")]
        public List<SelectListItem> ListadoDescripcionZonificacionUso { get; set; }

        public IEnumerable<SelectListItem> ParametroSector { get; set; }

        public IEnumerable<SelectListItem> ParametroManzana { get; set; }

        public IEnumerable<SelectListItem> ParametroVia { get; set; }

        public IEnumerable<SelectListItem> ParametroCuadra { get; set; }

        public IEnumerable<SelectListItem> ParametroLado { get; set; }
        //[Display(Name = "Código Sector")]
        //public string CodigoSector { get; set; }
        [Display(Name = "Departamento")]
        public string Departamento { get; set; }
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }
        //[Display(Name = "Sector")]
        public string NombreSectorReg { get; set; }
        public string NombreManzanaReg { get; set; }
        //[Display(Name = "Código Manzana")]
        //public string CodigoManzana { get; set; }
        //[Display(Name = "Código Vía")]
        //public string Codigovia { get; set; }
        //[Display(Name = "Vía")]
        public string NombreViaReg { get; set; }
        //[Display(Name = "Cuadra")]
        //public Nullable<int> Numcuadra { get; set; }
        //[Display(Name = "Lado")]
        //public string Posicionlado { get; set; }
        //[Display(Name = "Valorización")]
        //public string Nombrevalorizacion { get; set; }
        [Display(Name = "Distrito")]
        public string Distrito { get; set; }
        public int Estado { get; set; }
        [Display(Name = "Año")]
        public String PeriodoReg { get; set; }

        // [Display(Name = "Departamento")]
        // public string Departamento { get; set; }

    }
    public class Zonificacion
    {
        public string CodigoZonicacion { get; set; }
        public string Descripcion { get; set; }
    }

    public class ManzanaViaViewModel
    {

        public string CODCORRMANZVIA { get; set; }

        public IEnumerable<SelectListItem> ParametroSector { get; set; }

        public IEnumerable<SelectListItem> ParametroManzana { get; set; }

        public IEnumerable<SelectListItem> ParametroVia { get; set; }

        public IEnumerable<SelectListItem> ParametroCuadra { get; set; }

        public IEnumerable<SelectListItem> ParametroLado { get; set; }

        [Display(Name = "Sector")]
        [Required]
        public string CodigoSector { get; set; }

        [Display(Name = "Nombre Sector")]
        public string NombreSector { get; set; }

        [Display(Name = "Manzana")]
        [Required]
        public string CodigoManzana { get; set; }

        [Display(Name = "Nombre Manzana")]
        public string NombreManzana { get; set; }

        [Display(Name = "Vía")]
        [Required]
        public string CodigoVia { get; set; }

        [Display(Name = "Nombre Vía")]
        public string NombreVia { get; set; }

        [Display(Name = "Código manzana via")]
        public string CodigoManzanaVia { get; set; }

        [Display(Name = "Cuadra")]
        public Nullable<int> Numcuadra { get; set; }
        [Display(Name = "Lado")]
        public string Posicionlado { get; set; }

        [Display(Name = "Valorización")]
        public Nullable<decimal> Valorizacion { get; set; }

        [Display(Name = "Departamento")]
        public string Departamento { get; set; }
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }
        [Display(Name = "Distrito")]
        public string Distrito { get; set; }

        [Display(Name = "Altura Norm.")]
        public decimal? AlturaNormativa { get; set; }

        [Display(Name = "Retiro Oficial")]
        public decimal? RetiroOficial { get; set; }

        [Display(Name = "Jardin Oficial")]
        public decimal? JardinOficial { get; set; }
        [Display(Name = "Observación")]
        public string ObservacionNormativa { get; set; }
    }

    public class ManzanaViaValorViewModel
    {

        public string CODCORRMANZVIA { get; set; }

        public string CodigoSector { get; set; }

        public string CodigoManzana { get; set; }

        public string CodigoVia { get; set; }

        [Display(Name = "Código manzana via")]
        public string CodigoManzanaVia { get; set; }

        public Nullable<int> Numcuadra { get; set; }

        public string Posicionlado { get; set; }

        [Display(Name = "Valorización")]
        public Nullable<decimal> Valorizacion { get; set; }

        [Display(Name = "Departamento")]
        public string Departamento { get; set; }
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }
        [Display(Name = "Distrito")]
        public string Distrito { get; set; }
    }
}