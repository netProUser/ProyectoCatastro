using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MSI.Catastros.Web.Funcionalidad.Distritos;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Mantenimientos
{
    public class TablaViewModel
    {
        public string CodigoCampo { get; set; }
        public string NombreCampo { get; set; }
        public string AbreviaturaCampo { get; set; }
        public string EstadoCampo { get; set; }

        public string CodigoAdicional { get; set; }
        public string NombreAdicional { get; set; }
        public List<SelectListItem> ListaCampo { get; set; }
        public int Estado { get; set; }
        public string TipoMantenimiento { get; set; }
    }
    public class MantenimientosViewModel
    {
        [Display(Name = "Codigo Uso del Predio")]
        [StringLength(10)]
        public string FiltrarCodigoUso { get; set; }


        [Display(Name = "Nombre Uso del Predio")]
        public string FiltrarNombreUso { get; set; }

        [Display(Name = "Codigo Inscripción")]
        [StringLength(10)]
        public string FiltrarCodigoInscripcion { get; set; }
        [Display(Name = "Nombre Inscripción")]
        public string FiltrarNombreInscripcion { get; set; }

        [Display(Name = "Codigo Puerta")]
        [StringLength(10)]
        public string FiltrarCodigoPuerta { get; set; }
        [Display(Name = "Nombre Puerta")]
        public string FiltrarNombrePuerta { get; set; }

        [Display(Name = "Codigo Tipo Interior")]
        [StringLength(10)]
        public string FiltrarCodigoTipoInterior { get; set; }
        [Display(Name = "Nombre Tipo Interior")]
        public string FiltrarNombreTipoInterior { get; set; }

        [Display(Name = "Codigo Edificación")]
        [StringLength(10)]
        public string FiltrarCodigoEdificacion { get; set; }
        [Display(Name = "Nombre Edificación")]
        public string FiltrarNombreEdificacion { get; set; }

        public string listSectores { get; set; }

        [Display(Name = "Codigo Documento")]
        [StringLength(3)]
        public string FiltrarCodigoOtroDocumento { get; set; }


        [Display(Name = "Nombre Documento")]
        public string FiltrarNombreOtroDocumento{ get; set; }

        [Display(Name = "Nombre Zonificación")]
        public string FiltrarNombreZonificacion { get; set; }


        [Display(Name = "Abreviatura Zonificación")]
        public string FiltrarAbreviaturaZonificacion{ get; set; }
    }
    public class FiltrarSectoresViewModel
    {
        //[Required(AllowEmptyStrings = true)]
        [Display(Name = "Nombre del sector")]
        [StringLength(30)]
        public string NombreSector { get; set; }

        [Display(Name = "Nombre del sector")]
        public string NombreSectorReg { get; set; }

        [Display(Name = "Código del sector")]
        public string CodigoSector { get; set; }

        [Display(Name = "Distrito")]
        public string CodigoDistrito { get; set; }
        

        //LISTA DE DISTRITOS

        public IEnumerable<DistritoViewModel> listDistritos { get; set; }

        public IEnumerable<SectorViewModel> listSectores { get; set; }

        public FiltrarSectoresViewModel()
        {
            listSectores = new List<SectorViewModel>();
        }
    }
    public class RegistroSectorViewModel : SectorViewModel
    {
        //[Display(Name = "Nombre")]
        //public string NombreSector { get; set; }

        //[Display(Name = "Codigo")]
        //public string CodigoSector { get; set; }

        [Display(Name = "Distrito")]
        [Required]
        public string CodigoDistrito { get; set; }

        //public IEnumerable<DistritoViewModel> Distritos { get; set; }

        public int Estado { get; set; }

    }
    public class SectorViewModel
    {
        [Display(Name = "Código del sector")]
        public string CodigoSector { get; set; }
        [Display(Name = "Nombre del sector")]
        public string NombreSector { get; set; }

        [Display(Name = "Distritos")]
        public string CodigoDistritos { get; set; }

        public IEnumerable<DistritoViewModel> Distritos { get; set; }

    }
}