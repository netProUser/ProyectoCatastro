using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MSI.Catastros.Web.Funcionalidad.Distritos;

namespace MSI.Catastros.Web.Funcionalidad.Sectores
{
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