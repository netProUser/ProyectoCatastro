using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Dociso
{
    public class DocisoViewModel
    {
        public string CODDOCCAT { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese la descripción")]
        [Display(Name = "Descripción")]
        public string txtDescripcion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Seleccione el tipo de documento")]
        public string codTpDocumento { get; set; }

        [Display(Name = "Tipo de Documento")]
        public IEnumerable<SelectListItem> TpDocumento { get; set; }
        public string txtTpDocumento { get; set; }
        public int Estado { get; set; }
    }

    public class DetDocisoViewModel
    {
        public string codFormato { get; set; }
        public string codOrga { get; set; }
        public string txtTitVer { get; set; }
        public string codVersion { get; set; }
        public DateTime? fechainicio { get; set; }
        public DateTime? fechafin { get; set; }
    }

    public class AutoAnioIso
    {
        public string MyProperty { get; set; }
    }
}