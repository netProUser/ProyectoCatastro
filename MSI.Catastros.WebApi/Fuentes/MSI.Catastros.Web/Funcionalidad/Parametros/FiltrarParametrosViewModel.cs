using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSI.Catastros.Web.Funcionalidad.Parametros
{
    public class FiltrarParametrosViewModel
    {
        //[Required(AllowEmptyStrings = true)]
        [Display(Name = "Tabla")]
        public string Parametro { get; set; }

        public IEnumerable<ParametrosViewModel> listParametros { get; set; }

        public FiltrarParametrosViewModel()
        {
            listParametros = new List<ParametrosViewModel>();
        }
    }

    public class ParametrosViewModel
    {
        [Display(Name = "Codigo Parámetros")]
        public string CodigoParametro { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Abreviatura")]
        public string Abreviatura { get; set; }
    }
}